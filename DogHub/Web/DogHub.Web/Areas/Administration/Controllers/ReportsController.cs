namespace DogHub.Web.Areas.Administration.Controllers
{
    using DogHub.Common;
    using DogHub.Web.Areas.Administration.Services;
    using DogHub.Web.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : BaseController
    {
        private readonly IDashboardService dashboardService;

        public ReportsController(IDashboardService dashboardService)
        {
            this.dashboardService = dashboardService;
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult GetReport()
        {
            var data = this.dashboardService.AllBreedsForReport();

            // var data = this.dashboardService.GetReportData();
            return (JsonResult)data;
        }
    }
}
