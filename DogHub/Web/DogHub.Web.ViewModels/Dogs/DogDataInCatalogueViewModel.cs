using AutoMapper;
using DogHub.Data.Models;
using DogHub.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DogHub.Web.ViewModels.Dogs
{
    public class DogDataInCatalogueViewModel : IMapFrom<Dog>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public int BreedId { get; set; }

        public string BreedName { get; set; }

        public bool? Sellable { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Dog, DogDataInCatalogueViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                opt.MapFrom(x => x.DogImages.FirstOrDefault().RemoteImageUrl != null ?
                x.DogImages.FirstOrDefault().RemoteImageUrl :
                "/images/dogs/" + x.DogImages.FirstOrDefault().Id + "." + x.DogImages.FirstOrDefault().Extension));
        }
    }
}
