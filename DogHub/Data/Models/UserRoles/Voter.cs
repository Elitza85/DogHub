using DogHub.Data.Models.EvaluationForms;

namespace DogHub.Data.Models
{
    public class Voter : User
    {
        public int VoterEvaluationFormId { get; set; }

        public virtual VoterEvaluationForm VoterEvaluationFormResult { get; set; }
    }
}
