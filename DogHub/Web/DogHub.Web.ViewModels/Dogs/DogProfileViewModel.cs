namespace DogHub.Web.ViewModels.Dogs
{
    using System;
    using System.Linq;

    using AutoMapper;
    using DogHub.Data.Models;
    using DogHub.Services.Mapping;

    public class DogProfileViewModel : IMapFrom<Dog>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string BreedName { get; set; }

        public string DogColorColorName { get; set; }

        public string Gender { get; set; }

        public int? Age { get; set; }

        public double? Weight { get; set; }

        public string EyesColorEyesColorName { get; set; }

        public bool? Sellable { get; set; }

        public bool? IsSpayedOrNeutered { get; set; }

        public string Description { get; set; }

        public int DogsCompetitions { get; set; }

        public string UserId { get; set; }

        public string DogImage { get; set; }

        public string DogVideoUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Dog, DogProfileViewModel>()
                .ForMember(x => x.Gender, opt =>
                opt.MapFrom(x => x.Gender.ToString()))
                .ForMember(x => x.DogsCompetitions, opt =>
                opt.MapFrom(x => x.DogsCompetiotions
                .Where(c => c.Competition.CompetitionEnd < DateTime.Now).Count()))
                .ForMember(x => x.DogImage, opt =>
                opt.MapFrom(x => $"{x.DogImages.FirstOrDefault().FolderPath}" + $"Catalogue_{x.DogImages.FirstOrDefault().Id}" + "." + x.DogImages.FirstOrDefault().Extension));
        }
    }
}
