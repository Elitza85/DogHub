namespace FirstViewsTests.Controllers
{
    using DogHub.Services.Data;
    using DogHub.Web.ViewModels.Dog;
    using Microsoft.AspNetCore.Mvc;

    public class DogsController : Controller
    {
        private readonly IBreedsListService breedsListService;

        public DogsController(IBreedsListService breedsListService)
        {
            this.breedsListService = breedsListService;
        }
        public IActionResult Catalogue()
        {
            return this.View();
        }

        public IActionResult Register()
        {
            var viewModel = new RegisterDogInputModel();
            viewModel.BreedsItems = this.breedsListService.GetAllAsKVP();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Register(RegisterDogInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.BreedsItems = this.breedsListService.GetAllAsKVP();
                return this.View(input);
            }

            return this.Redirect("/Dogs/Catalogue");
        }

        public IActionResult Main()
        {
            return this.View();
        }

        public IActionResult DogProfile()
        {
            return this.View();
        }
    }
}
