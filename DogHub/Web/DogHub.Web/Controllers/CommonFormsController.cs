namespace DogHub.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using DogHub.Data.Models;
    using DogHub.Services.Data;
    using DogHub.Web.ViewModels.CommonForms;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CommonFormsController : Controller
    {
        private readonly ICommonFormsService commonFormsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICompetitionsHelpService competitionsHelpService;

        public CommonFormsController(
            ICommonFormsService commonFormsService,
            UserManager<ApplicationUser> userManager,
            ICompetitionsHelpService competitionsHelpService)
        {
            this.commonFormsService = commonFormsService;
            this.userManager = userManager;
            this.competitionsHelpService = competitionsHelpService;
        }

        [Authorize]
        public IActionResult ApplyForJudge()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ApplyForJudge(JudgeApplicationInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (this.commonFormsService.HasAlreadyAppliedForJudge(userId))
            {
                return this.Redirect("/Errors/AlreadyAppliedForJudge");
            }

            input.UserId = userId;
            await this.commonFormsService.ApplyForJudge(input);
            return this.Redirect("/Success/JudgeApplicationSubmission");
        }

        [Authorize]
        public IActionResult Vote(int dogId, int competitionId)
        {
            var userId = this.userManager.GetUserId(this.User);

            var isUserDogOwner = this.commonFormsService.CheckIfUserIsOwner(userId, dogId, competitionId);
            if (!isUserDogOwner)
            {
                return this.Redirect("/Errors/CantVoteForOwnDog");
            }

            var hasUserVoted = this.commonFormsService.CheckIfUserHasVoted(userId, dogId, competitionId);
            if (!hasUserVoted)
            {
                return this.Redirect("/Errors/AlreadyVoted");
            }

            if (this.commonFormsService.IsCompetitionCurrentlyInProgress(competitionId)
                && this.competitionsHelpService.IsDogAddedToCompetition(dogId, competitionId))
            {
                var model = new VoteFormInputModel
                {
                    CompetitionId = competitionId,
                    DogId = dogId,
                };
                return this.View(model);
            }
            else
            {
                return this.Redirect("/Errors/NotPossibleToVote");
            }
        }
    }
}
