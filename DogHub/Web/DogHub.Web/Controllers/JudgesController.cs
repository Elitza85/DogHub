namespace DogHub.Web.Controllers
{
    using DogHub.Services.Data;
    using Microsoft.AspNetCore.Mvc;

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
