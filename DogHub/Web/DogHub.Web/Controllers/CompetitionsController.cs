namespace FirstViewsTests.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CompetitionsController : Controller
    {
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
