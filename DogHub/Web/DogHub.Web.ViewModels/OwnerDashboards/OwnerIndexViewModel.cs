namespace DogHub.Web.ViewModels.OwnerDashboards
{
    using System.Collections.Generic;

    using DogHub.Web.ViewModels.Dogs;

    public class OwnerIndexViewModel
    {
        public IEnumerable<DogDataInCatalogueViewModel> DogsData { get; set; }

        public int DogsCount { get; set; }
    }
}
