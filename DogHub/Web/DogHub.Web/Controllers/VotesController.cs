namespace DogHub.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using DogHub.Common;
    using DogHub.Data.Models;
    using DogHub.Services.Data;
    using DogHub.Web.ViewModels.CommonForms;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : BaseController
    {
        private readonly ICommonFormsService commonFormsService;
        private readonly UserManager<ApplicationUser> userManager;

        public VotesController(
            ICommonFormsService commonFormsService,
            UserManager<ApplicationUser> userManager)
        {
            this.commonFormsService = commonFormsService;
            this.userManager = userManager;
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
            var user = await this.userManager.GetUserAsync(this.User);
            var role = await this.userManager.GetRolesAsync(user);

            await this.commonFormsService.VoteForDog(input, user);
            return this.NoContent();
        }
    }
}
