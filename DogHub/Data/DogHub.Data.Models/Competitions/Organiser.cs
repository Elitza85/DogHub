using DogHub.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DogHub.Data.Models.Competitions
{
    public class Organiser : BaseDeletableModel<int>
    {
        public Organiser()
        {
            this.OrganiserCompetitions = new HashSet<Competition>();
        }

        public string Name { get; set; }

        public virtual ICollection<Competition> OrganiserCompetitions { get; set; }
    }
}
