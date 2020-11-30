namespace DogHub.Web.ViewModels.Judges
{
    using AutoMapper;
    using DogHub.Data.Models.CommonForms;
    using DogHub.Services.Mapping;

    public class SingleJudgeViewModel : IMapFrom<JudgeApplicationForm>, IHaveCustomMappings
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string JudgeImage { get; set; }

        public string SelfDescription { get; set; }

        public int YearsOfExperience { get; set; }

        public int RaisedLitters { get; set; }

        public int NumberOfChampionsOwned { get; set; }

        public bool IsApproved { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<JudgeApplicationForm, SingleJudgeViewModel>()
                .ForMember(x => x.JudgeImage, opt =>
                opt.MapFrom(x => "/images/judges/" + x.JudgeImage.Id + "." + x.JudgeImage.Extension));
        }
    }
}
