namespace DogHub.Web.ViewModels.Dog
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DogHub.Common;
    using DogHub.Data.Models.Enums;

    public class RegisterDogInputModel : IValidatableObject
    {
        [Display(Name = "Dog Name ")]
        [Required]
        [MinLength(GlobalConstants.DogNameMinValue, ErrorMessage = ErrorMessages.DogNameMinLengthMsg)]
        [MaxLength(GlobalConstants.DogNameMaxValue, ErrorMessage = ErrorMessages.DogNameMaxLengthMsg)]
        public string DogName { get; set; }

        [Display(Name = "Dog Breed ")]
        public string Breed { get; set; }

        [Display(Name = "Dog Breed ")]
        public int BreedId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> BreedsItems { get; set; }

        [Display(Name = "Dog Gender ")]
        [Required(ErrorMessage = ErrorMessages.DogGenderRequiredMsg)]
        public DogGenderEnum? Gender { get; set; }

        [Display(Name = "Dog Age ")]
        [Range(0, 25, ErrorMessage = ErrorMessages.InvalidAgeRangeMsg)]
        public int? Age { get; set; }

        [Display(Name = "Dog Weight in Kg ")]
        [Required]
        [Range(GlobalConstants.MinDogWeight, GlobalConstants.MaxDogWeight, ErrorMessage = ErrorMessages.DogWeightRangeMsg)]
        public double? Weight { get; set; }

        [Display(Name = "Dog Eyes Color ")]
        public string EyesColor { get; set; }

        //public ICollection<EyesColorViewModel> EyesColorsList { get; set; }

        [Display(Name = "Selling Dog ")]
        [Required(ErrorMessage = ErrorMessages.SellingDogRequiredMsg)]
        public bool? Sellable { get; set; }

        [Display(Name = "Is Dog Spayed or Neutered")]
        [Required(ErrorMessage = ErrorMessages.DogSpayedOrNeuteredMsg)]
        public bool? IsSpayedOrNeutered { get; set; }

        [Display(Name = "Dog Description ")]
        [MaxLength(GlobalConstants.DogDescriptionMaxLength)]
        public string Description { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }

        //[Required]

        //[Display(Name ="Dog Image ")]
        //public IFormFile Image { get; set; }

        //[Required]

        //[Display(Name = "Dog Video ")]
        //public IFormFile Video { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if(this.Breed == null || this.BreedsList == null)
        //    {
        //        yield return new 
        //            ValidationResult("Dog breed should be selected or if you can`t find your dog breed in the drop- down list, you need to fill it manually.");
        //    }

        //    if(this.EyesColor == null || this.EyesColorsList == null)
        //    {
        //        yield return new ValidationResult("Dog eyes color should be selected or if you can`t find your dog`s eyes color in the drop- down, you need to fill it manually.");
        //    }
        //}
    }
}
