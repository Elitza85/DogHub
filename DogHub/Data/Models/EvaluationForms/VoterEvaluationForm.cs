using System.ComponentModel.DataAnnotations;

namespace DogHub.Data.Models.EvaluationForms
{
    public class VoterEvaluationForm : EvaluationForm
    {
        [Required]

        public string VoterId { get; set; }

        public virtual Voter Voter { get; set; }
    }
}
