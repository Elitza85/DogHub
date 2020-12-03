using DogHub.Web.ViewModels.Administration.Dashboard;
using DogHub.Web.ViewModels.Competitions;
using DogHub.Web.ViewModels.Dogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogHub.Web.Areas.Administration.Services
{
    public interface IDashboardService
    {
        Task Create(CreateCompetitionInputModel input, string imagePath);

        BreedsListViewModel BreedsListData();

        Task<string> ApproveNewBreed(int breedId);

        Task<string> RejectBreed(int breedId);

        JudgeAppFormsViewModel JudgeAppForms();

        Task<string> ApproveApplication(string userId);

        Task<string> RejectApplication(string userId, string notes);
    }
}
