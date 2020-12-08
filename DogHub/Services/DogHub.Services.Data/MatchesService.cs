namespace DogHub.Services.Data
{
    using System;
    using System.Linq;

    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models;
    using DogHub.Web.ViewModels.DogMatches;

    public class MatchesService : IMatchesService
    {
        private readonly IDeletableEntityRepository<Dog> dogsRepository;

        public MatchesService(IDeletableEntityRepository<Dog> dogsRepository)
        {
            this.dogsRepository = dogsRepository;
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
                && x.BreedId == senderDog.BreedId)
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
                })
                .FirstOrDefault();

            return senderDog;
        }
    }
}
