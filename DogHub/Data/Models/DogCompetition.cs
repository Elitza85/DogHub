using DogHub.Data.Models.EvaluationForms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DogHub.Data.Models
{
    public class DogCompetition
    {
        public DogCompetition()
        {
            this.Id = Guid.NewGuid().ToString();
            this.JudgeEvaluationForms = new HashSet<JudgeEvaluationForm>();
            this.VoterEvaluationForms = new HashSet<VoterEvaluationForm>();
        }

        [Key]
        public string Id { get; set; }

        public int DogId { get; set; }

        public virtual Dog Dog { get; set; }

        public int CompetitionId { get; set; }

        public virtual Competition Competition { get; set; }

        public virtual ICollection<JudgeEvaluationForm> JudgeEvaluationForms { get; set; }

        public virtual ICollection<VoterEvaluationForm> VoterEvaluationForms { get; set; }
    }
}
