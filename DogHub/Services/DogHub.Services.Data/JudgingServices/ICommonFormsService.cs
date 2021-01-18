namespace DogHub.Services.Data
{
    using System.Threading.Tasks;

    using DogHub.Data.Models;
    using DogHub.Web.ViewModels.CommonForms;

    public interface ICommonFormsService
    {
        Task ApplyForJudge(JudgeApplicationInputModel input, string imagePath);

        bool HasAlreadyAppliedForJudge(string userId);

        Task VoteForDog(VoteFormInputModel input, ApplicationUser user);

        bool CheckIfUserHasVoted(string userId, int dogId, int competitionId);

        bool CheckIfUserIsOwner(string userId, int dogId, int competitionId);

        public bool IsCompetitionCurrentlyInProgress(int competitionId);

        string GetDogVideoByDogId(int dogId);
    }
}
