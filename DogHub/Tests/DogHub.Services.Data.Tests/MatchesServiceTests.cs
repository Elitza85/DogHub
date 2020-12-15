namespace DogHub.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models;
    using DogHub.Data.Models.Dogs;
    using DogHub.Data.Models.Matches;
    using Moq;
    using Xunit;

    public class MatchesServiceTests
    {
        [Fact]
        public void GetRandomDogMatchBySenderDogIdReturnsNullForDogMatchOfSameOwner()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<MatchRequestReceived>> matchRequestsReceivedMockRepo = MatchRequestsReceivedMock();
            Mock<IDeletableEntityRepository<MatchRequestSent>> matchRequestsSentMockRepo = MatchRequestsSentMock();

            var service = new MatchesService(
                dogsMockRepo.Object,
                matchRequestsSentMockRepo.Object,
                matchRequestsReceivedMockRepo.Object);

            var breed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };
            var senderDog = new Dog
            {
                Id = 1,
                UserId = "firstUser",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
                BreedId = 1,
                Breed = breed,
                IsSpayedOrNeutered = false,
            };

            var possibleDogMatch = new Dog
            {
                Id = 2,
                UserId = "firstUser",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
                BreedId = 1,
                Breed = breed,
                IsSpayedOrNeutered = false,
            };
            dogsList.Add(senderDog);
            dogsList.Add(possibleDogMatch);

            Assert.Null(service.GetRandomReceiverDog(1));
        }

        [Fact]
        public void GetRandomDogMatchBySenderDogIdReturnsNullForDogMatchThatIsSpayedOrNeutered()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<MatchRequestReceived>> matchRequestsReceivedMockRepo = MatchRequestsReceivedMock();
            Mock<IDeletableEntityRepository<MatchRequestSent>> matchRequestsSentMockRepo = MatchRequestsSentMock();

            var service = new MatchesService(
                dogsMockRepo.Object,
                matchRequestsSentMockRepo.Object,
                matchRequestsReceivedMockRepo.Object);

            var breed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };
            var senderDog = new Dog
            {
                Id = 1,
                UserId = "firstUser",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
                BreedId = 1,
                Breed = breed,
                IsSpayedOrNeutered = false,
            };

            var possibleDogMatch = new Dog
            {
                Id = 2,
                UserId = "secondUser",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
                BreedId = 1,
                Breed = breed,
                IsSpayedOrNeutered = true,
            };
            dogsList.Add(senderDog);
            dogsList.Add(possibleDogMatch);

            Assert.Null(service.GetRandomReceiverDog(1));
        }

        [Fact]
        public void GetRandomDogMatchBySenderDogIdReturnsNullForDogMatchOfSameGender()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<MatchRequestReceived>> matchRequestsReceivedMockRepo = MatchRequestsReceivedMock();
            Mock<IDeletableEntityRepository<MatchRequestSent>> matchRequestsSentMockRepo = MatchRequestsSentMock();

            var service = new MatchesService(
                dogsMockRepo.Object,
                matchRequestsSentMockRepo.Object,
                matchRequestsReceivedMockRepo.Object);

            var breed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };
            var senderDog = new Dog
            {
                Id = 1,
                UserId = "firstUser",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
                BreedId = 1,
                Breed = breed,
                IsSpayedOrNeutered = false,
            };

            var possibleDogMatch = new Dog
            {
                Id = 2,
                UserId = "secondUser",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
                BreedId = 1,
                Breed = breed,
                IsSpayedOrNeutered = false,
            };
            dogsList.Add(senderDog);
            dogsList.Add(possibleDogMatch);

            Assert.Null(service.GetRandomReceiverDog(1));
        }

        [Fact]
        public void GetRandomDogMatchBySenderDogIdReturnsNullForOfDifferentBreed()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<MatchRequestReceived>> matchRequestsReceivedMockRepo = MatchRequestsReceivedMock();
            Mock<IDeletableEntityRepository<MatchRequestSent>> matchRequestsSentMockRepo = MatchRequestsSentMock();

            var service = new MatchesService(
                dogsMockRepo.Object,
                matchRequestsSentMockRepo.Object,
                matchRequestsReceivedMockRepo.Object);

            var breed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };
            var secondBreed = new Breed
            {
                Id = 2,
                Name = "Bulldog",
            };
            var senderDog = new Dog
            {
                Id = 1,
                UserId = "firstUser",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
                BreedId = 1,
                Breed = breed,
                IsSpayedOrNeutered = false,
            };

            var possibleDogMatch = new Dog
            {
                Id = 2,
                UserId = "secondUser",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
                BreedId = 2,
                Breed = secondBreed,
                IsSpayedOrNeutered = false,
            };
            dogsList.Add(senderDog);
            dogsList.Add(possibleDogMatch);

            Assert.Null(service.GetRandomReceiverDog(1));
        }

        [Fact]
        public void GetRandomDogMatchBySenderDogIdReturnsCorrectDogMatch()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<MatchRequestReceived>> matchRequestsReceivedMockRepo = MatchRequestsReceivedMock();
            Mock<IDeletableEntityRepository<MatchRequestSent>> matchRequestsSentMockRepo = MatchRequestsSentMock();

            var service = new MatchesService(
                dogsMockRepo.Object,
                matchRequestsSentMockRepo.Object,
                matchRequestsReceivedMockRepo.Object);

            var breed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };
            var secondBreed = new Breed
            {
                Id = 2,
                Name = "Bulldog",
            };

            var image = new DogImage
            {
                Id = "image",
                Extension = "jpg",
            };
            var senderDog = new Dog
            {
                Id = 1,
                UserId = "firstUser",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
                BreedId = 1,
                Breed = breed,
                IsSpayedOrNeutered = false,
            };

            var firstPossibleDogMatch = new Dog
            {
                Id = 2,
                UserId = "secondUser",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
                BreedId = 2,
                Breed = secondBreed,
                IsSpayedOrNeutered = false,
            };
            var secondPossibleDogMatch = new Dog
            {
                Id = 3,
                UserId = "secondUser",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
                BreedId = 1,
                Breed = breed,
                IsSpayedOrNeutered = false,
            };
            secondPossibleDogMatch.DogImages.Add(image);
            dogsList.Add(senderDog);
            dogsList.Add(firstPossibleDogMatch);
            dogsList.Add(secondPossibleDogMatch);

            var dogMatch = service.GetRandomReceiverDog(1);

            Assert.Equal(3, dogMatch.Id);
        }

        [Fact]
        public void GetSenderDogByIdWorksCorrectly()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<MatchRequestReceived>> matchRequestsReceivedMockRepo = MatchRequestsReceivedMock();
            Mock<IDeletableEntityRepository<MatchRequestSent>> matchRequestsSentMockRepo = MatchRequestsSentMock();

            var service = new MatchesService(
                dogsMockRepo.Object,
                matchRequestsSentMockRepo.Object,
                matchRequestsReceivedMockRepo.Object);

            var breed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };

            var image = new DogImage
            {
                Id = "image",
                Extension = "jpg",
            };
            var firstDog = new Dog
            {
                Id = 1,
                UserId = "firstUser",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
                BreedId = 1,
                Breed = breed,
                IsSpayedOrNeutered = false,
            };

            var secondDog = new Dog
            {
                Id = 2,
                UserId = "secondUser",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
                BreedId = 1,
                Breed = breed,
                IsSpayedOrNeutered = false,
            };
            secondDog.DogImages.Add(image);
            dogsList.Add(firstDog);
            dogsList.Add(secondDog);

            var dog = service.GetSenderDog(2);

            Assert.Equal(2, dog.Id);
        }

        [Fact]
        public void BothDogsBySenderDogIdReturned()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<MatchRequestReceived>> matchRequestsReceivedMockRepo = MatchRequestsReceivedMock();
            Mock<IDeletableEntityRepository<MatchRequestSent>> matchRequestsSentMockRepo = MatchRequestsSentMock();

            var service = new MatchesService(
                dogsMockRepo.Object,
                matchRequestsSentMockRepo.Object,
                matchRequestsReceivedMockRepo.Object);

            var breed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };

            var image = new DogImage
            {
                Id = "image",
                Extension = "jpg",
            };
            var senderDog = new Dog
            {
                Id = 1,
                UserId = "firstUser",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
                BreedId = 1,
                Breed = breed,
                IsSpayedOrNeutered = false,
            };
            senderDog.DogImages.Add(image);

            var firstPossibleDogMatch = new Dog
            {
                Id = 2,
                UserId = "firstUser",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
                BreedId = 1,
                Breed = breed,
                IsSpayedOrNeutered = false,
            };
            var secondPossibleDogMatch = new Dog
            {
                Id = 3,
                UserId = "secondUser",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
                BreedId = 1,
                Breed = breed,
                IsSpayedOrNeutered = true,
            };
            secondPossibleDogMatch.DogImages.Add(image);

            var thirdPossibleDogMatch = new Dog
            {
                Id = 4,
                UserId = "secondUser",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
                BreedId = 1,
                Breed = breed,
                IsSpayedOrNeutered = false,
            };
            thirdPossibleDogMatch.DogImages.Add(image);

            dogsList.Add(senderDog);
            dogsList.Add(firstPossibleDogMatch);
            dogsList.Add(secondPossibleDogMatch);
            dogsList.Add(thirdPossibleDogMatch);

            var dogs = service.GetBothDogs(1);

            Assert.Equal(4, dogs.ReceiverDog.Id);
            Assert.Equal(1, dogs.SenderDog.Id);
        }

        [Fact]
        public async Task MatchRequestSentAddsToDatabase()
        {
            var sentRequestsList = new List<MatchRequestSent>();
            var sentRequestsMockRepo = new Mock<IDeletableEntityRepository<MatchRequestSent>>();
            sentRequestsMockRepo.Setup(x => x.All()).Returns(sentRequestsList.AsQueryable());
            sentRequestsMockRepo.Setup(x => x.AddAsync(It.IsAny<MatchRequestSent>())).Callback(
                (MatchRequestSent request) => sentRequestsList.Add(request));

            Mock<IDeletableEntityRepository<MatchRequestReceived>> matchRequestsReceivedMockRepo = MatchRequestsReceivedMock();
            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();

            var service = new MatchesService(
                dogsMockRepo.Object,
                sentRequestsMockRepo.Object,
                matchRequestsReceivedMockRepo.Object);


            await service.SendMatchRequest(1, 2, "userId");

            Assert.Equal(1, sentRequestsList.Count());
            Assert.Equal(1, sentRequestsList.Select(x => x.SenderDogId).First());
            Assert.Equal(2, sentRequestsList.Select(x => x.ReceiverDogId).First());
            Assert.Equal("userId", sentRequestsList.Select(x => x.UserId).First());
            Assert.True(sentRequestsList.Select(x => x.IsUnderReview).First());
        }

        [Fact]
        public async Task MatchRequestReceivedAddsToDatabase()
        {
            var receivedRequestsList = new List<MatchRequestReceived>();
            var matchRequestsReceivedMockRepo = new Mock<IDeletableEntityRepository<MatchRequestReceived>>();
            matchRequestsReceivedMockRepo.Setup(x => x.All()).Returns(receivedRequestsList.AsQueryable());
            matchRequestsReceivedMockRepo.Setup(x => x.AddAsync(It.IsAny<MatchRequestReceived>())).Callback(
                (MatchRequestReceived request) => receivedRequestsList.Add(request));

            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<MatchRequestSent>> sentRequestsMockRepo = MatchRequestsSentMock();

            var service = new MatchesService(
                dogsMockRepo.Object,
                sentRequestsMockRepo.Object,
                matchRequestsReceivedMockRepo.Object);

            var receiverDog = new Dog
            {
                UserId = "userId",
                Id = 2,
            };
            dogsList.Add(receiverDog);

            await service.ReceiveMatchRequest(1, 2);

            Assert.Equal(1, receivedRequestsList.Count());
            Assert.Equal(1, receivedRequestsList.Select(x => x.SenderDogId).First());
            Assert.Equal(2, receivedRequestsList.Select(x => x.ReceiverDogId).First());
            Assert.Equal("userId", receivedRequestsList.Select(x => x.UserId).First());
            Assert.True(receivedRequestsList.Select(x => x.IsUnderReview).First());
        }

        [Fact]
        public async Task ApprovalOfMatchRequestChangesTheStatusOfSentAndReceivedMatchRequests()
        {
            var sentRequestsList = new List<MatchRequestSent>();
            var sentRequestsMockRepo = new Mock<IDeletableEntityRepository<MatchRequestSent>>();
            sentRequestsMockRepo.Setup(x => x.All()).Returns(sentRequestsList.AsQueryable());
            sentRequestsMockRepo.Setup(x => x.AddAsync(It.IsAny<MatchRequestSent>())).Callback(
                (MatchRequestSent request) => sentRequestsList.Add(request));

            var receivedRequestsList = new List<MatchRequestReceived>();
            var matchRequestsReceivedMockRepo = new Mock<IDeletableEntityRepository<MatchRequestReceived>>();
            matchRequestsReceivedMockRepo.Setup(x => x.All()).Returns(receivedRequestsList.AsQueryable());
            matchRequestsReceivedMockRepo.Setup(x => x.AddAsync(It.IsAny<MatchRequestReceived>())).Callback(
                (MatchRequestReceived request) => receivedRequestsList.Add(request));

            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();

            var service = new MatchesService(
                dogsMockRepo.Object,
                sentRequestsMockRepo.Object,
                matchRequestsReceivedMockRepo.Object);

            var sentRequest = new MatchRequestSent
            {
                Id = 1,
                IsApproved = false,
                IsRejected = false,
                IsUnderReview = true,
                SenderDogId = 1,
                ReceiverDogId = 2,
            };
            sentRequestsList.Add(sentRequest);

            var receivedRequest = new MatchRequestReceived
            {
                Id = 1,
                IsApproved = false,
                IsRejected = false,
                IsUnderReview = true,
                SenderDogId = 1,
                ReceiverDogId = 2,
            };
            receivedRequestsList.Add(receivedRequest);

            await service.ApproveRequest(2);

            Assert.False(sentRequestsList.Select(x => x.IsUnderReview).First());
            Assert.True(sentRequestsList.Select(x => x.IsApproved).First());
            Assert.False(receivedRequestsList.Select(x => x.IsUnderReview).First());
            Assert.True(receivedRequestsList.Select(x => x.IsApproved).First());
        }

        [Fact]
        public async Task RejectingMatchRequestChangesTheStatusOfSentAndReceivedMatchRequests()
        {
            var sentRequestsList = new List<MatchRequestSent>();
            var sentRequestsMockRepo = new Mock<IDeletableEntityRepository<MatchRequestSent>>();
            sentRequestsMockRepo.Setup(x => x.All()).Returns(sentRequestsList.AsQueryable());
            sentRequestsMockRepo.Setup(x => x.AddAsync(It.IsAny<MatchRequestSent>())).Callback(
                (MatchRequestSent request) => sentRequestsList.Add(request));

            var receivedRequestsList = new List<MatchRequestReceived>();
            var matchRequestsReceivedMockRepo = new Mock<IDeletableEntityRepository<MatchRequestReceived>>();
            matchRequestsReceivedMockRepo.Setup(x => x.All()).Returns(receivedRequestsList.AsQueryable());
            matchRequestsReceivedMockRepo.Setup(x => x.AddAsync(It.IsAny<MatchRequestReceived>())).Callback(
                (MatchRequestReceived request) => receivedRequestsList.Add(request));

            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();

            var service = new MatchesService(
                dogsMockRepo.Object,
                sentRequestsMockRepo.Object,
                matchRequestsReceivedMockRepo.Object);

            var sentRequest = new MatchRequestSent
            {
                Id = 1,
                IsApproved = false,
                IsRejected = false,
                IsUnderReview = true,
                SenderDogId = 1,
                ReceiverDogId = 2,
            };
            sentRequestsList.Add(sentRequest);

            var receivedRequest = new MatchRequestReceived
            {
                Id = 1,
                IsApproved = false,
                IsRejected = false,
                IsUnderReview = true,
                SenderDogId = 1,
                ReceiverDogId = 2,
            };
            receivedRequestsList.Add(receivedRequest);

            await service.RejectRequest(2);

            Assert.False(sentRequestsList.Select(x => x.IsUnderReview).First());
            Assert.True(sentRequestsList.Select(x => x.IsRejected).First());
            Assert.False(receivedRequestsList.Select(x => x.IsUnderReview).First());
            Assert.True(receivedRequestsList.Select(x => x.IsRejected).First());
        }

        private static Mock<IDeletableEntityRepository<MatchRequestReceived>> MatchRequestsReceivedMock()
        {
            var receivedRequestsList = new List<MatchRequestReceived>();
            var receivedRequestsMockRepo = new Mock<IDeletableEntityRepository<MatchRequestReceived>>();
            receivedRequestsMockRepo.Setup(x => x.All()).Returns(receivedRequestsList.AsQueryable());
            receivedRequestsMockRepo.Setup(x => x.AddAsync(It.IsAny<MatchRequestReceived>())).Callback(
                (MatchRequestReceived request) => receivedRequestsList.Add(request));
            return receivedRequestsMockRepo;
        }

        private static Mock<IDeletableEntityRepository<MatchRequestSent>> MatchRequestsSentMock()
        {
            var sentRequestsList = new List<MatchRequestSent>();
            var sentRequestsMockRepo = new Mock<IDeletableEntityRepository<MatchRequestSent>>();
            sentRequestsMockRepo.Setup(x => x.All()).Returns(sentRequestsList.AsQueryable());
            sentRequestsMockRepo.Setup(x => x.AddAsync(It.IsAny<MatchRequestSent>())).Callback(
                (MatchRequestSent request) => sentRequestsList.Add(request));
            return sentRequestsMockRepo;
        }

        private static Mock<IDeletableEntityRepository<Dog>> DogsMock()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));
            return dogsMockRepo;
        }
    }
}
