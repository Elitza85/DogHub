namespace DogHub.Web.ViewModels.DogMatches
{
    public class DogPartnershipReguestsViewModel
    {
        public int OtherDogId { get; set; }

        public string OtherDogName { get; set; }

        public bool IsUnderReview { get; set; }

        public bool IsApproved { get; set; }

        public bool IsRejected { get; set; }
    }
}
