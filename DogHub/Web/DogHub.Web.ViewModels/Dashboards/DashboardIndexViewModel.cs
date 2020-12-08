namespace DogHub.Web.ViewModels.Dashboards
{
    using System.Collections.Generic;

    using DogHub.Web.ViewModels.Competitions;
    using DogHub.Web.ViewModels.DogMatches;
    using DogHub.Web.ViewModels.Dogs;

    public class DashboardIndexViewModel
    {
        public IEnumerable<DogDataInCatalogueViewModel> DogsData { get; set; }

        public int DogsCount { get; set; }

        public IEnumerable<DogsInCompetitionsViewModel> DogsCompetitionsData { get; set; }

        public IEnumerable<CompetitionDetailsViewModel> RegularVotingData { get; set; }

        public IEnumerable<CompetitionDetailsViewModel> JudgeVotingData { get; set; }

        public IEnumerable<DogPartnershipReguestsViewModel> PartnershipRequestsSent { get; set; }

        public IEnumerable<DogPartnershipReguestsViewModel> PartnershipRequestsReceived { get; set; }
    }
}
