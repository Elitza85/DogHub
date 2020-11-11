namespace DogHub.Services.Data
{
    using System.Collections.Generic;

    public interface IBreedsListService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKVP();
    }
}
