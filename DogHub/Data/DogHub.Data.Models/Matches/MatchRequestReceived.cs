namespace DogHub.Data.Models.Matches
{
    using System.ComponentModel.DataAnnotations.Schema;

    using DogHub.Data.Common.Models;

    public class MatchRequestReceived : BaseDeletableModel<int>
    {
        public int DogId { get; set; }

        public virtual Dog Dog { get; set; }

        public int SenderDogId { get; set; }

        public virtual Dog SenderDog { get; set; }

        public bool IsUnderReview { get; set; }

        public bool IsApproved { get; set; }

        public bool IsRejected { get; set; }
    }
}
