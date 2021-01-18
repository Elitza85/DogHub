namespace DogHub.Services.Data
{
    using System.Collections.Generic;

    using DogHub.Web.ViewModels.Dogs;

    public interface ISearchesService
    {
        IEnumerable<T> GetAllColors<T>();

        IEnumerable<DogDataInCatalogueViewModel> GetDogsByColors(IEnumerable<int> colorIds);

        IEnumerable<T> GetDogsByBreed<T>(int breedId);
    }
}
