using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DogHub.Data.Models
{
    public class Color
    {
        public Color()
        {
            this.DogsColors = new HashSet<DogColor>();
        }
        [Key]
        public int ColorId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DogColorMaxLength)]
        public string ColorName { get; set; }

        public virtual ICollection<DogColor> DogsColors { get; set; }
    }
}
