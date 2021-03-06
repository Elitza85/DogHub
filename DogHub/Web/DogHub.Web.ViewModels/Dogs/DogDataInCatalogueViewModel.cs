﻿namespace DogHub.Web.ViewModels.Dogs
{
    using System.Linq;

    using AutoMapper;
    using DogHub.Data.Models;
    using DogHub.Services.Mapping;

    public class DogDataInCatalogueViewModel : IMapFrom<Dog>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public int BreedId { get; set; }

        public string BreedName { get; set; }

        public string DogColorColorName { get; set; }

        public int DogColorId { get; set; }

        public int TotalPoints { get; set; }

        public bool? Sellable { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Dog, DogDataInCatalogueViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                opt.MapFrom(x => x.DogImages.FirstOrDefault().RemoteImageUrl != null ? x.DogImages.FirstOrDefault().RemoteImageUrl :
                x.DogImages.FirstOrDefault().FolderPath != null ? $"{x.DogImages.FirstOrDefault().FolderPath}" + $"Catalogue_{x.DogImages.FirstOrDefault().Id}" + "." + x.DogImages.FirstOrDefault().Extension :
                "/images/dogs/" + x.DogImages.FirstOrDefault().Id + "." + x.DogImages.FirstOrDefault().Extension))
                .ForMember(x => x.Gender, opt =>
                opt.MapFrom(x => x.Gender.Value.ToString()));
        }

        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    configuration.CreateMap<Dog, DogDataInCatalogueViewModel>()
        //        .ForMember(x => x.ImageUrl, opt =>
        //        opt.MapFrom(x => x.DogImages.FirstOrDefault().RemoteImageUrl != null ?
        //        x.DogImages.FirstOrDefault().RemoteImageUrl :
        //        $"{x.DogImages.FirstOrDefault().FolderPath}" + $"Catalogue_{x.DogImages.FirstOrDefault().Id}" + "." + x.DogImages.FirstOrDefault().Extension))
        //        .ForMember(x => x.Gender, opt =>
        //        opt.MapFrom(x => x.Gender.Value.ToString()));
        //}
    }
}
