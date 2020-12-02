using DogHub.Data.Common.Repositories;
using DogHub.Data.Models.Competitions;
using DogHub.Data.Models.Dogs;
using DogHub.Web.ViewModels.Competitions;
using DogHub.Web.ViewModels.Dogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DogHub.Web.Areas.Administration.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly string[] AllowedExtensions = new[] { "png", "jpg", "jpeg" };

        private readonly IDeletableEntityRepository<Organiser> organisersRepository;
        private readonly IDeletableEntityRepository<Competition> competitionsRepository;
        private readonly IDeletableEntityRepository<Breed> breedsRepository;

        public DashboardService(
            IDeletableEntityRepository<Organiser> organisersRepository,
            IDeletableEntityRepository<Competition> competitionsRepository,
            IDeletableEntityRepository<Breed> breedsRepository)
        {
            this.organisersRepository = organisersRepository;
            this.competitionsRepository = competitionsRepository;
            this.breedsRepository = breedsRepository;
        }

        public async Task Create(CreateCompetitionInputModel input, string imagePath)
        {
            var competition = new Competition
            {
                BreedId = input.BreedId,
                CompetitionEnd = input.CompetitionEnd,
                CompetitionStart = input.CompetitionStart,
                Name = input.Name,
            };

            var organiser = this.organisersRepository.All()
                .FirstOrDefault(x => x.Name == input.OrganisedBy);
            if (organiser == null)
            {
                organiser = new Organiser
                {
                    Name = input.OrganisedBy,
                };
            }

            competition.Organiser = organiser;

            Directory.CreateDirectory($"{imagePath}/competitions/");
            var image = input.CompetitionImage;
            var extension = Path.GetExtension(image.FileName).TrimStart('.');
            if (!this.AllowedExtensions.Any(x => extension.EndsWith(x)))
            {
                throw new Exception($"Invalid image extenstion {extension}");
            }

            var newImage = new CompetitionImage
            {
                Extension = extension,
            };
            competition.CompetitionImage = newImage;

            var filePath = $"{imagePath}/competitions/{newImage.Id}.{extension}";
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await image.CopyToAsync(fileStream);

            await this.competitionsRepository.AddAsync(competition);
            await this.competitionsRepository.SaveChangesAsync();
        }

        public BreedsListViewModel BreedsListData()
        {
            var breedsPage = new BreedsListViewModel();
            breedsPage.AllBreeds = this.GelAllBreeds();
            return breedsPage;
        }

        public async Task<string> ApproveNewBreed(int breedId)
        {
            var breed = this.breedsRepository.All()
                .Where(x => x.Id == breedId).FirstOrDefault();
            breed.IsApproved = true;
            breed.IsUnderReview = false;

            await this.breedsRepository.SaveChangesAsync();

            return breed.Name;
        }

        private IEnumerable<BreedNames> GelAllBreeds()
        {
            return this.breedsRepository.All()
                .Where(x => x.IsUnderReview == true)
                .Select(x => new BreedNames
                {
                    BreedId = x.Id,
                    BreedName = x.Name,
                })
                .OrderBy(x => x.BreedName)
                .ToList();
        }
    }
}
