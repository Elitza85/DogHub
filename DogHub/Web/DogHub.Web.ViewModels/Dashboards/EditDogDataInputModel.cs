namespace DogHub.Web.ViewModels.Dashboards
{
    using AutoMapper;
    using DogHub.Data.Models;
    using DogHub.Services.Mapping;
    using DogHub.Web.ViewModels.Dogs;

    public class EditDogDataInputModel : BaseDogInputModel, IMapFrom<Dog>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int DogColorId { get; set; }

        public int EyesColorId { get; set; }

        public string DogVideoUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Dog, EditDogDataInputModel>()
                .ForMember(x => x.DogName, opt =>
                opt.MapFrom(x => x.Name))
                .ForMember(x => x.EyesColor, opt =>
                opt.MapFrom(x => x.EyesColor.EyesColorName))
                .ForMember(x => x.DogColor, opt =>
                opt.MapFrom(x => x.DogColor.ColorName));
        }
    }
}
