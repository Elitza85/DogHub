namespace DogHub.Data.Models.EvaluationForms
{
    using DogHub.Data.Common.Models;
    using DogHub.Data.Models.Competitions;

    public class EvaluationForm : BaseDeletableModel<int>
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int DogId { get; set; }

        public virtual Dog Dog { get; set; }

        public int CompetitionId { get; set; }

        public virtual Competition Competitions { get; set; }

        public int TotalPoints { get; set; }
    }
}
