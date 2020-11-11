using DogHub.Data.Common.Repositories;
using DogHub.Data.Models.Dogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DogHub.Services.Data
{
    public class BreedsListService : IBreedsListService
    {
        private readonly IDeletableEntityRepository<Breed> breedsRepository;

        public BreedsListService(IDeletableEntityRepository<Breed> breedsRepository)
        {
            this.breedsRepository = breedsRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKVP()
        {
            return this.breedsRepository.All().Select(x => new
            {
                x.Id,
                x.BreedName,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.BreedName));
        }
    }
}
