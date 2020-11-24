namespace DogHub.Web.ViewModels.Competitions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DogHub.Common;
    using Microsoft.AspNetCore.Http;

    public class CreateCompetitionInputModel
    {
        [Display(Name = "Competition Name")]
        [Required]
        [MaxLength(GlobalConstants.CompetitionNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Competition Image ")]
        public IFormFile CompetitionImage { get; set; }

        [Display(Name = "Competition Start Date and Time")]
        public DateTime CompetitionStart { get; set; }

        [Display(Name = "Competition End Date and Time")]
        public DateTime CompetitionEnd { get; set; }

        [Display(Name = "Organised By")]
        [Required]
        public string OrganisedBy { get; set; }

        [Display(Name = "Breed to Compete")]
        [Required]
        public int BreedId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> BreedsList { get; set; }
    }
}
