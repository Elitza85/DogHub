namespace DogHub.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models;
    using DogHub.Data.Models.Matches;
    using DogHub.Web.ViewModels.DogMatches;

    public class MatchesService : IMatchesService
    {
        private readonly IDeletableEntityRepository<Dog> dogsRepository;
        private readonly IDeletableEntityRepository<MatchRequestSent> sentRequestsRepository;
        private readonly IDeletableEntityRepository<MatchRequestReceived> receivedRequestsRepository;

        public MatchesService(
            IDeletableEntityRepository<Dog> dogsRepository,
            IDeletableEntityRepository<MatchRequestSent> sentRequestsRepository,
            IDeletableEntityRepository<MatchRequestReceived> receivedRequestsRepository)
        {
            this.dogsRepository = dogsRepository;
            this.sentRequestsRepository = sentRequestsRepository;
            this.receivedRequestsRepository = receivedRequestsRepository;
        }

        public BothDogsDataViewModel GetBothDogs(int id)
        {
            var viewModel = new BothDogsDataViewModel
            {
                SenderDog = this.GetSenderDog(id),
                ReceiverDog = this.GetRandomReceiverDog(id),
            };
            return viewModel;
        }

        public DogMatchViewModel GetRandomReceiverDog(int id)
        {
            var senderDog = this.dogsRepository.All()
                .Where(x => x.Id == id).FirstOrDefault();

            var receiverDog = this.dogsRepository.All()
                .Where(x => x.Id != senderDog.Id
                && x.UserId != senderDog.UserId
                && x.Gender != senderDog.Gender
                && x.BreedId == senderDog.BreedId
                && x.IsSpayedOrNeutered == false)
                .OrderBy(x => Guid.NewGuid())
                .Select(d => new DogMatchViewModel
                {
                    Id = d.Id,
                    UserId = d.UserId,
                    Name = d.Name,
                    BreedName = d.Breed.Name,
                    ImageUrl = "/images/dogs/" + d.DogImages.FirstOrDefault().Id + "." + d.DogImages.FirstOrDefault().Extension,
                    Gender = d.Gender.ToString(),
                })
                .FirstOrDefault();

            return receiverDog;
        }

        public DogMatchViewModel GetSenderDog(int id)
        {
            var senderDog = this.dogsRepository.All()
                .Where(x => x.Id == id)
                .Select(x => new DogMatchViewModel
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    Name = x.Name,
                    ImageUrl = "/images/dogs/" + x.DogImages.FirstOrDefault().Id + "." + x.DogImages.FirstOrDefault().Extension,
                    BreedName = x.Breed.Name,
                    Gender = x.Gender.ToString(),
                }).FirstOrDefault();
            return senderDog;
        }

        public async Task SendMatchRequest(int senderDogId, int receiverDogId, string userId)
        {
            var sentRequest = new MatchRequestSent
            {
                UserId = userId,
                SenderDogId = senderDogId,
                ReceiverDogId = receiverDogId,
                IsUnderReview = true,
                IsRejected = false,
                IsApproved = false,
            };

            await this.sentRequestsRepository.AddAsync(sentRequest);
            await this.sentRequestsRepository.SaveChangesAsync();
        }

        public async Task ReceiveMatchRequest(int senderDogId, int receiverDogId)
        {
            var receiverDog = this.dogsRepository.All()
                .Where(x => x.Id == receiverDogId).FirstOrDefault();

            var receivedRequest = new MatchRequestReceived
            {
                UserId = receiverDog.UserId,
                SenderDogId = senderDogId,
                ReceiverDogId = receiverDogId,
                IsUnderReview = true,
                IsRejected = false,
                IsApproved = false,
            };

            await this.receivedRequestsRepository.AddAsync(receivedRequest);
            await this.receivedRequestsRepository.SaveChangesAsync();
        }

        public async Task ApproveRequest(int receiverDogId)
        {
            var sentRequest = this.sentRequestsRepository.All()
                .Where(x => x.ReceiverDogId == receiverDogId)
                .FirstOrDefault();
            sentRequest.IsApproved = true;
            sentRequest.IsUnderReview = false;

            var receivedRequest = this.receivedRequestsRepository.All()
                .Where(x => x.ReceiverDogId == receiverDogId)
                .FirstOrDefault();
            receivedRequest.IsApproved = true;
            receivedRequest.IsUnderReview = false;

            await this.sentRequestsRepository.SaveChangesAsync();
            await this.receivedRequestsRepository.SaveChangesAsync();
        }

        public async Task RejectRequest(int receiverDogId)
        {
            var sendRequest = this.sentRequestsRepository.All()
                .Where(x => x.ReceiverDogId == receiverDogId)
                .FirstOrDefault();
            sendRequest.IsRejected = true;
            sendRequest.IsUnderReview = false;

            var receiveRequest = this.receivedRequestsRepository.All()
                .Where(x => x.ReceiverDogId == receiverDogId)
                .FirstOrDefault();
            receiveRequest.IsRejected = true;
            receiveRequest.IsUnderReview = false;

            await this.sentRequestsRepository.SaveChangesAsync();
            await this.receivedRequestsRepository.SaveChangesAsync();
        }
    }
}
