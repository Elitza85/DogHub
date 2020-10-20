using DogHub.Data.Models.EvaluationForms;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DogHub.Data.Models.UserRoles
{
    public class Judge : User
    {
        public Judge()
        {
            this.JudgeEvaluationFormResults = new HashSet<JudgeEvaluationForm>();
        }
        //This whole Judge Model could be turned into application form which can lead
        //to approval or denial of a person to become a judge


        //should be above 12 according to professional requirements
        public int YearsOfExperience { get; set; }

        //should be 5 or above
        public int RaisedLitters { get; set; }

        //number of dog-champions that the judge applicant owned or bred is 4 or above
        public int NumberOfChampionsOwned { get; set; }

        //it should be true to be able to become a judge
        public bool HasBeenJudgeAssistant { get; set; }

        //should be true
        public bool AttendedJudgeInstituteCourse { get; set; }

        [Required]
        //It could be made as attachment option at later stage
        public string JudgeInstituteCertificateUrl { get; set; }

        public virtual ICollection<JudgeEvaluationForm> JudgeEvaluationFormResults { get; set; }
    }
}
