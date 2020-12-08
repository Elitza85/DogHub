namespace DogHub.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models;
    using DogHub.Data.Models.Dogs;
    using DogHub.Services.Mapping;
    using DogHub.Web.ViewModels.Dogs;
    using DogHub.Web.ViewModels.Searches;

    public class SearchesService : ISearchesService
    {
        private readonly IDeletableEntityRepository<DogColor> colorsRepository;
        private readonly IDeletableEntityRepository<Dog> dogsRepository;

        public SearchesService(
            IDeletableEntityRepository<DogColor> colorsRepository,
            IDeletableEntityRepository<Dog> dogsRepository)
        {
            this.colorsRepository = colorsRepository;
            this.dogsRepository = dogsRepository;
        }

        public IEnumerable<T> GetAllColors<T>()
        {
            return this.colorsRepository.All()
                .OrderBy(x => x.ColorName)
                .To<T>().ToList();
        }

        public IEnumerable<DogDataInCatalogueViewModel> GetDogsByColors(IEnumerable<int> colorIds)
        {
            if (colorIds == null)
            {
                return null;
            }
            else
            {
                List<DogDataInCatalogueViewModel> dogs = new List<DogDataInCatalogueViewModel>();
                var result = this.dogsRepository.All().AsQueryable();
                var tempResult = this.dogsRepository.All().AsQueryable();
                foreach (var colorId in colorIds)
                {
                    if (this.dogsRepository.All().Any(y => y.DogColorId == colorId))
                    {
                        tempResult = result.Where(y => y.DogColorId == colorId);
                        var listDogs = tempResult.Select(x => new DogDataInCatalogueViewModel
                        {
                            Name = x.Name,
                            DogColorId = x.DogColorId,
                            DogColorColorName = x.DogColor.ColorName,
                            Id = x.Id,
                            ImageUrl = "/images/dogs/" + x.DogImages.FirstOrDefault().Id + "." + x.DogImages.FirstOrDefault().Extension,
                        }).ToList();
                        dogs.AddRange(listDogs);
                    }
                }

                return dogs;
            }
        }

        public IEnumerable<T> GetDogsByBreed<T>(int breedId)
        {
            if (breedId == 0)
            {
                return null;
            }
            else
            {
                var query = this.dogsRepository.All().AsQueryable();
                query = query.Where(x => x.BreedId == breedId);

                return query.To<T>().ToList();
            }
        }
    }
}
