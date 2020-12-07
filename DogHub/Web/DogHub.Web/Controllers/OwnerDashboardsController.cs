namespace FirstViewsTests.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using DogHub.Common;
    using DogHub.Services.Data;
    using DogHub.Web.ViewModels.OwnerDashboards;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.DogOwnerUserRoleName)]
    public class OwnerDashboardsController : Controller
    {
        private readonly IOwnerDashboardsService ownerDashboardsService;
        private readonly IBreedsListService breedsListService;

        public OwnerDashboardsController(
            IOwnerDashboardsService ownerDashboardsService,
            IBreedsListService breedsListService)
        {
            this.ownerDashboardsService = ownerDashboardsService;
            this.breedsListService = breedsListService;
        }

        public IActionResult Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var viewModel = this.ownerDashboardsService.DogsData(userId);
            return this.View(viewModel);
        }

        public IActionResult EditDog(int id)
        {
            var inputModel = this.ownerDashboardsService.GetById<EditDogDataInputModel>(id);
            inputModel.BreedsItems = this.breedsListService.GetAllAsKVP();

            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditDog(int id, EditDogDataInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.BreedsItems = this.breedsListService.GetAllAsKVP();
                return this.View(input);
            }

            try
            {
                await this.ownerDashboardsService.UpdateAsync(id, input);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                input.BreedsItems = this.breedsListService.GetAllAsKVP();
                return this.View(input);
            }

            this.TempData["Message"] = string.Format(SuccessMessages.UpdatedDogDataMsg, input.DogName);

            return this.Redirect("/OwnerDashboards/Index");
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
