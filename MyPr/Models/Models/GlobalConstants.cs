using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public static class GlobalConstants
    {
        //User
        public const int UserFullNameMaxValue = 50;
        public const int UsernameMaxValue = 30;
        public const int UserEmailMaxValue = 40;
        public const int UserMinAge = 18;
        public const int UserMaxAge = 110;

        //Dog
        public const int DogNameMaxValue = 60;
        public const int BreedMaxLength = 40;
        public const int DogEyesColorMaxLength = 20;
        public const int DogColorMaxLength = 20;
        public const int MinDogAge = 0;
        public const int MaxDogAge = 25;
        public const int MinDogWeight = 0;
        public const int MaxDogWeight = 180;
        public const int DogDescriptionMaxLength = 500;

        //Competition
        public const int CompetitionDescriptionMaxLength = 500;

    }
}
