namespace DogHub.Web.ViewModels.DogMatches
{
    public class DogPartnershipReguestsViewModel
    {
        public int SenderDogId { get; set; }

        public string SenderDogName { get; set; }

        public int ReceiverDogId { get; set; }

        public string ReceiverDogName { get; set; }

        public string OtherDogOwnerEmail { get; set; }

        public bool IsUnderReview { get; set; }

        public bool IsApproved { get; set; }

        public bool IsRejected { get; set; }
    }
}
