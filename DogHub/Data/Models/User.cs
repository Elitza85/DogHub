using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DogHub.Data.Models
{
    public class User
    {
        public User()
        {
            this.UserId = Guid.NewGuid().ToString();
            this.Dogs = new HashSet<Dog>();
        }
        [Key]
        [Required]
        public string UserId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.UserFullNameMaxValue)]
        public string FullName { get; set; }


        public int TownId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.UserTownMaxLength)]
        public Town Town { get; set; }

        [Required]
        [MaxLength(GlobalConstants.UsernameMaxValue)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(GlobalConstants.UserEmailMaxValue)]
        public string Email { get; set; }

        //Should be above 18
        public int Age { get; set; }

        public virtual ICollection<Dog> Dogs { get; set; }
    }
}
