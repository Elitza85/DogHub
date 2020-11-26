namespace DogHub.Web.Controllers
{
    using System;
    using System.Threading.Tasks;
    using DogHub.Data.Models;
    using DogHub.Data.Models.EvaluationForms;
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

        //[HttpPost]
        //[Authorize]
        //public async Task<IActionResult> Vote(VoteFormInputModel input)
        //{
        //    if (!this.ModelState.IsValid)
        //    {
        //        return this.View();
        //    }

        //    var userId = this.userManager.GetUserId(this.User);
        //    input.UserId = userId;

        //    await this.commonFormsService.VoteForDog(input);
        //    return this.Redirect("/Success/ThankYouForVoting");
        //}

        //[Authorize]
        //public IActionResult Vote(int dogId, int competitionId)
        //{
        //    var userId = this.userManager.GetUserId(this.User);

        //    var isUserDogOwner = this.commonFormsService.CheckIfUserIsOwner(userId, dogId, competitionId);
        //    if (!isUserDogOwner)
        //    {
        //        return this.Redirect("/Errors/CantVoteForOwnDog");
        //    }

        //    var hasUserVoted = this.commonFormsService.CheckIfUserHasVoted(userId, dogId, competitionId);
        //    if (!hasUserVoted)
        //    {
        //        return this.Redirect("/Errors/AlreadyVoted");
        //    }

        //    if (this.commonFormsService.IsCompetitionCurrentlyInProgress(competitionId)
        //        && this.competitionsHelpService.IsDogAddedToCompetition(dogId, competitionId))
        //    {
        //        return this.View();
        //    }
        //    else
        //    {
        //        return this.Redirect("/Errors/NotPossibleToVote");
        //    }
        //}

        //[HttpPost]
        //[Authorize]
        //public async Task<IActionResult> Vote(int dogId, int competitionId, int totalPoints)
        //{
        //    if (!this.ModelState.IsValid)
        //    {
        //        return this.View();
        //    }

        //    var userId = this.userManager.GetUserId(this.User);

        //    await this.commonFormsService.VoteForDog(dogId, competitionId, totalPoints, userId);
        //    return this.Redirect("/Success/ThankYouForVoting");
        //}
    }
}
