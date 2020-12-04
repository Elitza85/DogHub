namespace DogHub.Web.ViewModels.Dogs
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class DogsCatalogueViewModel : PagingViewModel
    {
        public IEnumerable<DogDataInCatalogueViewModel> DogsData { get; set; }

        [Display(Name = "Dog Breed ")]
        public int BreedId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> BreedsItems { get; set; }
    }
}
