namespace DogHub.Services.Data
{
    using DogHub.Web.ViewModels.Competitions;
    using DogHub.Web.ViewModels.Dashboards;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOwnerDashboardsService
    {
        IEnumerable<T> GetAllDogsOwned<T>(string userId);

        DashboardIndexViewModel DogsData(string userId);

        T GetById<T>(int id);

        Task UpdateAsync(int id, EditDogDataInputModel input);

        Task DeleteAsync(int id);

        IEnumerable<DogsInCompetitionsViewModel> DogsInCompetitions(string userId);

        IEnumerable<CompetitionDetailsViewModel> VoteInCompetitionDetails(string userId);
    }
}
