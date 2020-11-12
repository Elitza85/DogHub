namespace FirstViewsTests.Controllers
{
    using DogHub.Services.Data;
    using DogHub.Web.ViewModels.Dog;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class DogsController : Controller
    {
        private readonly IBreedsListService breedsListService;
        private readonly IDogService dogService;

        public DogsController(IBreedsListService breedsListService,
            IDogService dogService)
        {
            this.breedsListService = breedsListService;
            this.dogService = dogService;
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
        public async Task<IActionResult> Register(RegisterDogInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.BreedsItems = this.breedsListService.GetAllAsKVP();
                return this.View(input);
            }

            await this.dogService.Register(input);

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
