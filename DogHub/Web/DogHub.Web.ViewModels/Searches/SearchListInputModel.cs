using System;
using System.Collections.Generic;
using System.Text;

namespace DogHub.Web.ViewModels.Searches
{
    public class SearchListInputModel
    {
        public IEnumerable<int> DogColors { get; set; }

        public int BreedId { get; set; }
    }
}
