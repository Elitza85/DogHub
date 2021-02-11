namespace DogHub.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DogHub.Common;
    using DogHub.Web.ViewModels.Dogs;

    public interface IDogsService
    {
        // Task<bool> Register(RegisterDogInputModel input, string imagePath);

        Task<Result> Register(RegisterDogInputModel input, string imagePath);

        T DogProfile<T>(int id);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12);

        DogsCatalogueViewModel DogsData(int page, int itemsPerPage = 12);

        int GetCount();
    }
}
