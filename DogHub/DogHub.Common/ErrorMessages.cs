namespace DogHub.Common
{
    public static class ErrorMessages
    {
        // Dog
        public const string DogNameMinLengthMsg = "Dog name should be at least 3 characters.";
        public const string DogNameMaxLengthMsg = "Dog name should be less than 60 characters.";
        public const string DogGenderRequiredMsg = "Dog gender is required, please select from the drop- down list.";
        public const string DogWeightRangeMsg = "Dog weight should be between 0 and 180 kg.";
        public const string SellingDogRequiredMsg = "You need to specifiy whether you sell your dog or no.";
        public const string DogSpayedOrNeuteredMsg = "You must specify whether the dog to be registered is spayes or neutered.";
        public const string InvalidAgeRangeMsg = "Dog age must be in range 0-25 years.";
        public const string DogColorRequiredMsg = "Dog Color is required field.";
        public const string DogImageInvalidFormatMsg = "Dog image should be in one of the following formats: .png, .jpg, .jpeg.";

        // ErrorMsgsInViews
        public const string DogAgeNotAvailableMsg = "Dog age is not available.";
        public const string DogDescriptionNotAvailableMsg = "Dog description is not available.";
    }
}
