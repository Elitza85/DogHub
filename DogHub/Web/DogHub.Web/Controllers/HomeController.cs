namespace DogHub.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using DogHub.Services.Data;
    using DogHub.Web.ViewModels;
    using DogHub.Web.ViewModels.CurrentShows;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ICurrentShowsService currentShowsService;

        public HomeController(ICurrentShowsService currentShowsService)
        {
            this.currentShowsService = currentShowsService;
        }

        public IActionResult Index()
        {
            var viewModel = this.currentShowsService.GetCurrentShowData();
            if (viewModel != null)
            {
                return this.View(viewModel);
            }

            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
