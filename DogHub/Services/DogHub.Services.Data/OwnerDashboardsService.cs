namespace DogHub.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models;
    using DogHub.Data.Models.Dogs;
    using DogHub.Services.Mapping;
    using DogHub.Web.ViewModels.Dogs;
    using DogHub.Web.ViewModels.OwnerDashboards;

    public class OwnerDashboardsService : IOwnerDashboardsService
    {
        private readonly IDeletableEntityRepository<Dog> dogsRepository;
        private readonly IDeletableEntityRepository<DogColor> dogColorsRepository;
        private readonly IDeletableEntityRepository<EyesColor> eyesColorRepository;

        public OwnerDashboardsService(
            IDeletableEntityRepository<Dog> dogsRepository,
            IDeletableEntityRepository<DogColor> dogColorsRepository,
            IDeletableEntityRepository<EyesColor> eyesColorRepository)
        {
            this.dogsRepository = dogsRepository;
            this.dogColorsRepository = dogColorsRepository;
            this.eyesColorRepository = eyesColorRepository;
        }

        public IEnumerable<T> GetAllDogsOwned<T>(string userId)
        {
            return this.dogsRepository.All()
                .Where(x => x.UserId == userId && !x.IsDeleted)
                .OrderBy(x => x.Name)
                .To<T>()
                .ToList();
        }

        public OwnerIndexViewModel DogsData(string userId)
        {
            var viewModel = new OwnerIndexViewModel
            {
                DogsCount = this.RegisteredDogsCount(userId),
                DogsData = this.GetAllDogsOwned<DogDataInCatalogueViewModel>(userId),
            };
            return viewModel;
        }

        public T GetById<T>(int id)
        {
            var dog = this.dogsRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return dog;
        }

        public async Task UpdateAsync(int id, EditDogDataInputModel input)
        {
            var dog = this.dogsRepository.All()
                .Where(x => x.Id == id).FirstOrDefault();
            dog.Name = input.DogName;
            dog.BreedId = input.BreedId;
            dog.Age = input.Age;
            dog.Gender = input.Gender;
            dog.Description = input.Description;
            dog.IsSpayedOrNeutered = input.IsSpayedOrNeutered;
            dog.Sellable = input.Sellable;
            dog.Weight = input.Weight;

            int newDogColorId = await this.ValidateDogColor(input);
            dog.DogColorId = newDogColorId;

            int newEyesColorId = await this.ValidateDogEyesColor(input);
            dog.EyesColorId = newEyesColorId;

            if (!input.DogVideoUrl.ToLower().Contains("youtube"))
            {
                throw new Exception("Video should be from YouTube");
            }
            else
            {
                dog.DogVideoUrl = input.DogVideoUrl;
            }

            await this.dogsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dog = this.dogsRepository.All().Where(x => !x.IsDeleted).FirstOrDefault(x => x.Id == id);
            this.dogsRepository.Delete(dog);
            await this.dogsRepository.SaveChangesAsync();
        }

        private async Task<int> ValidateDogEyesColor(EditDogDataInputModel input)
        {
            if (!this.eyesColorRepository.All().Any(x => x.EyesColorName == input.EyesColor))
            {
                await this.eyesColorRepository
                    .AddAsync(new EyesColor { EyesColorName = input.EyesColor });
                await this.eyesColorRepository.SaveChangesAsync();
            }

            int newEyesColorId = this.eyesColorRepository.All().First(x => x.EyesColorName == input.EyesColor).Id;
            return newEyesColorId;
        }

        private async Task<int> ValidateDogColor(EditDogDataInputModel input)
        {
            if (!this.dogColorsRepository.All().Any(x => x.ColorName == input.DogColor))
            {
                await this.dogColorsRepository
                    .AddAsync(new DogColor { ColorName = input.DogColor });
                await this.dogColorsRepository.SaveChangesAsync();
            }

            int newColorId = this.dogColorsRepository.All().First(x => x.ColorName == input.DogColor).Id;
            return newColorId;
        }

        private int RegisteredDogsCount(string userId)
        {
            return this.dogsRepository.All()
                .Where(x => x.UserId == userId).Count();
        }
    }
}
