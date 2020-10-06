using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class EyesColor
    {
        public EyesColor()
        {
            this.Dogs = new HashSet<Dog>();
        }
        [Key]
        public int EyesColorId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DogEyesColorMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Dog> Dogs { get; set; }
    }
}
