namespace DogHub.Web.ViewModels.Competitions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AllEventsViewModel
    {
        public CurrentCompetitionViewModel CurrentEvent { get; set; }

        public IEnumerable<PastCompetitionsViewModel> PastEvents { get; set; }

        public IEnumerable<UpcomingCompetitionsViewModel> UpcomingEvents { get; set; }
    }
}
