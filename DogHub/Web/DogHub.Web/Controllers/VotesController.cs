namespace DogHub.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using DogHub.Services.Data;
    using DogHub.Web.ViewModels.CommonForms;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : BaseController
    {
        private readonly ICommonFormsService commonFormsService;

        public VotesController(ICommonFormsService commonFormsService)
        {
            this.commonFormsService = commonFormsService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(VoteFormInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.commonFormsService.VoteForDog(input, userId);
            return this.NoContent();
        }
    }
}
