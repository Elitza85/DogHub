namespace FirstViewsTests.Controllers
{
    using DogHub.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    public class CurrentShowsController : Controller
    {
        private readonly ICurrentShowsService currentShowsService;

        public CurrentShowsController(ICurrentShowsService currentShowsService)
        {
            this.currentShowsService = currentShowsService;
        }

        public IActionResult Competitors(int competitionId)
        {
            var viewModel = this.currentShowsService.FullDataOfCurrentShow(competitionId);
            return this.View(viewModel);
        }
    }
}
