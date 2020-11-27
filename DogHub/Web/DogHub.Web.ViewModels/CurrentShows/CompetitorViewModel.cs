namespace DogHub.Web.ViewModels.CurrentShows
{
    using AutoMapper;
    using DogHub.Data.Models;
    using DogHub.Services.Mapping;
    using System.Linq;

    public class CompetitorViewModel
    {
        public string ImageUrl { get; set; }

        public string DogName { get; set; }

        public int CurrentTotalPoints { get; set; }

        public int DogId { get; set; }
    }
}
