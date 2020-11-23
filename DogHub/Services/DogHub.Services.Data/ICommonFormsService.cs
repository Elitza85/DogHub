namespace DogHub.Services.Data
{
    using System.Threading.Tasks;

    using DogHub.Web.ViewModels.CommonForms;

    public interface ICommonFormsService
    {
        Task ApplyForJudge(JudgeApplicationInputModel input);

        Task VoteForDog(VoteFormInputModel input);

        bool CheckIfUserHasVoted(string userId, int dogId, int competitionId);

        bool CheckIfUserIsOwner(string userId, int dogId, int competitionId);

        public bool IsCompetitionCurrentlyInProgress(int competitionId);
    }
}
