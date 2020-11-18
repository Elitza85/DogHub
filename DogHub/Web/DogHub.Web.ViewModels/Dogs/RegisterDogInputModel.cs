namespace DogHub.Web.ViewModels.Dogs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DogHub.Common;
    using DogHub.Data.Models.Dogs;
    using DogHub.Data.Models.Enums;
    using Microsoft.AspNetCore.Http;

    public class RegisterDogInputModel
    {
        public string UserId { get; set; }

        [Display(Name = "Dog Name ")]
        [Required]
        [MinLength(GlobalConstants.DogNameMinValue, ErrorMessage = ErrorMessages.DogNameMinLengthMsg)]
        [MaxLength(GlobalConstants.DogNameMaxValue, ErrorMessage = ErrorMessages.DogNameMaxLengthMsg)]
        public string DogName { get; set; }

        [Display(Name = "Dog Breed ")]
        public int BreedId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> BreedsItems { get; set; }

        [Display(Name = "Dog Gender ")]
        [Required(ErrorMessage = ErrorMessages.DogGenderRequiredMsg)]
        public DogGenderEnum? Gender { get; set; }

        //[Display(Name = "Dog Color ")]
        //public int DogColorId { get; set; }

        //public virtual DogColor DogColor { get; set; }

        [Required(ErrorMessage =ErrorMessages.DogColorRequiredMsg)]
        public string DogColor { get; set; }

        [Display(Name = "Dog Age ")]
        [Range(0, 25, ErrorMessage = ErrorMessages.InvalidAgeRangeMsg)]
        public int? Age { get; set; }

        [Display(Name = "Dog Weight in Kg ")]
        [Required]
        [Range(GlobalConstants.MinDogWeight, GlobalConstants.MaxDogWeight, ErrorMessage = ErrorMessages.DogWeightRangeMsg)]
        public double? Weight { get; set; }

        [Display(Name = "Dog Eyes Color ")]
        public string EyesColor { get; set; }

        [Display(Name = "Dog is For Sale ")]
        [Required(ErrorMessage = ErrorMessages.SellingDogRequiredMsg)]
        public bool? Sellable { get; set; }

        [Display(Name = "Dog is Spayed or Neutered")]
        [Required(ErrorMessage = ErrorMessages.DogSpayedOrNeuteredMsg)]
        public bool? IsSpayedOrNeutered { get; set; }

        [Display(Name = "Dog Description ")]
        [MaxLength(GlobalConstants.DogDescriptionMaxLength)]
        public string Description { get; set; }

        //[Required]
        //[Display(Name = "Dog Images ")]

        //public IEnumerable<IFormFile> Images { get; set; }

        //[Required]

        //[Display(Name = "Dog Video ")]
        //public IFormFile Video { get; set; }

    }
}
