namespace FirstViewsTests.Controllers
{
    using System;
    using System.Threading.Tasks;

    using DogHub.Data.Models;
    using DogHub.Services.Data;
    using DogHub.Web.ViewModels.Dogs;
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

        public DogsController(
            IBreedsListService breedsListService,
            IDogsService dogService,
            IWebHostEnvironment webHostEnvironment,
            UserManager<ApplicationUser> userManager)
        {
            this.breedsListService = breedsListService;
            this.dogService = dogService;
            this.webHostEnvironment = webHostEnvironment;
            this.userManager = userManager;
        }

        public IActionResult Catalogue(int id = 1)
        {
            if(id <= 0)
            {
                return this.NotFound();
            }
            var viewModel = this.dogService.DogsData(id, 12);
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

        public async Task<IActionResult> Register(RegisterDogInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.BreedsItems = this.breedsListService.GetAllAsKVP();
                return this.View(input);
            }

            var userId = this.userManager.GetUserId(this.User);
            input.UserId = userId;
            var imagePath = $"{this.webHostEnvironment.WebRootPath}/images";

            try
            {
                await this.dogService.Register(input, imagePath);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                input.BreedsItems = this.breedsListService.GetAllAsKVP();
                return this.View(input);
            }

            return this.Redirect("/Dogs/Catalogue");
        }

        public IActionResult Main()
        {
            return this.View();
        }

        public IActionResult DogProfile(int id)
        {
            var viewModel = this.dogService.DogProfile(id);
            return this.View(viewModel);
        }
    }
}
