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

        AllEventsViewModel AllEvents();

        AddDogToCompetitionInputModel DogsToAddToCompetition(int competitionId, string userId);

        bool DoesDogMeetTheCompetitionRequirements(int dogId, int competitionId);

        Task SuccessfullyAddDogToCompetitionAsync(int dogId, int competitionId);

        Task RemoveDogFromUpcomingCompetition(int dogId, int competitionId);
    }
}
