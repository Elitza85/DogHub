namespace DogHub.Web.ViewModels.Dogs
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DogHub.Common;

    public class BreedsListViewModel
    {
        public IEnumerable<BreedNames> AllBreeds { get; set; }

        [Required]
        [Display(Name = "Propose New Breed")]
        [MinLength(GlobalConstants.BreedMinLength)]
        [MaxLength(GlobalConstants.BreedMaxLength)]
        public string BreedName { get; set; }

        public bool IsApproved { get; set; }

        public bool IsUnderReview { get; set; }

        public bool IsRejected { get; set; }
    }
}
