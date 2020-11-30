namespace DogHub.Web.Controllers
{
    using DogHub.Services.Data;
    using DogHub.Web.ViewModels.Judges;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class JudgesController : Controller
    {
        private readonly IJudgesService judgesService;

        public JudgesController(IJudgesService judgesService)
        {
            this.judgesService = judgesService;
        }

        public IActionResult JudgesList()
        {
            var viewModel = this.judgesService.JudgesList();
            return this.View(viewModel);
        }
    }
}
