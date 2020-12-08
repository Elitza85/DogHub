namespace DogHub.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using DogHub.Data.Common.Models;

    public class MatchRequest : BaseDeletableModel<int>
    {
        public bool IsUnderReview { get; set; }

        public bool IsApproved { get; set; }

        public bool IsRejected { get; set; }
    }
}