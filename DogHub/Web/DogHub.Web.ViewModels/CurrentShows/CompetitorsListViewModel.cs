namespace DogHub.Web.ViewModels.CurrentShows
{
    using System;
    using System.Collections.Generic;

    public class CompetitorsListViewModel
    {
        public int CompetitionId { get; set; }

        public string CompetitionName { get; set; }

        public string CompetitionBreed { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IEnumerable<CompetitorViewModel> CompetitorDogs { get; set; }
    }
}
