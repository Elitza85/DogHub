namespace DogHub.Web.Controllers
{
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

        public CommonFormsController(ICommonFormsService commonFormsService,
            UserManager<ApplicationUser> userManager)
        {
            this.commonFormsService = commonFormsService;
            this.userManager = userManager;
        }

        public IActionResult ApplyForJudge()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> ApplyForJudge(JudgeApplicationInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

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

            var model = new VoteFormInputModel();
            model.CompetitionId = competitionId;
            model.DogId = dogId;
            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Vote(VoteFormInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var userId = this.userManager.GetUserId(this.User);
            input.UserId = userId;

            await this.commonFormsService.VoteForDog(input);
            return this.Redirect("/Success/ThankYouForVoting");
        }
    }
}
