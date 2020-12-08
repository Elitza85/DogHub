namespace DogHub.Data.Models.Matches
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class MatchRequestSent : MatchRequest
    {
        [ForeignKey(nameof(Dog))]
        public int ReceiverDogId { get; set; }

        public virtual Dog ReceiverDog { get; set; }
    }
}
