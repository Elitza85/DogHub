using DogHub.Web.ViewModels.Dogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DogHub.Web.ViewModels.Competitions
{
    public class AddDogToCompetitionInputModel
    {
        public int CompetitionId { get; set; }

        public string CompetitionName { get; set; }

        public string CompetitionBreed { get; set; }

        public IEnumerable<PossibleDogApplicantsViewModel> PossibleDogApplicants { get; set; }
    }
}
