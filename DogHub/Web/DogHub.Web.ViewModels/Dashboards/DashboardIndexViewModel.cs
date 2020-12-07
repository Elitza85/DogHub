namespace DogHub.Web.ViewModels.Dashboards
{
    using System.Collections.Generic;

    using DogHub.Web.ViewModels.Dogs;

    public class DashboardIndexViewModel
    {
        public IEnumerable<DogDataInCatalogueViewModel> DogsData { get; set; }

        public int DogsCount { get; set; }
    }
}
