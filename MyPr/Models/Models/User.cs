using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class User
    {
        public User()
        {
            this.Dogs = new HashSet<Dog>();
        }
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.UserFullNameMaxValue)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.UsernameMaxValue)]
        public string Username { get; set; }

        //DO I NEED PASSWORD PROP???

        [Required]
        [EmailAddress]
        [MaxLength(GlobalConstants.UserEmailMaxValue)]
        public string Email { get; set; }


        [Range(GlobalConstants.UserMinAge, GlobalConstants.UserMaxAge)]
        public int Age { get; set; }

        public virtual ICollection<Dog> Dogs { get; set; }
    }
}
