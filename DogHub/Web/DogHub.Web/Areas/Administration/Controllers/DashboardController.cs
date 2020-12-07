namespace DogHub.Web.Areas.Administration.Controllers
{
    using DogHub.Common;
    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models;
    using DogHub.Services.Data;
    using DogHub.Services.Messaging;
    using DogHub.Web.Areas.Administration.Services;
    using DogHub.Web.ViewModels.Administration.Dashboard;
    using DogHub.Web.ViewModels.Competitions;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Text;

    public class DashboardController : AdministrationController
    {
        private readonly ISettingsService settingsService;
        private readonly IBreedsListService breedsService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IDashboardService dashboardService;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IEmailSender emailSender;

        public DashboardController(
            ISettingsService settingsService,
            IBreedsListService breedsService,
            IWebHostEnvironment webHostEnvironment,
            IDashboardService dashboardService,
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            UserManager<ApplicationUser> userManager,
            IEmailSender emailSender)
        {
            this.settingsService = settingsService;
            this.breedsService = breedsService;
            this.webHostEnvironment = webHostEnvironment;
            this.dashboardService = dashboardService;
            this.usersRepository = usersRepository;
            this.userManager = userManager;
            this.emailSender = emailSender;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel { SettingsCount = this.settingsService.GetCount(), };
            return this.View(viewModel);
        }

        public IActionResult CreateCompetition()
        {
            var viewModel = new CreateCompetitionInputModel();
            viewModel.BreedsList = this.breedsService.GetAllAsKVP();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompetition(CreateCompetitionInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.BreedsList = this.breedsService.GetAllAsKVP();
                return this.View(input);
            }

            var imagePath = $"{this.webHostEnvironment.WebRootPath}/images";

            try
            {
                string competitionName = await this.dashboardService.CreateCompetition(input, imagePath);
                this.TempData["Message"] = string.Format(SuccessMessages.SuccessfullyCreatedCompetitionMsg, competitionName);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                input.BreedsList = this.breedsService.GetAllAsKVP();
                return this.View(input);
            }


            return this.Redirect("Index");
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
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var breedName = await this.dashboardService.RejectBreed(breedId);

            this.TempData["Message"] = string.Format(SuccessMessages.RejectedDogBreedMsg, breedName);
            return this.Redirect("Index");
        }

        public IActionResult JudgesFormsList()
        {
            var viewModel = this.dashboardService.JudgeAppForms();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveApplication(string userId)
        {
            var applicantName = await this.dashboardService.ApproveApplication(userId);

            var user = this.usersRepository.All().First(x => x.Id == userId);

            await this.userManager.AddToRoleAsync(user, GlobalConstants.JudgeRoleName);
            await this.dashboardService.SendEmailApproval(userId);

            this.TempData["Message"] = string.Format(SuccessMessages.ApproveJudgeApplication, applicantName);
            return this.Redirect("/Administration/Dashboard");
        }

        [HttpPost]
        public async Task<IActionResult> RejectApplication(JudgeAppFormsViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var applicantName = await this.dashboardService.RejectApplication(input.UserId, input.EvaluatorNotes);

            await this.dashboardService.SendEmailRejection(input.UserId);

            this.TempData["Message"] = string.Format(SuccessMessages.RejectJudgeApplication, applicantName);
            return this.Redirect("Index");
        }
    }
}
