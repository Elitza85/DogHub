﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DogHub.Web.ViewModels.Dogs
{
    public class PossibleDogApplicantsViewModel
    {
        // public int Image { get; set; }
        public int DogId { get; set; }

        public string DogName { get; set; }

        public string DogBreed { get; set; }

        public bool? IsSpayedOrNeutered { get; set; }

        public int CompetitionsParticipatedIn { get; set; }
    }
}
