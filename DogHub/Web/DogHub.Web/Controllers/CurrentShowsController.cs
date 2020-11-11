namespace FirstViewsTests.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CurrentShowsController : Controller
    {
        public IActionResult Competitors()
        {
            return this.View();
        }

        public IActionResult Vote()
        {
            return this.View();
        }
    }
}
