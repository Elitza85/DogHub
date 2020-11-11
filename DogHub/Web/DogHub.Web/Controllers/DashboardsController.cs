namespace FirstViewsTests.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class DashboardsController : Controller
    {
        public IActionResult Owner()
        {
            return this.View();
        }

        public IActionResult Voter()
        {
            return this.View();
        }

        public IActionResult Judge()
        {
            return this.View();
        }

        public IActionResult Admin()
        {
            return this.View();
        }
    }
}
