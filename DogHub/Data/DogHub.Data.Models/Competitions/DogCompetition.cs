namespace DogHub.Data.Models.Competitions
{
    public class DogCompetition
    {
        public int Id { get; set; }

        public int DogId { get; set; }

        public virtual Dog Dog { get; set; }

        public int CompetitionId { get; set; }

        public virtual Competition Competition { get; set; }
    }
}
