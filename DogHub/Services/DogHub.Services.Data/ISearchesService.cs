using DogHub.Web.ViewModels.Dogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DogHub.Services.Data
{
    public interface ISearchesService
    {
        IEnumerable<T> GetAllColors<T>();

        IEnumerable<DogDataInCatalogueViewModel> GetDogsByColors(IEnumerable<int> colorIds);

        IEnumerable<T> GetDogsByBreed<T>(int breedId);
    }
}
