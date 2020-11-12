using DogHub.Data.Common.Repositories;
using DogHub.Data.Models;
using DogHub.Data.Models.Dogs;
using DogHub.Web.ViewModels.Dog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogHub.Services.Data
{
    public class DogService : IDogService
    {
        private readonly IDeletableEntityRepository<Dog> dogsRepository;
        private readonly IDeletableEntityRepository<DogColor> dogColorsRepository;
        private readonly IDeletableEntityRepository<EyesColor> eyesColorRepository;

        public DogService(
            IDeletableEntityRepository<Dog> dogsRepository,
            IDeletableEntityRepository<DogColor> dogColorsRepository,
            IDeletableEntityRepository<EyesColor> eyesColorRepository)
        {
            this.dogsRepository = dogsRepository;
            this.dogColorsRepository = dogColorsRepository;
            this.eyesColorRepository = eyesColorRepository;
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
