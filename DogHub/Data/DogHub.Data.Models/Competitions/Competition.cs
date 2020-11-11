namespace DogHub.Data.Models.Competitions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using DogHub.Common;
    using DogHub.Data.Common.Models;
    using DogHub.Data.Models.Dogs;

    public class Competition : BaseDeletableModel<int>
    {
        public Competition()
        {
            this.DogsCompetitions = new HashSet<DogCompetition>();

            // this.CompetitionImages = new HashSet<CompetitionImage>();
        }

        [Required]
        [MaxLength(GlobalConstants.CompetitionNameMaxLength)]
        public string Name { get; set; }

        [ForeignKey(nameof(CompetitionImage))]
        public int CompetitionImageId { get; set; }

        public virtual CompetitionImage CompetitionImage { get; set; }

        public DateTime CompetitionStart { get; set; }

        public DateTime CompetitionEnd { get; set; }

        [Required]
        [MaxLength(GlobalConstants.OrganisedByMaxLength)]
        public string OrganisedBy { get; set; }

        public int BreedId { get; set; }

        public virtual Breed Breed { get; set; }

        // public virtual ICollection<CompetitionImage> CompetitionImages { get; set; }
        public virtual ICollection<DogCompetition> DogsCompetitions { get; set; }
    }
}
