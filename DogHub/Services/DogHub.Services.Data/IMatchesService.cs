namespace DogHub.Services.Data
{
    using System.Threading.Tasks;

    using DogHub.Web.ViewModels.DogMatches;

    public interface IMatchesService
    {
        DogMatchViewModel GetSenderDog(int id);

        DogMatchViewModel GetRandomReceiverDog(int id);

        BothDogsDataViewModel GetBothDogs(int id);

        Task SendMatchRequest(int senderDogId, int receiverDogId);

        Task ReceiveMatchRequest(int senderDogId, int receiverDogId);
    }
}
