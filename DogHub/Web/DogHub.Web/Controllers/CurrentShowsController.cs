namespace FirstViewsTests.Controllers
{
    using DogHub.Services.Data;
    using Microsoft.AspNetCore.Mvc;
    using System;

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
            if (viewModel.StartDate < DateTime.Now && DateTime.Now < viewModel.EndDate)
            {
                return this.View(viewModel);
            }
            else
            {
                return this.Redirect("/Errors/NotPossibleToVote");
            }
        }
    }
}
