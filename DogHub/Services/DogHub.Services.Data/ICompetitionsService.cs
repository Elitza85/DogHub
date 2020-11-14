namespace DogHub.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DogHub.Web.ViewModels.Competitions;

    public interface ICompetitionsService
    {
        Task Create(CreateCompetitionInputModel input);

        CurrentCompetitionViewModel GetCurrentCompetition();

        IEnumerable<PastCompetitionsViewModel> GetPastCompetitions();

        IEnumerable<UpcomingCompetitionsViewModel> GetUpcomingCompetitions();

        CompetitionDetailsViewModel CompetitionDetails(int id);
    }
}
