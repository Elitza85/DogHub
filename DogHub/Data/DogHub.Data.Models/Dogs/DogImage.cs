namespace DogHub.Data.Models.Dogs
{
    using System.ComponentModel.DataAnnotations.Schema;

    using DogHub.Data.Common.Models;

    public class DogImage : BaseDeletableModel<int>
    {
        [ForeignKey(nameof(Dog))]
        public int DogId { get; set; }

        public virtual Dog Dog { get; set; }

        public string Extension { get; set; }
    }
}
