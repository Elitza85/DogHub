using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Competition
    {
        public Competition()
        {
            this.DogsCompetitions = new HashSet<DogsCompetitions>();
        }
        public int CompetitionId { get; set; }

        [Required]
        public string Name { get; set; }

        public byte[] Image { get; set; }

        public DateTime CompetitionStart { get; set; }

        public DateTime CompetitionEnd { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CompetitionDescriptionMaxLength)]
        public string Description { get; set; }

        public virtual ICollection<DogsCompetitions> DogsCompetitions { get; set; }
    }
}
