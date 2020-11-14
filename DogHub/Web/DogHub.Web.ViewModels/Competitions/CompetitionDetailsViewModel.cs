namespace DogHub.Web.ViewModels.Competitions
{
    using System;

    public class CompetitionDetailsViewModel
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Status { get; set; }

        public int ParticipantsCount { get; set; }
    }
}
