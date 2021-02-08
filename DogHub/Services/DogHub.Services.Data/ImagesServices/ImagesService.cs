namespace DogHub.Services.Data.ImagesServices
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models;
    using DogHub.Data.Models.CommonForms;
    using DogHub.Data.Models.Competitions;
    using DogHub.Data.Models.Dogs;
    using DogHub.Web.ViewModels.CommonForms;
    using DogHub.Web.ViewModels.Competitions;
    using DogHub.Web.ViewModels.Dogs;
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.Formats.Jpeg;
    using SixLabors.ImageSharp.Processing;

    public class ImagesService : IImagesService
    {
        private const int DogsCatalogueImageWidth = 350;
        private const int DogsDashboardImageWidth = 265;

        private readonly string[] AllowedExtensions = new[] { "png", "jpg", "jpeg" };
        private readonly IRepository<DogImage> dogImages;
        private readonly IDeletableEntityRepository<Dog> dogsRepository;

        public ImagesService(
            IRepository<DogImage> dogImages,
            IDeletableEntityRepository<Dog> dogsRepository)
        {
            this.dogImages = dogImages;
            this.dogsRepository = dogsRepository;
        }

        public async Task AddCompetitionImage(Competition competition, CreateCompetitionInputModel input, string imagePath)
        {
            Directory.CreateDirectory($"{imagePath}/competitions/");
            var image = input.CompetitionImage;
            var extension = Path.GetExtension(image.FileName).TrimStart('.');
            if (!this.AllowedExtensions.Any(x => extension.EndsWith(x)))
            {
                throw new Exception($"Invalid image extenstion {extension}");
            }

            var newImage = new CompetitionImage
            {
                Extension = extension,
            };
            competition.CompetitionImage = newImage;

            var filePath = $"{imagePath}/competitions/{newImage.Id}.{extension}";
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await image.CopyToAsync(fileStream);
        }

        public async Task AddDogImages(Dog dog, RegisterDogInputModel input, string imagePath)
        {
            var tasks = new List<Task>();
            var totalImages = this.dogImages.All().Count();

            input.DogImages.Select(i => new DogImageInputModel
            {
                Content = i.OpenReadStream(),
            });

            foreach (var image in input.DogImages)
            {
                tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        using var imageResult = await Image.LoadAsync(image.OpenReadStream());

                        var currentPath = $"/images/dogs/{totalImages % 100}/";

                        var storingPath = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            $"wwwroot{currentPath}".Replace("/", "\\"));

                        if (!Directory.Exists(storingPath))
                        {
                            Directory.CreateDirectory(storingPath);
                        }

                        var id = Guid.NewGuid().ToString();

                        await this.SaveImage(imageResult, $"Original_{id}", storingPath, imageResult.Width);
                        await this.SaveImage(imageResult, $"Catalogue_{id}", storingPath, DogsCatalogueImageWidth);
                        await this.SaveImage(imageResult, $"Dashboard_{id}", storingPath, DogsDashboardImageWidth);

                        var newImage = new DogImage
                        {
                            Id = id,
                            FolderPath = currentPath,
                            Extension = "jpg",
                        };
                        dog.DogImages.Add(newImage);

                        await this.dogsRepository.SaveChangesAsync();
                    }
                    catch
                    {
                    }
                }));

                await Task.WhenAll(tasks);
            }
        }

        public async Task AddJudgeImage(JudgeApplicationForm appForm, JudgeApplicationInputModel input, string imagePath)
        {
            Directory.CreateDirectory($"{imagePath}/judges/");
            var image = input.JudgeImage;
            var extension = Path.GetExtension(image.FileName).TrimStart('.');
            if (!this.AllowedExtensions.Any(x => extension.EndsWith(x)))
            {
                throw new Exception($"Invalid image extenstion {extension}");
            }

            var newImage = new JudgeImage
            {
                Extension = extension,
            };
            appForm.JudgeImage = newImage;

            var filePath = $"{imagePath}/judges/{newImage.Id}.{extension}";
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await image.CopyToAsync(fileStream);
        }

        private async Task SaveImage(Image imageResult, string name, string path, int resizeWidth)
        {
            var width = imageResult.Width;
            var height = imageResult.Height;

            if (width > resizeWidth)
            {
                height = (int)((double)resizeWidth / width * height);
                width = resizeWidth;
            }

            imageResult.Mutate(i => i.Resize(new
                Size(width, height)));

            imageResult.Metadata.ExifProfile = null;

            await imageResult.SaveAsJpegAsync($"{path}/{name}.jpg", new JpegEncoder
            {
                Quality = 75,
            });
        }
    }
}
