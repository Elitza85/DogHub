namespace DogHub.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DogHub.Web.ViewModels.Dogs;

    public interface IBreedsListService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKVP();

        BreedsListViewModel BreedsListData();

        Task ProposeBreed(BreedsListViewModel input);
    }
}
