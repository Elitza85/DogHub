namespace DogHub.Web.ViewModels.Competitions
{
    using Microsoft.AspNetCore.Http;
    using System;

    public class CompetitionDetailsViewModel
    {
        public int CompetitionId { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Status { get; set; }

        public int ParticipantsCount { get; set; }

        public string CompetitionImage { get; set; }
    }
}
