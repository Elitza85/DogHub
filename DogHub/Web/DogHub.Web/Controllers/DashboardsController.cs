namespace DogHub.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using DogHub.Common;
    using DogHub.Services.Data;
    using DogHub.Web.ViewModels.Dashboards;
    using Microsoft.AspNetCore.Mvc;

    public class DashboardsController : Controller
    {
        private readonly IOwnerDashboardsService ownerDashboardsService;
        private readonly IBreedsListService breedsListService;

        public DashboardsController(
            IOwnerDashboardsService ownerDashboardsService,
            IBreedsListService breedsListService)
        {
            this.ownerDashboardsService = ownerDashboardsService;
            this.breedsListService = breedsListService;
        }

        public IActionResult Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var viewModel = this.ownerDashboardsService.DashboardData(userId);
            return this.View(viewModel);
        }

        public IActionResult EditDog(int id)
        {
            var inputModel = this.ownerDashboardsService.GetById<EditDogDataInputModel>(id);
            inputModel.BreedsItems = this.breedsListService.GetAllAsKVP();

            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<ActionResult<Result>> EditDog(int id, EditDogDataInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.BreedsItems = this.breedsListService.GetAllAsKVP();
                return this.View(input);
            }

            Result result = await this.ownerDashboardsService.UpdateAsync(id, input);

            if (!result)
            {
                this.ModelState.AddModelError("error", result.Errors.First());
                input.BreedsItems = this.breedsListService.GetAllAsKVP();
                return this.View(input);
            }

            this.TempData["Message"] = string.Format(SuccessMessages.UpdatedDogDataMsg, input.DogName);

            return this.Redirect("/Dashboards/Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDog(int id)
        {
            await this.ownerDashboardsService.DeleteAsync(id);

            this.TempData["Message"] = SuccessMessages.DogDeletedMsg;

            return this.RedirectToAction("Index");
        }
    }
}
