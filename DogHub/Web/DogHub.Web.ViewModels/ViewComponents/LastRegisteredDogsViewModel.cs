namespace DogHub.Web.ViewModels.ViewComponents
{
    using System.Collections.Generic;

    public class LastRegisteredDogsViewModel
    {
        public string Title { get; set; }

        public IEnumerable<LastRegisteredDogViewModel> DogsData { get; set; }
    }
}
