namespace DogHub.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models.Dogs;
    using DogHub.Services.Mapping;

    public class SearchesService : ISearchesService
    {
        private readonly IDeletableEntityRepository<DogColor> colorsRepository;

        public SearchesService(IDeletableEntityRepository<DogColor> colorsRepository)
        {
            this.colorsRepository = colorsRepository;
        }

        public IEnumerable<T> GetAllColors<T>()
        {
            return this.colorsRepository.All()
                .OrderBy(x => x.ColorName)
                .To<T>().ToList();
        }
    }
}
