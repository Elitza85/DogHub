namespace DogHub.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DogHub.Web.ViewModels.OwnerDashboards;

    public interface IOwnerDashboardsService
    {
        IEnumerable<T> GetAllDogsOwned<T>(string userId);

        OwnerIndexViewModel DogsData(string userId);

        T GetById<T>(int id);

        Task UpdateAsync(int id, EditDogDataInputModel input);

    }
}
