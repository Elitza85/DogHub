using DogHub.Web.ViewModels.Dogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DogHub.Web.ViewModels.Searches
{
    public class ListDataViewModel
    {
        public IEnumerable<DogDataInCatalogueViewModel> DogsByColor { get; set; }

        public IEnumerable<DogDataInCatalogueViewModel> DogsByBreed { get; set; }
    }
}
