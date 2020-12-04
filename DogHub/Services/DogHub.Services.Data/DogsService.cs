namespace DogHub.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models;
    using DogHub.Data.Models.Dogs;
    using DogHub.Services.Mapping;
    using DogHub.Web.ViewModels.Dogs;

    public class DogsService : IDogsService
    {
        private readonly string[] AllowedExtensions = new[] { "png", "jpg", "jpeg" };

        private readonly IDeletableEntityRepository<Dog> dogsRepository;
        private readonly IDeletableEntityRepository<DogColor> dogColorsRepository;
        private readonly IDeletableEntityRepository<EyesColor> eyesColorRepository;
        private readonly ICommonFormsService commonFormsService;

        public DogsService(
            IDeletableEntityRepository<Dog> dogsRepository,
            IDeletableEntityRepository<DogColor> dogColorsRepository,
            IDeletableEntityRepository<EyesColor> eyesColorRepository,
            ICommonFormsService commonFormsService)
        {
            this.dogsRepository = dogsRepository;
            this.dogColorsRepository = dogColorsRepository;
            this.eyesColorRepository = eyesColorRepository;
            this.commonFormsService = commonFormsService;
        }

        public DogProfileViewModel DogProfile(int id)
        {
            var dogProfileViewModel = this.dogsRepository.All()
                .Where(x => x.Id == id)
                .Select(y => new DogProfileViewModel
                {
                    Age = y.Age,
                    Breed = y.Breed.Name,
                    Color = y.DogColor.ColorName,
                    CompetitionsCount = y.DogsCompetiotions
                    .Where(c => c.Competition.CompetitionEnd < DateTime.Now).Count(),
                    Description = y.Description,
                    EyesColor = y.EyesColor.EyesColorName,
                    Gender = y.Gender.ToString(),
                    IsSellable = y.Sellable,
                    IsSpayedOrNeutred = y.IsSpayedOrNeutered,
                    Name = y.Name,
                    OwnerId = y.UserId,
                    Weight = y.Weight,
                    DogImage = "/images/dogs/" + y.DogImages.FirstOrDefault().Id + "." + y.DogImages.FirstOrDefault().Extension,
                }).FirstOrDefault();

            var videoString = this.commonFormsService.GetDogVideoByDogId(id);
            dogProfileViewModel.DogVideoUrl = videoString;

            return dogProfileViewModel;
        }

        //public IEnumerable<DogDataInCatalogueViewModel> GetAllDogs(int page, int itemsPerPage = 12)
        //{
        //    return this.dogsRepository.All()
        //        .OrderByDescending(x => x.Id)
        //        .Skip((page - 1) * itemsPerPage)
        //        .Take(itemsPerPage)
        //        .Select(x => new DogDataInCatalogueViewModel
        //        {
        //            Breed = x.Breed.BreedName,
        //            Gender = x.Gender.ToString(),
        //            Name = x.Name,
        //            ImageUrl =
        //            x.DogImages.FirstOrDefault().RemoteImageUrl != null ?
        //            x.DogImages.FirstOrDefault().RemoteImageUrl :
        //            "/images/dogs/" + x.DogImages.FirstOrDefault().Id + "." +
        //            x.DogImages.FirstOrDefault().Extension,
        //            IsSellable = x.Sellable,
        //        }).ToList();
        //}

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12)
        {
            return this.dogsRepository.All()
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();
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

        public async Task Register(RegisterDogInputModel input, string imagePath)
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

            Directory.CreateDirectory($"{imagePath}/dogs/");
            foreach (var image in input.DogImages)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                if (!this.AllowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extenstion {extension}");
                }

                var newImage = new DogImage
                {
                    Extension = extension,
                };
                dog.DogImages.Add(newImage);

                var filePath = $"{imagePath}/dogs/{newImage.Id}.{extension}";
                using Stream fileStream = new FileStream(filePath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }

            if (!this.IsVideoFromYouTube(input.DogVideoUrl))
            {
                throw new Exception("The video should be from YouTube.");
            }

            dog.DogVideoUrl = input.DogVideoUrl;

            await this.dogsRepository.AddAsync(dog);
            await this.dogsRepository.SaveChangesAsync();
        }

        public int GetCount()
        {
            return this.dogsRepository.All().Where(x => !x.IsDeleted).Count();
        }

        public bool IsVideoFromYouTube(string videoString)
        {
            return videoString.Contains("youtube");
        }
    }
}
