using System;
using System.Collections.Generic;
using System.Text;

namespace DogHub.Web.ViewModels.Dogs
{
    public class BreedsListViewModel
    {
        public IEnumerable<BreedNames> AllBreeds { get; set; }
    }
}
