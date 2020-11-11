using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DogHub.Data.Models
{
    public class Town
    {
        public Town()
        {
            this.Users = new HashSet<User>();
        }
        [Key]
        public int TownId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.MaxTownLength)]
        public string TownName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
