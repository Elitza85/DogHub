using DogHub.Data.Models.EvaluationForms;
using System.Collections;
using System.Collections.Generic;

namespace DogHub.Data.Models
{
    public class Voter : User
    {
        public Voter()
        {
            this.VoterEvaluationForms = new HashSet<VoterEvaluationForm>();
        }

        public virtual ICollection<VoterEvaluationForm> VoterEvaluationForms { get; set; }
    }
}
