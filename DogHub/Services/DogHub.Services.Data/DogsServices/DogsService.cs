﻿namespace DogHub.Services.Data
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
            return this.dogsRepository.All().Count();
        }

        public bool IsVideoFromYouTube(string videoString)
        {
            return videoString.Contains("youtube");
        }
    }
}
