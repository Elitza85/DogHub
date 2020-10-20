using DogHub.Data.Models.UserRoles;
using System.ComponentModel.DataAnnotations;

namespace DogHub.Data.Models.EvaluationForms
{
    public class JudgeEvaluationForm : EvaluationForm
    {
        [Required]
        public string JudgeId { get; set; }

        public virtual Judge Judge { get; set; }

        
    }
}
