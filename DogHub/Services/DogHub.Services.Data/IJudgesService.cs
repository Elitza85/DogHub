namespace DogHub.Services.Data
{
    using System.Collections.Generic;
    using DogHub.Web.ViewModels.Competitions;
    using DogHub.Web.ViewModels.Judges;

    public interface IJudgesService
    {
        IEnumerable<SingleJudgeViewModel> JudgeDetails<T>();

        public JudgesListViewModel JudgesList();

        IEnumerable<CompetitionDetailsViewModel> VoteInCompetitionsAsJudge(string userId);
    }
}
