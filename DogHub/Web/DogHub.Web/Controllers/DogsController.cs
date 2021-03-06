﻿namespace DogHub.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using DogHub.Common;
    using DogHub.Data.Models;
    using DogHub.Services.Data;
    using DogHub.Web.ViewModels.Dogs;
    using DogHub.Web.ViewModels.Searches;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class DogsController : Controller
    {
        private readonly IBreedsListService breedsListService;
        private readonly IDogsService dogService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ISearchesService searchesService;
        private readonly ICommonFormsService commonFormsService;
        private readonly SignInManager<ApplicationUser> signInManager;

        public DogsController(
            IBreedsListService breedsListService,
            IDogsService dogService,
            IWebHostEnvironment webHostEnvironment,
            UserManager<ApplicationUser> userManager,
            ISearchesService searchesService,
            ICommonFormsService commonFormsService,
            SignInManager<ApplicationUser> signInManager)
        {
            this.breedsListService = breedsListService;
            this.dogService = dogService;
            this.webHostEnvironment = webHostEnvironment;
            this.userManager = userManager;
            this.searchesService = searchesService;
            this.commonFormsService = commonFormsService;
            this.signInManager = signInManager;
        }

        public IActionResult Catalogue(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = this.dogService.DogsData(id, 12);
            viewModel.BreedsItems = this.breedsListService.GetAllAsKVP();
            viewModel.DogColors = this.searchesService.GetAllColors<ColorNameViewModel>();
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Register()
        {
            var viewModel = new RegisterDogInputModel();
            viewModel.BreedsItems = this.breedsListService.GetAllAsKVP();
            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [RequestSizeLimit(10 * 1024 * 1024)]

        public async Task<ActionResult<Result>> Register(RegisterDogInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.BreedsItems = this.breedsListService.GetAllAsKVP();
                return this.View(input);
            }

            var userId = this.userManager.GetUserId(this.User);
            input.UserId = userId;
            var imagePath = $"{this.webHostEnvironment.WebRootPath}/images";

            if (input.DogImages.Any(i => i.Length > 800 * 1024))
            {
                this.ModelState.AddModelError("images", "Each of the images should be less thank 800 KB.");
                input.BreedsItems = this.breedsListService.GetAllAsKVP();
                return this.View(input);
            }

            Result result = await this.dogService.Register(input, imagePath);

            if (!result)
            {
                this.ModelState.AddModelError("error", result.Errors.First());
                input.BreedsItems = this.breedsListService.GetAllAsKVP();
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            if (!this.User.IsInRole(GlobalConstants.DogOwnerUserRoleName))
            {
                await this.userManager.AddToRoleAsync(user, GlobalConstants.DogOwnerUserRoleName);
                await this.signInManager.SignOutAsync();
            }

            this.TempData["Message"] = SuccessMessages.RegisteredDogMsg;

            return this.Redirect("/Dogs/Catalogue");
        }

        public IActionResult Main()
        {
            return this.View();
        }

        public IActionResult DogProfile(int id)
        {
            var viewModel = this.dogService.DogProfile<DogProfileViewModel>(id);
            viewModel.DogVideoUrl = this.commonFormsService.GetDogVideoByDogId(id);

            return this.View(viewModel);
        }

        public IActionResult BreedsList()
        {
            var viewModel = this.breedsListService.BreedsListData();

            return this.View(viewModel);
        }

        public IActionResult ProposeBreed()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> ProposeBreed(BreedsListViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.breedsListService.ProposeBreed(input);

            return this.Redirect("/Success/ThankYouForProposingNewBreed");
        }
    }
}
