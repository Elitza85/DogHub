namespace DogHub.Web.ViewModels.Searches
{
    using System.Collections.Generic;

    public class SearchListInputModel
    {
        public IEnumerable<int> DogColors { get; set; }

        public int BreedId { get; set; }
    }
}
