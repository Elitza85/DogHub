using System;
using System.ComponentModel.DataAnnotations;

namespace DogHub.Data.Models.EvaluationForms
{
    public abstract class EvaluationForm
    {
        public EvaluationForm()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        //Possible ranking of all dog criteria varies in range 1-5

        //overall appropriate proportions
        public string Id { get; set; }
        public int BalanceRate { get; set; }

        public int WeightRate { get; set; }

        //color, shape- typical for the breed
        public int EyesRate { get; set; }

        //shape, length, position- typical for the breed
        public int EarsRate { get; set; }

        public int HeadShapeRate { get; set; }

        //shape, length- typical for the breed
        public int MuzzleRate { get; set; }

        //accepted breed colors
        public int ColorRate { get; set; }


        //Make it calculate property in the ViewModel
        public int TotalPoints { get; set; }

        [Required]
        public string DogCompetitionId { get; set; }

        public virtual DogCompetition DogCompetition { get; set; }
    }
}
