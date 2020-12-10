namespace DogHub.Web.ViewModels.CommonForms
{
    using System.ComponentModel.DataAnnotations;

    using DogHub.Common;
    using Microsoft.AspNetCore.Http;

    public class JudgeApplicationInputModel
    {
        public string UserId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MinLength(GlobalConstants.JudjeNameMinLength)]
        [MaxLength(GlobalConstants.JudgeNameMaxLenght)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MinLength(GlobalConstants.JudjeNameMinLength)]
        [MaxLength(GlobalConstants.JudgeNameMaxLenght)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Describe Yourself")]
        [MinLength(GlobalConstants.JudgeDescriptionMinLength)]
        [MaxLength(GlobalConstants.JudgeDescriptionMaxLength)]
        public string SelfDescription { get; set; }

        [Required]
        [Display(Name = "Profile Image")]
        public IFormFile JudgeImage { get; set; }

        [Display(Name = "Years of Experience ")]
        public int YearsOfExperience { get; set; }

        [Display(Name = "Number of Raised Litters ")]

        // should be 5 or above
        public int RaisedLitters { get; set; }

        [Display(Name = "Number of Dog Champions Owned or Bred")]

        // number of dog-champions that the judge applicant owned or bred is 4 or above
        public int NumberOfChampionsOwned { get; set; }

        // it should be true to be able to become a judge
        [Display(Name = "Have You Ever Been a Judge Assistant ")]
        public bool HasBeenJudgeAssistant { get; set; }

        // should be true
        [Display(Name = "Have You Attended Judge Course ")]
        public bool AttendedJudgeInstituteCourse { get; set; }

        [Required]
        [Display(Name = "Add Location to Your Judge Course Certificate ")]

        public string JudgeInstituteCertificateUrl { get; set; }

        public bool IsApproved => false;

        public bool IsUnderReview => true;

        public bool IsRejected => false;
    }
}
