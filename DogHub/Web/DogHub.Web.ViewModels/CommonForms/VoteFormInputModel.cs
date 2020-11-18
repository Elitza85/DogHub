namespace DogHub.Web.ViewModels.CommonForms
{
    public class VoteFormInputModel
    {
        //public string UserId { get; set; }

        //public virtual ApplicationUser User { get; set; }

        public int DogId { get; set; }

        public int CompetitionId { get; set; }

        public int BalanceRate { get; set; }

        public int WeightRate { get; set; }

        public int EyesRate { get; set; }

        public int EarsRate { get; set; }

        public int HeadShapeRate { get; set; }

        public int MuzzleRate { get; set; }

        public int ColorRate { get; set; }

        public int TotalPoints => this.BalanceRate + this.ColorRate + this.EarsRate + this.EyesRate + this.HeadShapeRate + this.MuzzleRate + this.WeightRate;
    }
}
