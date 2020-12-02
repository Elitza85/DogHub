namespace DogHub.Web.Areas.Administration.Controllers
{
    using DogHub.Common;
    using DogHub.Services.Data;
    using DogHub.Web.Areas.Administration.Services;
    using DogHub.Web.ViewModels.Administration.Dashboard;
    using DogHub.Web.ViewModels.Competitions;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    public class DashboardController : AdministrationController
    {
        private readonly ISettingsService settingsService;
        private readonly IBreedsListService breedsService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IDashboardService dashboardService;

        public DashboardController(
            ISettingsService settingsService,
            IBreedsListService breedsService,
            IWebHostEnvironment webHostEnvironment,
            IDashboardService dashboardService)
        {
            this.settingsService = settingsService;
            this.breedsService = breedsService;
            this.webHostEnvironment = webHostEnvironment;
            this.dashboardService = dashboardService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel { SettingsCount = this.settingsService.GetCount(), };
            return this.View(viewModel);
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
                await this.dashboardService.Create(input, imagePath);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                input.BreedsList = this.breedsService.GetAllAsKVP();
                return this.View(input);
            }

            return this.Redirect("/Competitions/CompetitionsList");
        }

        public IActionResult NewBreedsList()
        {
            var viewModel = this.dashboardService.BreedsListData();
            return this.View(viewModel);
        }

        public async Task<IActionResult> ApproveBreed(int breedId)
        {
            var breedName = await this.dashboardService.ApproveNewBreed(breedId);

            this.TempData["Message"] = string.Format(SuccessMessages.ApprovedDogBreedMsg, breedName);
            return this.Redirect("Index");
        }

        public async Task<IActionResult> RejectBreed(int breedId)
        {
            var breedName = await this.dashboardService.RejectBreed(breedId);

            this.TempData["Message"] = string.Format(SuccessMessages.RejectedDogBreedMsg, breedName);
            return this.Redirect("Index");
        }
    }
}
