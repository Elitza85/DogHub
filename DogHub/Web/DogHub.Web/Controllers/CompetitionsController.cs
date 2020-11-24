namespace FirstViewsTests.Controllers
{
    using System;
    using System.Threading.Tasks;

    using DogHub.Data.Models;
    using DogHub.Services.Data;
    using DogHub.Web.ViewModels.Competitions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CompetitionsController : Controller
    {
        private readonly IBreedsListService breedsService;
        private readonly ICompetitionsService competitionsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CompetitionsController(
            IBreedsListService breedsService,
            ICompetitionsService competitionsService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment webHostEnvironment)
        {
            this.breedsService = breedsService;
            this.competitionsService = competitionsService;
            this.userManager = userManager;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateCompetitionInputModel();
            viewModel.BreedsList = this.breedsService.GetAllAsKVP();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCompetitionInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.BreedsList = this.breedsService.GetAllAsKVP();
                return this.View(input);
            }

            var imagePath = $"{this.webHostEnvironment.WebRootPath}/images";

            try
            {
                await this.competitionsService.Create(input, imagePath);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                input.BreedsList = this.breedsService.GetAllAsKVP();
                return this.View(input);
            }

            return this.Redirect("/Competitions/CompetitionsList");
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
