using System;
using System.Collections.Generic;
using System.Text;

namespace DogHub.Common
{
    public static class ErrorMessages
    {
        //Dog
        public const string DogNameMinLengthMsg = "Dog name should be at least 3 characters.";
        public const string DogNameMaxLengthMsg = "Dog name should be less than 60 characters.";
        public const string DogGenderRequiredMsg = "Dog gender is required, please select from the drop- down list.";
        public const string DogWeightRangeMsg = "Dog weight should be between 0 and 180 kg.";
        public const string SellingDogRequiredMsg = "You need to specifiy whether you sell your dog or no.";
        public const string DogSpayedOrNeuteredMsg = "You must specify whether the dog to be registered is spayes or neutered.";
        public const string InvalidAgeRangeMsg = "Dog age must be in range 0-25 years.";
    }
}
