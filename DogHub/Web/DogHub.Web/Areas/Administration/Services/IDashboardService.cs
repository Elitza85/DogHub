using DogHub.Web.ViewModels.Competitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogHub.Web.Areas.Administration.Services
{
    public interface IDashboardService
    {
        Task Create(CreateCompetitionInputModel input, string imagePath);
    }
}
