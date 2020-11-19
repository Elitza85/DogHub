namespace DogHub.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ErrorsController : Controller
    {
        public IActionResult DogNotApplicableToCompetition()
        {
            return this.View();
        }
    }
}
