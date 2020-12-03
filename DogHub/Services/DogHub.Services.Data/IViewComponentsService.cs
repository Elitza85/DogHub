namespace DogHub.Services.Data
{
    using System.Collections.Generic;

    using DogHub.Web.ViewModels.ViewComponents;

    public interface IViewComponentsService
    {
        IEnumerable<LastRegisteredDogViewModel> LastDogData();

        LastRegisteredDogsViewModel LastRegisteredDogsData();
    }
}
