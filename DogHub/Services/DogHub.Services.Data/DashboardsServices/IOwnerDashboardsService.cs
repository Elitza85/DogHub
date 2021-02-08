namespace DogHub.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DogHub.Web.ViewModels.Competitions;
    using DogHub.Web.ViewModels.Dashboards;
    using DogHub.Web.ViewModels.DogMatches;

    public interface IOwnerDashboardsService
    {
        IEnumerable<T> GetAllDogsOwned<T>(string userId);

        DashboardIndexViewModel DashboardData(string userId);

        T GetById<T>(int id);

        Task<bool> UpdateAsync(int id, EditDogDataInputModel input);

        Task DeleteAsync(int id);

        IEnumerable<DogsInCompetitionsViewModel> DogsInCompetitions(string userId);

        IEnumerable<CompetitionDetailsViewModel> VoteInCompetitionDetails(string userId);

        IEnumerable<DogPartnershipReguestsViewModel> GetPartnershipRequestsSent(string userId);

        IEnumerable<DogPartnershipReguestsViewModel> GetPartnershipRequestsReceived(string userId);
    }
}
