using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class DogColor
    {
        public DogColor()
        {
            this.Dogs = new HashSet<Dog>();
        }
        [Key]
        public int ColorId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DogColorMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Dog> Dogs { get; set; }
    }
}
