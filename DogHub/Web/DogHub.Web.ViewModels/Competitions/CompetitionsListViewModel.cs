using System;

namespace DogHub.Web.ViewModels.Competitions
{
    public abstract class CompetitionsListViewModel
    {
        public string Name { get; set; }

        public string Organiser { get; set; }

        public string Breed { get; set; }

        public int CompetitionId { get; set; }
    }
}
