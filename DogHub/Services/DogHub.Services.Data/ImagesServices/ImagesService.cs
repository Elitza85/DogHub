namespace DogHub.Services.Data.ImagesServices
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using DogHub.Data.Models;
    using DogHub.Data.Models.Competitions;
    using DogHub.Data.Models.Dogs;
    using DogHub.Web.ViewModels.Competitions;
    using DogHub.Web.ViewModels.Dogs;

    public class ImagesService : IImagesService
    {
        private readonly string[] AllowedExtensions = new[] { "png", "jpg", "jpeg" };

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
        }
    }
}
