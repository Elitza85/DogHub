namespace DogHub.Data.Models.Dogs
{
    using System.Collections.Generic;

    using DogHub.Data.Common.Models;

    public class DogColor : BaseDeletableModel<int>
    {
        public DogColor()
        {
            this.ColorDogs = new HashSet<Dog>();
        }

        public string ColorName { get; set; }

        public virtual ICollection<Dog> ColorDogs { get; set; }
    }
}
