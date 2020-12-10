namespace DogHub.Web.ViewModels.Searches
{
    using System.Collections.Generic;

    using DogHub.Web.ViewModels.Dogs;

    public class ListDataViewModel
    {
        public IEnumerable<DogDataInCatalogueViewModel> DogsByColor { get; set; }

        public IEnumerable<DogDataInCatalogueViewModel> DogsByBreed { get; set; }
    }
}
