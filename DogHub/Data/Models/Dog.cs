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

        [Required]
        public string DogVideoUrl { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DogNameMaxValue)]
        public string Name { get; set; }

        [Required]
        [MaxLength(GlobalConstants.BreedMaxLength)]
        public string Breed { get; set; }

        public int? Age { get; set; }

        public double Weight { get; set; }

        public int EyesColorId { get; set; }
        public virtual EyesColor EyesColor { get; set; }

        //as it is required by default we do not put [Required]
        public bool Sellable { get; set; }

        [MaxLength(GlobalConstants.DogDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<DogCompetition> DogsCompetiotions { get; set; }

        public virtual ICollection<DogColor> DogsColors { get; set; }
    }
}
