namespace DogHub.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DogHub.Web.ViewModels.Dogs;

    public interface IDogsService
    {
        Task Register(RegisterDogInputModel input, string imagePath);

        DogProfileViewModel DogProfile(int id);

        // IEnumerable<DogDataInCatalogueViewModel> GetAllDogs(int page, int itemsPerPage = 12);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12);

        DogsCatalogueViewModel DogsData(int page, int itemsPerPage = 12);

        int GetCount();
    }
}
