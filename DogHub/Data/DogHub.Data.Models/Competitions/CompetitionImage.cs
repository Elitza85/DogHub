namespace DogHub.Data.Models.Competitions
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using DogHub.Data.Common.Models;

    public class CompetitionImage : BaseModel<string>
    {
        public CompetitionImage()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [ForeignKey(nameof(Competition))]
        public int CompetitionId { get; set; }

        public virtual Competition Competition { get; set; }

        public string Extension { get; set; }
    }
}
