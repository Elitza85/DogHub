namespace DogHub.Web.ViewModels.ViewComponents
{
    using System;

    public class LastRegisteredDogViewModel
    {
        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public DateTime RegisteredOn { get; set; }
    }
}
