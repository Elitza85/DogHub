namespace DogHub.Web.ViewModels.Competitions
{
    using System.Collections.Generic;

    public class AllEventsViewModel
    {
        public CurrentCompetitionViewModel CurrentEvent { get; set; }

        public IEnumerable<PastCompetitionsViewModel> PastEvents { get; set; }

        public IEnumerable<UpcomingCompetitionsViewModel> UpcomingEvents { get; set; }
    }
}
