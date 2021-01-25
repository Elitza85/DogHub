namespace DogHub.Services.Data.ImagesServices
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using DogHub.Data.Models;
    using DogHub.Data.Models.Dogs;
    using DogHub.Web.ViewModels.Dogs;

    public class ImagesService : IImagesService
    {
        private readonly string[] AllowedExtensions = new[] { "png", "jpg", "jpeg" };

        public async Task AddDogImage(Dog dog, RegisterDogInputModel input, string imagePath)
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
