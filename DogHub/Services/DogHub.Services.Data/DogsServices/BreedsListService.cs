namespace DogHub.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models.Dogs;
    using DogHub.Web.ViewModels.Dogs;

    public class BreedsListService : IBreedsListService
    {
        private readonly IDeletableEntityRepository<Breed> breedsRepository;

        public BreedsListService(IDeletableEntityRepository<Breed> breedsRepository)
        {
            this.breedsRepository = breedsRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKVP()
        {
            return this.breedsRepository.All()
                .Where(x => x.IsApproved == true)
                .Select(x => new
            {
                x.Id,
                x.Name,
            })
                .OrderBy(x => x.Name)
                .ToList()
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public BreedsListViewModel BreedsListData()
        {
            var breedsPage = new BreedsListViewModel();
            breedsPage.AllBreeds = this.GetAllBreeds();
            return breedsPage;
        }

        public async Task ProposeBreed(BreedsListViewModel input)
        {
            var breedName = input.BreedName.ToLower();
            if (!this.breedsRepository.All().Any(x => x.Name.ToLower() == breedName))
            {
                var newBreedProposal = new Breed
                {
                    Name = input.BreedName,
                    IsRejected = false,
                    IsApproved = false,
                    IsUnderReview = true,
                };

                await this.breedsRepository.AddAsync(newBreedProposal);
                await this.breedsRepository.SaveChangesAsync();
            }
        }

        private IEnumerable<BreedNames> GetAllBreeds()
        {
            return this.breedsRepository.All()
                .Where(x => x.IsApproved == true)
                .Select(x => new BreedNames
                {
                    BreedName = x.Name,
                    TotalDogsInBreed = x.BreedDogs.Count(),
                })
                .OrderBy(x => x.BreedName)
                .ToList();
        }
    }
}
