namespace DogHub.Web.Areas.Administration.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DogHub.Web.ViewModels.Administration.Dashboard;
    using DogHub.Web.ViewModels.Competitions;
    using DogHub.Web.ViewModels.Dogs;
    using Microsoft.AspNetCore.Mvc;

    public interface IDashboardService
    {
        Task<string> CreateCompetition(CreateCompetitionInputModel input, string imagePath);

        BreedsListViewModel BreedsListData();

        Task<string> ApproveNewBreed(int breedId);

        Task<string> RejectBreed(int breedId);

        JudgeAppFormsViewModel JudgeAppForms();

        Task<string> ApproveApplication(string userId);

        Task<IActionResult> SendEmailApproval(string userId);

        Task<string> RejectApplication(string userId, string notes);

        Task<IActionResult> SendEmailRejection(string userId);

        IEnumerable<BreedsData> AllBreedsForReport();

        ReportViewModel GetReportData();
    }
}
