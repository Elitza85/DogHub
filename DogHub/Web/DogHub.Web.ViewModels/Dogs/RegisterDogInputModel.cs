namespace DogHub.Web.ViewModels.Dogs
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using DogHub.Data.Models.Dogs;
    using Microsoft.AspNetCore.Http;

    public class RegisterDogInputModel : BaseDogInputModel
    {
        [Required]
        [Display(Name = "Dog Images ")]
        public IEnumerable<IFormFile> DogImages { get; set; }

        //public IEnumerable<DogImageInputModel> DogImages { get; set; }

        [Required]
        [Display(Name = "Link To Your Dog Video")]
        public string DogVideoUrl { get; set; }
    }
}
