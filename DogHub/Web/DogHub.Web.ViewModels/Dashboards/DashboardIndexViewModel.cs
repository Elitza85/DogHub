namespace DogHub.Web.ViewModels.Dashboards
{
    using DogHub.Web.ViewModels.Dogs;
    using System.Collections.Generic;

    public class DashboardIndexViewModel
    {
        public IEnumerable<DogDataInCatalogueViewModel> DogsData { get; set; }

        public int DogsCount { get; set; }

        public IEnumerable<DogsInCompetitionsViewModel> DogsCompetitionsData { get; set; }
    }
}
