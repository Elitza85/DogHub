namespace DogHub.Web.ViewModels.Dogs
{
    using System.ComponentModel.DataAnnotations;

    using DogHub.Common;

    public class NewBreedInputModel
    {
        [Required]
        [MinLength(GlobalConstants.BreedMinLength)]
        [MaxLength(GlobalConstants.BreedMaxLength)]
        public string BreedName { get; set; }

        public bool IsApproved { get; set; }

        public bool IsUnderReview { get; set; }

        public bool IsRejected { get; set; }
    }
}
