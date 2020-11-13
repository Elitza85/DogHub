namespace FirstViewsTests.Controllers
{
    using DogHub.Services.Data;
    using DogHub.Web.ViewModels.Competitions;
    using Microsoft.AspNetCore.Mvc;

    public class CompetitionsController : Controller
    {
        private readonly IBreedsListService breedsService;

        public CompetitionsController(IBreedsListService breedsService)
        {
            this.breedsService = breedsService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateCompetitionInputModel();
            viewModel.BreedsList = this.breedsService.GetAllAsKVP();
            return this.View(viewModel);
        }

        //[HttpPost]
        //public IActionResult Create(CreateCompetitionInputModel input)
        //{

        //}
        public IActionResult CompetitionsList()
        {
            return this.View();
        }

        public IActionResult Details()
        {
            return this.View();
        }

        public IActionResult AddDogToCompetition()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult AddDogToCompetition(string competitionId)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            return this.Redirect("/Competitions/Main");
        }
    }
}
