namespace DogHub.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class SuccessController : Controller
    {
        public IActionResult JudgeApplicationSubmission()
        {
            return this.View();
        }

        public IActionResult ThankYouForVoting()
        {
            return this.View();
        }
    }
}
