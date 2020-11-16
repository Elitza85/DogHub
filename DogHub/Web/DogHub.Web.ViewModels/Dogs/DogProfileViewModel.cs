using System;
using System.Collections.Generic;
using System.Text;

namespace DogHub.Web.ViewModels.Dogs
{
    public class DogProfileViewModel
    {
        public string Name { get; set; }

        public string Breed { get; set; }

        public string Color { get; set; }

        public string Gender { get; set; }

        public int? Age { get; set; }

        public double? Weight { get; set; }

        public string EyesColor { get; set; }

        public bool? IsSellable { get; set; }

        public bool? IsSpayedOrNeutred { get; set; }

        public string Description { get; set; }

        public int CompetitionsCount { get; set; }

        public string OwnerId { get; set; }

        //public int Image { get; set; }
    }
}
