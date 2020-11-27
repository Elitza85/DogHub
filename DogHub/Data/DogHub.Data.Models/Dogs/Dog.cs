namespace DogHub.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DogHub.Common;
    using DogHub.Data.Common.Models;
    using DogHub.Data.Models.Competitions;
    using DogHub.Data.Models.Dogs;
    using DogHub.Data.Models.Enums;
    using DogHub.Data.Models.EvaluationForms;

    public class Dog : BaseDeletableModel<int>
    {
        public Dog()
        {
            this.DogsCompetiotions = new HashSet<DogCompetition>();
            this.EvaluationForms = new HashSet<EvaluationForm>();
            this.DogImages = new HashSet<DogImage>();
        }

        [Required]
        [MaxLength(GlobalConstants.DogNameMaxValue)]
        public string Name { get; set; }

        [Required]
        public string DogVideoUrl { get; set; }

        public int BreedId { get; set; }

        public virtual Breed Breed { get; set; }

        public DogGenderEnum? Gender { get; set; }

        public int? Age { get; set; }

        public double? Weight { get; set; }

        public int EyesColorId { get; set; }

        public virtual EyesColor EyesColor { get; set; }

        public int DogColorId { get; set; }

        public virtual DogColor DogColor { get; set; }

        public bool? Sellable { get; set; }

        public bool? IsSpayedOrNeutered { get; set; }

        public bool IsSold { get; set; } = false;

        [MaxLength(GlobalConstants.DogDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<DogCompetition> DogsCompetiotions { get; set; }

        public virtual ICollection<EvaluationForm> EvaluationForms { get; set; }

        public virtual ICollection<DogImage> DogImages { get; set; }
    }
}
