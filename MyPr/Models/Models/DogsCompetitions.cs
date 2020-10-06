using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class DogsCompetitions
    {
        public int DogId { get; set; }

        public virtual Dog Dog { get; set; }

        public int CompetitionId { get; set; }

        public virtual Competition Competition { get; set; }
    }
}
