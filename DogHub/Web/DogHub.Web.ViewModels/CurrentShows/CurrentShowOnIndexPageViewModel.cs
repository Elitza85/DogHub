namespace DogHub.Web.ViewModels.CurrentShows
{
    using System;

    public class CurrentShowOnIndexPageViewModel
    {
        public int CompetitionId { get; set; }

        public string CompetitionName { get; set; }

        public DateTime CompetitionStart { get; set; }

        public DateTime CompetitionEnd { get; set; }
    }
}
