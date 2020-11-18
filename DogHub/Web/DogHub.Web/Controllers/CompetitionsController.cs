namespace FirstViewsTests.Controllers
{
    using System.Threading.Tasks;

    using DogHub.Services.Data;
    using DogHub.Web.ViewModels.Competitions;
    using Microsoft.AspNetCore.Mvc;

    public class CompetitionsController : Controller
    {
        private readonly IBreedsListService breedsService;
        private readonly ICompetitionsService competitionsService;

        public CompetitionsController(
            IBreedsListService breedsService,
            ICompetitionsService competitionsService)
        {
            this.breedsService = breedsService;
            this.competitionsService = competitionsService;
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

            await this.competitionsService.Create(input);

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
