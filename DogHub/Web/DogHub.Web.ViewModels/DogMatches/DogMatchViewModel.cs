using AutoMapper;
using DogHub.Data.Models;
using DogHub.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DogHub.Web.ViewModels.DogMatches
{
    public class DogMatchViewModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string BreedName { get; set; }

        public string Gender { get; set; }
    }
}
