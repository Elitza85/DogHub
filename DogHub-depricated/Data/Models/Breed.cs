using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DogHub.Data.Models
{
    public class Breed
    {
        public Breed()
        {
            //this.BreedDogs = new HashSet<Dog>();
        }
        [Key]
        public int BreedId { get; set; }

        public string BreedName { get; set; }

        public virtual ICollection<Dog> BreedDogs { get; set; }
    }
}
