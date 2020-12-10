namespace DogHub.Web.ViewModels.Competitions
{
    using System;
    using System.Collections.Generic;

    public class CompetitionDetailsViewModel
    {
        public int CompetitionId { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Status { get; set; }

        public int ParticipantsCount { get; set; }

        public string CompetitionImage { get; set; }

        public IEnumerable<WinnersViewModel> FemaleDogWinners { get; set; }

        public IEnumerable<WinnersViewModel> MaleDogWinners { get; set; }
    }
}
