namespace DogHub.Web.ViewModels.Competitions
{
    using System.Collections.Generic;

    using DogHub.Web.ViewModels.Dogs;

    public class AddDogToCompetitionInputModel
    {
        public int CompetitionId { get; set; }

        public string CompetitionName { get; set; }

        public string CompetitionBreed { get; set; }

        public IEnumerable<PossibleDogApplicantsViewModel> PossibleDogApplicants { get; set; }
    }
}
