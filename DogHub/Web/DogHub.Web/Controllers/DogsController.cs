namespace FirstViewsTests.Controllers
{
    using DogHub.Common;
    using DogHub.Data.Models;
    using DogHub.Services.Data;
    using DogHub.Web.ViewModels.Dogs;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

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

        public IActionResult Catalogue()
        {
            var viewModel = this.dogService.DogsData();
            return this.View(viewModel);
        }

        public IActionResult Register()
        {
            var viewModel = new RegisterDogInputModel();
            viewModel.BreedsItems = this.breedsListService.GetAllAsKVP();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDogInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.BreedsItems = this.breedsListService.GetAllAsKVP();
                return this.View(input);
            }

            //if (!input.Images.FirstOrDefault().FileName.EndsWith(".png")
            //    || !input.Images.FirstOrDefault().FileName.EndsWith(".jpg")
            //    || !input.Images.FirstOrDefault().FileName.EndsWith(".jpeg"))
            //{
            //    this.ModelState.AddModelError("Image", ErrorMessages.DogImageInvalidFormatMsg);
            //}

            //using (FileStream fs = new FileStream(this.webHostEnvironment.WebRootPath + "/" + input.Images.FirstOrDefault().FileName, FileMode.Create))
            //{
            //    await input.Images.FirstOrDefault().CopyToAsync(fs);
            //}
            var userId = this.userManager.GetUserId(this.User);

            input.UserId = userId;
            await this.dogService.Register(input);

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
