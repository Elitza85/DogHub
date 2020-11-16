using System;
using System.Collections.Generic;
using System.Text;

namespace DogHub.Web.ViewModels.Dogs
{
    public class DogsCatalogueViewModel
    {
        public IEnumerable<DogDataInCatalogueViewModel> DogsData { get; set; }
    }
}
