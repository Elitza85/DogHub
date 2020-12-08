namespace DogHub.Services.Data
{
    using DogHub.Web.ViewModels.DogMatches;

    public interface IMatchesService
    {
        DogMatchViewModel GetSenderDog(int id);

        DogMatchViewModel GetRandomReceiverDog(int id);

        BothDogsDataViewModel GetBothDogs(int id);
    }
}
