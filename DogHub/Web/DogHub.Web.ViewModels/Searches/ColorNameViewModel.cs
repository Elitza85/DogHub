namespace DogHub.Web.ViewModels.Searches
{
    using DogHub.Data.Models.Dogs;
    using DogHub.Services.Mapping;

    public class ColorNameViewModel : IMapFrom<DogColor>
    {
        public int Id { get; set; }

        public string ColorName { get; set; }
    }
}
