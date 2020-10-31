using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DogHub.Data.Models.UserRoles
{
    public class Owner
    {
        public Owner()
        {
            this.OwnerId = Guid.NewGuid().ToString();
            this.Dogs = new HashSet<Dog>();
        }
        [Key]
        public string OwnerId { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Dog> Dogs { get; set; }
    }
}
