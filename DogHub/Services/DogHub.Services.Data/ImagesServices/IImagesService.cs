namespace DogHub.Services.Data.ImagesServices
{
    using System.Threading.Tasks;

    using DogHub.Data.Models;
    using DogHub.Web.ViewModels.Dogs;

    public interface IImagesService
    {
        Task AddDogImage(Dog dog, RegisterDogInputModel input, string imagePath);
    }
}
