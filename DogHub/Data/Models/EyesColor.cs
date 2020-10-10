using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DogHub.Data.Models
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
        public string EyesColorName { get; set; }

        public virtual ICollection<Dog> Dogs { get; set; }
    }
}
