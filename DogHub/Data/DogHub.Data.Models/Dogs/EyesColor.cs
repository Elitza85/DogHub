namespace DogHub.Data.Models.Dogs
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DogHub.Common;
    using DogHub.Data.Common.Models;

    public class EyesColor : BaseDeletableModel<int>
    {
        public EyesColor()
        {
            this.EyesDogs = new HashSet<Dog>();
        }

        [Required]

        [MaxLength(GlobalConstants.DogEyesColorMaxLength)]
        public string EyesColorName { get; set; }

        public virtual ICollection<Dog> EyesDogs { get; set; }
    }
}
