using DogHub.Data.Models.EvaluationForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DogHub.Data.Models
{
    public class Voter 
    {
        public Voter()
        {
            this.VoterId = Guid.NewGuid().ToString();
            this.VoterEvaluationForms = new HashSet<VoterEvaluationForm>();
        }
        [Key]
        public string VoterId { get; set; }
        [Required]

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<VoterEvaluationForm> VoterEvaluationForms { get; set; }
    }
}
