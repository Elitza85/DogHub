using System;
using System.Collections.Generic;
using System.Text;

namespace DogHub.Web.ViewModels.Dogs
{
    public class DogDataInCatalogueViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string Breed { get; set; }

        public bool? IsSellable { get; set; }
    }
}
