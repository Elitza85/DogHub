namespace DogHub.Services.Data
{
    using DogHub.Web.ViewModels.CurrentShows;

    public interface ICurrentShowsService
    {
        CompetitorsListViewModel FullDataOfCurrentShow(int competitionId);
    }
}
