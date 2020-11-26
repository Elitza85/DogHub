namespace DogHub.Data.Models.CommonForms
{
    using System.ComponentModel.DataAnnotations;

    using DogHub.Data.Common.Models;

    public class JudgeApplicationForm : BaseDeletableModel<int>
    {
        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int YearsOfExperience { get; set; }

        // should be 5 or above
        public int RaisedLitters { get; set; }

        // number of dog-champions that the judge applicant owned or bred is 4 or above
        public int NumberOfChampionsOwned { get; set; }

        // it should be true to be able to become a judge
        public bool HasBeenJudgeAssistant { get; set; }

        // should be true
        public bool AttendedJudgeInstituteCourse { get; set; }

        [Required]

        // It could be made as attachment option at later stage
        public string JudgeInstituteCertificateUrl { get; set; }

        public string EvaluatorNotes { get; set; }

        public bool IsApproved => false;

        public bool IsUnderReview => true;

        public bool IsRejected => false;
    }
}
