using DogHub.Web.ViewModels.Dogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DogHub.Services.Data
{
    public interface IDogsService
    {
        Task Register(RegisterDogInputModel input, string imagePath);

        DogProfileViewModel DogProfile(int id);

        // IEnumerable<DogDataInCatalogueViewModel> GetAllDogs(int page, int itemsPerPage = 12);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12);

        DogsCatalogueViewModel DogsData(int page, int itemsPerPage = 12);

        int GetCount();

        BreedsListViewModel BreedsListData();

        Task ProposeBreed(NewBreedInputModel input);
    }
}
