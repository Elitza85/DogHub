using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Dog
    {
        public Dog()
        {
            this.DogsCompetiotions = new HashSet<DogsCompetitions>();
        }
        [Key]
        public int DogId { get; set; }

        public byte[] DogPhoto { get; set; }

        public byte[] DogVideo { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DogNameMaxValue)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(GlobalConstants.BreedMaxLength)]
        public string Breed { get; set; }

        [Range(GlobalConstants.MinDogAge, GlobalConstants.MaxDogAge)]
        public int? Age { get; set; }

        [Range(GlobalConstants.MinDogWeight, GlobalConstants.MaxDogWeight)]
        public double? Weight { get; set; }

        public int EyesColorId { get; set; }
        public virtual EyesColor EyesColor { get; set; }

        public int DogColorId { get; set; }
        public virtual DogColor DogColor { get; set; }

        //as it is required by default we do not put [Required]
        public bool Sellable { get; set; }

        [MaxLength(GlobalConstants.DogDescriptionMaxLength)]
        public string Description { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<DogsCompetitions> DogsCompetiotions { get; set; }
    }
}
