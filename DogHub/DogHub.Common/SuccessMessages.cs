﻿namespace DogHub.Common
{
    public static class SuccessMessages
    {
        // Admin
        public const string ApprovedDogBreedMsg = "You approved the {0} breed.";
        public const string RejectedDogBreedMsg = "You rejected the {0} breed.";
        public const string ApproveJudgeApplication = "You approved the judge application request of {0}.";
        public const string RejectJudgeApplication = "You rejected the application request of {0}.";
        public const string SuccessfullyCreatedCompetitionMsg = "You successfully created {0}.";

        // Owner
        public const string UpdatedDogDataMsg = "You successfully updated the information about your dog {0}.";
        public const string DogDeletedMsg = "You successfully deleted your dog.";
        public const string DogPartnershipRequestSentMsg = "Your dog partnership request was sent.";
        public const string RejectRandomMatchProposalMsg = "You rejected the randomly proposed partner match for your dog.";

        // Dog
        public const string RegisteredDogMsg = "Thank you for registering your dog in the Dog Hub.";
    }
}
