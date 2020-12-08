namespace DogHub.Web.ViewModels.Dashboards
{
    using System.Collections.Generic;

    using DogHub.Web.ViewModels.Dogs;

    public class DogsInCompetitionsViewModel
    {
        public int CompetitionId { get; set; }

        public string CompetitionName { get; set; }

        public string CompetitionImage { get; set; }

        public IEnumerable<DogDataInCatalogueViewModel> AllDogsParticipants { get; set; }
    }
}
