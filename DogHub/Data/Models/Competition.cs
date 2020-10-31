using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DogHub.Data.Models
{
    public class Competition
    {
        public Competition()
        {
            this.DogsCompetitions = new HashSet<DogCompetition>();
            this.BreedsAllowed = new HashSet<Breed>();
        }
        public int CompetitionId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CompetitionNameMaxLength)]
        public string Name { get; set; }

        //Or add image with attachment option
        [Required]
        public string ImageUrl { get; set; }

        public DateTime CompetitionStart { get; set; }

        public DateTime CompetitionEnd { get; set; }

        [Required]
        [MaxLength(GlobalConstants.OrganisedByMaxLength)]
        public string OrganisedBy { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CompetitionDescriptionMaxLength)]
        public string Description { get; set; }

        public virtual ICollection<DogCompetition> DogsCompetitions { get; set; }

        public virtual ICollection<Breed> BreedsAllowed { get; set; }
    }
}
