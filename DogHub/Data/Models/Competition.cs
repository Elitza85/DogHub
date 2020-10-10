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
        }
        public int CompetitionId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CompetitionNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public DateTime CompetitionStart { get; set; }

        public DateTime CompetitionEnd { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CompetitionDescriptionMaxLength)]
        public string Description { get; set; }

        public virtual ICollection<DogCompetition> DogsCompetitions { get; set; }
    }
}
