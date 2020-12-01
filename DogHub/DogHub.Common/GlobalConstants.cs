namespace DogHub.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "DogHub";

        public const string AdministratorRoleName = "Administrator";
        public const string RegularUserRoleName = "Regular";
        public const string DogOwnerUserRoleName = "Owner";

        // User
        public const int UserFullNameMaxValue = 50;
        public const int UsernameMaxValue = 30;
        public const int UserEmailMaxValue = 40;
        public const int UserMinAge = 18;
        public const int UserMaxAge = 110;
        public const int UserTownMaxLength = 30;

        // Dog
        public const int DogNameMinValue = 3;
        public const int DogNameMaxValue = 60;
        public const int BreedMinLength = 3;
        public const int BreedMaxLength = 40;
        public const int DogEyesColorMaxLength = 20;
        public const int DogColorMaxLength = 20;
        public const int MinDogAge = 0;
        public const int MaxDogAge = 25;
        public const int MinDogWeight = 0;
        public const int MaxDogWeight = 180;
        public const int DogDescriptionMaxLength = 250;

        // Competition
        public const int CompetitionDescriptionMaxLength = 500;
        public const int CompetitionNameMaxLength = 100;

        public const int OrganisedByMaxLength = 80;

        // Judge
        public const int JudjeNameMinLength = 2;
        public const int JudgeNameMaxLenght = 20;
        public const int JudgeDescriptionMinLength = 150;
        public const int JudgeDescriptionMaxLength = 250;

        // Chat
        public const int ChatTopicMaxLength = 150;

        // ChatMessage
        public const int ChatMsgMaxLength = 250;
    }
}
