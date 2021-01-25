namespace DogHub.Web.Controllers
{
    using System.Threading.Tasks;

    using DogHub.Data.Models;
    using DogHub.Services.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CompetitionsController : Controller
    {
        private readonly ICompetitionsService competitionsService;
        private readonly UserManager<ApplicationUser> userManager;

        public CompetitionsController(
            ICompetitionsService competitionsService,
            UserManager<ApplicationUser> userManager)
        {
            this.competitionsService = competitionsService;
            this.userManager = userManager;
        }

        public IActionResult CompetitionsList()
        {
            var viewModel = this.competitionsService.AllEvents();

            return this.View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var viewModel = this.competitionsService.CompetitionDetails(id);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult AddDogToCompetition(int id)
        {
            var userId = this.userManager.GetUserId(this.User);
            var viewModel = this.competitionsService.DogsToAddToCompetition(id, userId);
            return this.View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> AddDogToCompetitionOrReturnError(int dogId, int competitionId)
        {
            bool result = this.competitionsService.DoesDogMeetTheCompetitionRequirements(dogId, competitionId);

            if (!result)
            {
                return this.Redirect("/Errors/DogNotApplicableToCompetition");
            }

            await this.competitionsService.SuccessfullyAddDogToCompetitionAsync(dogId, competitionId);

            return this.Redirect("/Success/SuccessfullyAddedDogToCompetition");
        }

        public async Task<IActionResult> RemoveDogFromCompetition(int dogId, int competitionId)
        {
            await this.competitionsService.RemoveDogFromUpcomingCompetition(dogId, competitionId);

            return this.Redirect("/Success/RemovedDogFromCompetition");
        }
    }
}
