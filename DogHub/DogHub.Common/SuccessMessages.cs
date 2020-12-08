namespace DogHub.Common
{
    public static class SuccessMessages
    {
        // Admin

        public const string ApprovedDogBreedMsg = "You approved the {0} breed.";
        public const string RejectedDogBreedMsg = "You rejected the {0} breed.";
        public const string ApproveJudgeApplication = "You approved the judge application request of {0}.";
        public const string RejectJudgeApplication = "You rejected the application request of {0}.";
        public const string SuccessfullyCreatedCompetitionMsg = "You successfully created {0}.";

        //Owner

        public const string UpdatedDogDataMsg = "You successfully updated the information about your dog {0}.";
        public const string DogDeletedMsg = "You successfully deleted your dog.";
        public const string DogPartnershipRequestSentMsg = "You dog partnership request was sent.";

        // Dog
        public const string RegisteredDogMsg = "Thank you for registering your dog in the Dog Hub.";
    }
}
