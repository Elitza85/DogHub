using DogHub.Data.Models.Enums;
using DogHub.Data.Models.UserRoles;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DogHub.Data.Models
{
    public class Dog
    {
        public Dog()
        {
            this.DogsCompetiotions = new HashSet<DogCompetition>();
            this.DogsColors = new HashSet<DogColor>();
        }
        [Key]
        public int DogId { get; set; }

        [Required]
        public string DogPhotoUrl { get; set; }

        //can do it with attach video option at later stage
        [Required]
        public string DogVideoUrl { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DogNameMaxValue)]
        public string Name { get; set; }

        [Required]
        [MaxLength(GlobalConstants.BreedMaxLength)]
        public string Breed { get; set; }

        //drop-down menu with two options
        public DogGender Gender { get; set; }

        public int? Age { get; set; }

        public double Weight { get; set; }

        public int EyesColorId { get; set; }
        public virtual EyesColor EyesColor { get; set; }

        //as it is required by default we do not put [Required]
        public bool Sellable { get; set; }


        public bool IsSold { get; set; } = false;
        
        [MaxLength(GlobalConstants.DogDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public virtual Owner Owner { get; set; }


        public virtual ICollection<DogCompetition> DogsCompetiotions { get; set; }

        public virtual ICollection<DogColor> DogsColors { get; set; }
    }
}
