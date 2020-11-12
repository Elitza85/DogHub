namespace DogHub.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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
        }

        [Required]
        [MaxLength(GlobalConstants.DogNameMaxValue)]
        public string Name { get; set; }

        [ForeignKey(nameof(DogImage))]
        public int? DogImageId { get; set; }

        public virtual DogImage DogImage { get; set; }

        // can do it with attach video option at later stage
        //[Required]
        public string DogVideoUrl { get; set; }

        public int BreedId { get; set; }

        public virtual Breed Breed { get; set; }

        // drop-down menu with two options
        public DogGenderEnum? Gender { get; set; }

        public int? Age { get; set; }

        public double? Weight { get; set; }

        public int EyesColorId { get; set; }

        public virtual EyesColor EyesColor { get; set; }

        public int DogColorId { get; set; }

        public virtual DogColor DogColor { get; set; }

        // as it is required by default we do not put [Required]
        public bool? Sellable { get; set; }

        public bool? IsSpayedOrNeutered { get; set; }

        public bool IsSold { get; set; } = false;

        [MaxLength(GlobalConstants.DogDescriptionMaxLength)]
        public string Description { get; set; }

        // [Required]
        public string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public virtual ICollection<DogCompetition> DogsCompetiotions { get; set; }

        public virtual ICollection<EvaluationForm> EvaluationForms { get; set; }
    }
}
