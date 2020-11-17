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

        // Possible ranking of all dog criteria varies in range 1-5

        // overall appropriate proportions
        public int BalanceRate { get; set; }

        public int WeightRate { get; set; }

        // color, shape- typical for the breed
        public int EyesRate { get; set; }

        // shape, length, position- typical for the breed
        public int EarsRate { get; set; }

        public int HeadShapeRate { get; set; }

        // shape, length- typical for the breed
        public int MuzzleRate { get; set; }

        // accepted breed colors
        public int ColorRate { get; set; }

        // Make it calculate property in the ViewModel
        public int TotalPoints { get; set; }
    }
}
