using DogHub.Data.Common.Repositories;
using DogHub.Data.Models;
using DogHub.Data.Models.Dogs;
using DogHub.Web.ViewModels.Dogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogHub.Services.Data
{
    public class DogsService : IDogsService
    {
        private readonly IDeletableEntityRepository<Dog> dogsRepository;
        private readonly IDeletableEntityRepository<DogColor> dogColorsRepository;
        private readonly IDeletableEntityRepository<EyesColor> eyesColorRepository;

        public DogsService(
            IDeletableEntityRepository<Dog> dogsRepository,
            IDeletableEntityRepository<DogColor> dogColorsRepository,
            IDeletableEntityRepository<EyesColor> eyesColorRepository)
        {
            this.dogsRepository = dogsRepository;
            this.dogColorsRepository = dogColorsRepository;
            this.eyesColorRepository = eyesColorRepository;
        }

        public DogProfileViewModel DogProfile(int id)
        {
            return this.dogsRepository.All()
                .Where(x => x.Id == id)
                .Select(y => new DogProfileViewModel
                {
                    Age = y.Age,
                    Breed = y.Breed.BreedName,
                    Color = y.DogColor.ColorName,
                    CompetitionsCount = y.DogsCompetiotions.Count(),
                    Description = y.Description,
                    EyesColor = y.EyesColor.EyesColorName,
                    Gender = y.Gender.ToString(),
                    IsSellable = y.Sellable,
                    IsSpayedOrNeutred = y.IsSpayedOrNeutered,
                    Name = y.Name,
                    OwnerId = y.OwnerId,
                    Weight = y.Weight,
                }).FirstOrDefault();
        }

        public IEnumerable<DogsCatalogueViewModel> GetAllDogs()
        {
            return this.dogsRepository.All()
                .Select(x => new DogsCatalogueViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Breed = x.Breed.BreedName,
                    Gender = x.Gender.ToString(),
                    IsSellable = x.Sellable.Value,
                }).ToList();
        }

        public async Task Register(RegisterDogInputModel input)
        {
            var dog = new Dog
            {
                Age = input.Age,
                BreedId = input.BreedId,
                Description = input.Description,
                Gender = input.Gender,
                IsSpayedOrNeutered = input.IsSpayedOrNeutered,
                Name = input.DogName,
                Sellable = input.Sellable,
                Weight = input.Weight,
            };

            var dogColor = this.dogColorsRepository.All()
                .FirstOrDefault(x => x.ColorName == input.DogColor);
            if (dogColor == null)
            {
                dogColor = new DogColor { ColorName = input.DogColor };
            }

            var eyesColor = this.eyesColorRepository.All()
                .FirstOrDefault(x => x.EyesColorName == input.EyesColor);
            if (eyesColor == null)
            {
                eyesColor = new EyesColor { EyesColorName = input.EyesColor };
            }

            dog.DogColor = dogColor;
            dog.EyesColor = eyesColor;

            await this.dogsRepository.AddAsync(dog);
            await this.dogsRepository.SaveChangesAsync();
        }
    }
}
