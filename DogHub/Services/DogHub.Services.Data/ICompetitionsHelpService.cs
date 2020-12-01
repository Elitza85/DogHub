namespace DogHub.Services.Data
{
    using System.Collections.Generic;

    using DogHub.Data.Models;
    using DogHub.Data.Models.Competitions;
    using DogHub.Web.ViewModels.Competitions;
    using DogHub.Web.ViewModels.Dogs;

    public interface ICompetitionsHelpService
    {
        IEnumerable<PossibleDogApplicantsViewModel> GetPossibleDogApplicants(string userId, int id);

        string GetDogBreed(int dogId);

        string GetCompetitionRequiredBreed(int competitionId);

        bool IsDogSpayedOrNeutered(int dogId);

        public bool IsDogAddedToCompetition(int dogId, int competitionId);

        Dog GetDogById(int dogId);

        Competition GetCompetitionById(int competitionId);

        IEnumerable<WinnersViewModel> FemaleWinners(int id);

        IEnumerable<WinnersViewModel> MaleWinners(int id);
    }
}
