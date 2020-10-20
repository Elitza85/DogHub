using System.Collections.Generic;

namespace DogHub.Data.Models.UserRoles
{
    public class Owner : User
    {
        public Owner()
        {
            this.Dogs = new HashSet<Dog>();
        }
        public virtual ICollection<Dog> Dogs { get; set; }
    }
}
