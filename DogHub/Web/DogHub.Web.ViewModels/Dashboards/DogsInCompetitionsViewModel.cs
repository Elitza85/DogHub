using DogHub.Web.ViewModels.Dogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DogHub.Web.ViewModels.Dashboards
{
    public class DogsInCompetitionsViewModel
    {
        public int CompetitionId { get; set; }
        public string CompetitionName { get; set; }

        public string CompetitionImage { get; set; }

        public IEnumerable<DogDataInCatalogueViewModel> AllDogsParticipants { get; set; }
    }
}
