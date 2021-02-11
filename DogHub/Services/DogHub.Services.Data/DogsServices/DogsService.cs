namespace DogHub.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DogHub.Common;
    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models;
    using DogHub.Data.Models.Dogs;
    using DogHub.Services.Data.ImagesServices;
    using DogHub.Services.Mapping;
    using DogHub.Web.ViewModels.Dogs;

    public class DogsService : IDogsService
    {
        private readonly IDeletableEntityRepository<Dog> dogsRepository;
        private readonly IDeletableEntityRepository<DogColor> dogColorsRepository;
        private readonly IDeletableEntityRepository<EyesColor> eyesColorRepository;
        private readonly ICommonFormsService commonFormsService;
        private readonly IImagesService imagesService;

        public DogsService(
            IDeletableEntityRepository<Dog> dogsRepository,
            IDeletableEntityRepository<DogColor> dogColorsRepository,
            IDeletableEntityRepository<EyesColor> eyesColorRepository,
            ICommonFormsService commonFormsService,
            IImagesService imagesService)
        {
            this.dogsRepository = dogsRepository;
            this.dogColorsRepository = dogColorsRepository;
            this.eyesColorRepository = eyesColorRepository;
            this.commonFormsService = commonFormsService;
            this.imagesService = imagesService;
        }

        public T DogProfile<T>(int id)
        {
            var dogProfileViewModel = this.dogsRepository.All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return dogProfileViewModel;
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12)
        {
            var result = this.dogsRepository.All()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();

            return result;
        }

        public DogsCatalogueViewModel DogsData(int id, int itemsPerPage = 12)
        {
            const int ItemsPerPage = 12;
            var viewModel = new DogsCatalogueViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                DogsCount = this.GetCount(),
                DogsData = this.GetAll<DogDataInCatalogueViewModel>(id, ItemsPerPage),
            };
            return viewModel;
        }

        public async Task<Result> Register(RegisterDogInputModel input, string imagePath)
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
                UserId = input.UserId,
            };

            this.SetDogColor(input, dog);
            this.SetDogEyesColor(input, dog);

            await this.imagesService.AddDogImages(dog, input, imagePath);

            if (!this.SetDogVideo(input, dog))
            {
                return "Your dog video should be from YouTube.";
            }

            await this.dogsRepository.AddAsync(dog);
            await this.dogsRepository.SaveChangesAsync();
            return true;
        }

        //public async Task<bool> Register(RegisterDogInputModel input, string imagePath)
        //{
        //    var dog = new Dog
        //    {
        //        Age = input.Age,
        //        BreedId = input.BreedId,
        //        Description = input.Description,
        //        Gender = input.Gender,
        //        IsSpayedOrNeutered = input.IsSpayedOrNeutered,
        //        Name = input.DogName,
        //        Sellable = input.Sellable,
        //        Weight = input.Weight,
        //        UserId = input.UserId,
        //    };

        //    this.SetDogColor(input, dog);
        //    this.SetDogEyesColor(input, dog);

        //    await this.imagesService.AddDogImages(dog, input, imagePath);

        //    if (!this.SetDogVideo(input, dog))
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //         await this.dogsRepository.AddAsync(dog);
        //         await this.dogsRepository.SaveChangesAsync();
        //         return true;
        //    }
        //}

        public int GetCount()
        {
            return this.dogsRepository.All().Count();
        }

        public bool IsVideoFromYouTube(string videoString)
        {
            return videoString.Contains("youtube");
        }

        private bool SetDogVideo(RegisterDogInputModel input, Dog dog)
        {
            if (!this.IsVideoFromYouTube(input.DogVideoUrl))
            {
                return false;
            }
            else
            {

                dog.DogVideoUrl = input.DogVideoUrl;
                return true;
            }
        }

        private void SetDogEyesColor(RegisterDogInputModel input, Dog dog)
        {
            var eyesColor = this.eyesColorRepository.All()
                            .FirstOrDefault(x => x.EyesColorName == input.EyesColor);
            if (eyesColor == null)
            {
                eyesColor = new EyesColor { EyesColorName = input.EyesColor };
            }

            dog.EyesColor = eyesColor;
        }

        private void SetDogColor(RegisterDogInputModel input, Dog dog)
        {
            var dogColor = this.dogColorsRepository.All()
                            .FirstOrDefault(x => x.ColorName == input.DogColor);
            if (dogColor == null)
            {
                dogColor = new DogColor { ColorName = input.DogColor };
            }

            dog.DogColor = dogColor;
        }
    }
}
