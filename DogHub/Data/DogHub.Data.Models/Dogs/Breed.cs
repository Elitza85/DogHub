namespace DogHub.Data.Models.Dogs
{
    using System.Collections.Generic;

    using DogHub.Data.Common.Models;
    using DogHub.Data.Models.Competitions;

    public class Breed : BaseDeletableModel<int>
    {
        public Breed()
        {
            this.BreedDogs = new HashSet<Dog>();
            this.BreedCompetitions = new HashSet<Competition>();
        }

        public string Name { get; set; }

        public bool IsApproved { get; set; }

        public bool IsUnderReview { get; set; }

        public bool IsRejected { get; set; }

        public virtual ICollection<Dog> BreedDogs { get; set; }

        public virtual ICollection<Competition> BreedCompetitions { get; set; }
    }
}
