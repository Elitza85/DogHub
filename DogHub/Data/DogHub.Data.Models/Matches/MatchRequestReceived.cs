namespace DogHub.Data.Models.Matches
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class MatchRequestReceived : MatchRequest
    {
        [ForeignKey(nameof(Dog))]
        public int SenderDogId { get; set; }

        public virtual Dog SenderDog { get; set; }
    }
}
