using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class DogsCompetitions
    {
        public int DogId { get; set; }

        public virtual Dog Dog { get; set; }

        public int CompetitionId { get; set; }

        public virtual Competition Competition { get; set; }

        //overall appropriate proportions
        [Range(1,5)]
        public int BalanceRate { get; set; }

        [Range(1, 5)]
        public int WeightRate { get; set; }

        //color, shape- typical for the breed
        [Range(1, 5)]
        public int EyesRate { get; set; }

        //shape, length, position- typical for the breed
        [Range(1, 5)]
        public int EarsRate { get; set; }

        [Range(1, 5)]
        public int HeadShapeRate { get; set; }

        //shape, length- typical for the breed
        [Range(1, 5)]
        public int MuzzleRate { get; set; }

        //accepted breed colors
        [Range(1, 5)]
        public int ColorRate { get; set; }

        [Range(5, 35)]
        public int TotalPoints { get; set; }
    }
}
