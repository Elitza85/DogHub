namespace DogHub.Web.Controllers
{
    using System.Threading.Tasks;

    using DogHub.Services.Data;
    using DogHub.Web.ViewModels.CommonForms;
    using Microsoft.AspNetCore.Mvc;

    public class CommonFormsController : Controller
    {
        private readonly ICommonFormsService commonFormsService;

        public CommonFormsController(ICommonFormsService commonFormsService)
        {
            this.commonFormsService = commonFormsService;
        }

        public IActionResult ApplyForJudge()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> ApplyForJudge(JudgeApplicationInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.commonFormsService.ApplyForJudge(input);
            return this.Redirect("/Success/JudgeApplicationSubmission");
        }
    }
}
