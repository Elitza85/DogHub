namespace DogHub.Data.Models.Competitions
{
    using System.ComponentModel.DataAnnotations.Schema;

    using DogHub.Data.Common.Models;

    public class CompetitionImage : BaseDeletableModel<int>
    {
        [ForeignKey(nameof(Competition))]
        public int CompetitionId { get; set; }

        public virtual Competition Competition { get; set; }

        public string Extension { get; set; }
    }
}
