namespace DogHub.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models;
    using DogHub.Data.Models.CommonForms;
    using DogHub.Data.Models.Competitions;
    using DogHub.Data.Models.Dogs;
    using DogHub.Data.Models.EvaluationForms;
    using DogHub.Data.Models.Matches;
    using DogHub.Web.ViewModels.Dashboards;
    using DogHub.Web.ViewModels.Dogs;
    using Moq;
    using Xunit;

    public class OwnerDashboardsServiceTests
    {
        //[Fact]
        //public void GivenUserIdReturnsAllDogsOwnedByUser()
        //{
        //    var dogsList = new List<Dog>();
        //    var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
        //    dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
        //    dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
        //        (Dog dog) => dogsList.Add(dog));

        //    Mock<IDeletableEntityRepository<MatchRequestReceived>> receivedRequestsMockRepo = MatchRequestsReceivedMock();
        //    Mock<IDeletableEntityRepository<MatchRequestSent>> sentRequestsMockRepo = MatchRequestsSentMock();
        //    Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JudgeAppFormsMock();
        //    Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
        //    Mock<IDeletableEntityRepository<EyesColor>> eyesColorsMockRepo = EyesColorsMock();
        //    Mock<IDeletableEntityRepository<DogColor>> dogsColorMockRepo = DogColorsMock();

        //    var judgeSrvice = new JudgesService(
        //        appFormsMockRepo.Object,
        //        competitionsMockRepo.Object);

        //    var service = new OwnerDashboardsService(
        //        dogsMockRepo.Object,
        //        dogsColorMockRepo.Object,
        //        eyesColorsMockRepo.Object,
        //        competitionsMockRepo.Object,
        //        appFormsMockRepo.Object,
        //        judgeSrvice,
        //        sentRequestsMockRepo.Object,
        //        receivedRequestsMockRepo.Object);

        //    var image = new DogImage
        //    {
        //        Id = "imageId",
        //        Extension = "jpg",
        //    };
        //    var breed = new Breed
        //    {
        //        Id = 1,
        //        Name = "Poodle",
        //    };
        //    var color = new DogColor
        //    {
        //        Id = 1,
        //        ColorName = "Black",
        //    };

        //    var firstDog = new Dog
        //    {
        //        UserId = "firstUser",
        //        Id = 1,
        //        Name = "Test1",
        //        Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
        //        BreedId = 1,
        //        Breed = breed,
        //        DogColorId = 1,
        //        DogColor = color,
        //        Sellable = true,
        //    };
        //    firstDog.DogImages.Add(image);
        //    dogsList.Add(firstDog);

        //    var secondDog = new Dog
        //    {
        //        UserId = "secondUser",
        //        Id = 2,
        //        Name = "Test2",
        //        Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
        //        BreedId = 1,
        //        Breed = breed,
        //        DogColorId = 1,
        //        DogColor = color,
        //        Sellable = false,
        //    };
        //    secondDog.DogImages.Add(image);
        //    dogsList.Add(secondDog);

        //    var data = service.GetAllDogsOwned<DogDataInCatalogueViewModel>("firstUser").ToList();

        //    Assert.Equal(1, data.Count());
        //    Assert.Equal(1, data.Select(x => x.Id).First());
        //}

        //[Fact]
        //public void GivenDogIdReturnsThatDog()
        //{
        //    var dogsList = new List<Dog>();
        //    var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
        //    dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
        //    dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
        //        (Dog dog) => dogsList.Add(dog));

        //    Mock<IDeletableEntityRepository<MatchRequestReceived>> receivedRequestsMockRepo = MatchRequestsReceivedMock();
        //    Mock<IDeletableEntityRepository<MatchRequestSent>> sentRequestsMockRepo = MatchRequestsSentMock();
        //    Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JudgeAppFormsMock();
        //    Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
        //    Mock<IDeletableEntityRepository<EyesColor>> eyesColorsMockRepo = EyesColorsMock();
        //    Mock<IDeletableEntityRepository<DogColor>> dogsColorMockRepo = DogColorsMock();

        //    var judgeSrvice = new JudgesService(
        //        appFormsMockRepo.Object,
        //        competitionsMockRepo.Object);

        //    var service = new OwnerDashboardsService(
        //        dogsMockRepo.Object,
        //        dogsColorMockRepo.Object,
        //        eyesColorsMockRepo.Object,
        //        competitionsMockRepo.Object,
        //        appFormsMockRepo.Object,
        //        judgeSrvice,
        //        sentRequestsMockRepo.Object,
        //        receivedRequestsMockRepo.Object);

        //    var image = new DogImage
        //    {
        //        Id = "imageId",
        //        Extension = "jpg",
        //    };
        //    var breed = new Breed
        //    {
        //        Id = 1,
        //        Name = "Poodle",
        //    };
        //    var color = new DogColor
        //    {
        //        Id = 1,
        //        ColorName = "Black",
        //    };
        //    var eyesColor = new EyesColor
        //    {
        //        Id = 1,
        //        EyesColorName = "Brown",
        //    };

        //    var firstDog = new Dog
        //    {
        //        UserId = "firstUser",
        //        Id = 1,
        //        Name = "Test1",
        //        Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
        //        BreedId = 1,
        //        Breed = breed,
        //        DogColorId = 1,
        //        DogColor = color,
        //        Sellable = true,
        //        EyesColorId = 1,
        //        EyesColor = eyesColor,
        //        DogVideoUrl = "videoUrl",
        //    };
        //    firstDog.DogImages.Add(image);
        //    dogsList.Add(firstDog);

        //    var secondDog = new Dog
        //    {
        //        UserId = "secondUser",
        //        Id = 2,
        //        Name = "Test2",
        //        Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
        //        BreedId = 1,
        //        Breed = breed,
        //        DogColorId = 1,
        //        DogColor = color,
        //        Sellable = false,
        //        EyesColorId = 1,
        //        EyesColor = eyesColor,
        //        DogVideoUrl = "videoUrl",
        //    };
        //    secondDog.DogImages.Add(image);
        //    dogsList.Add(secondDog);

        //    var data = service.GetById<EditDogDataInputModel>(2);

        //    Assert.Equal(2, data.Id);
        //}

        [Fact]
        public async Task UpdatingDogNameInDatabaseWorksCorrectly()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<MatchRequestReceived>> receivedRequestsMockRepo = MatchRequestsReceivedMock();
            Mock<IDeletableEntityRepository<MatchRequestSent>> sentRequestsMockRepo = MatchRequestsSentMock();
            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JudgeAppFormsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
            Mock<IDeletableEntityRepository<EyesColor>> eyesColorsMockRepo = EyesColorsMock();
            Mock<IDeletableEntityRepository<DogColor>> dogsColorMockRepo = DogColorsMock();

            var judgeSrvice = new JudgesService(
                appFormsMockRepo.Object,
                competitionsMockRepo.Object);

            var service = new OwnerDashboardsService(
                dogsMockRepo.Object,
                dogsColorMockRepo.Object,
                eyesColorsMockRepo.Object,
                competitionsMockRepo.Object,
                appFormsMockRepo.Object,
                judgeSrvice,
                sentRequestsMockRepo.Object,
                receivedRequestsMockRepo.Object);

            var breed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };
            var color = new DogColor
            {
                Id = 1,
                ColorName = "Black",
            };
            var eyesColor = new EyesColor
            {
                Id = 1,
                EyesColorName = "Brown",
            };

            var dog = new Dog
            {
                UserId = "firstUser",
                Id = 1,
                Name = "Test1",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
                BreedId = 1,
                Breed = breed,
                DogColorId = 1,
                DogColor = color,
                Sellable = true,
                EyesColorId = 1,
                EyesColor = eyesColor,
                DogVideoUrl = "https://www.youtube.com/watch?v=gpyB54lSpYg",
            };
            dogsList.Add(dog);

            var input = new EditDogDataInputModel
            {
                DogName = "NewName",
                DogVideoUrl = "https://www.youtube.com/watch?v=gpyB54lSpYg",
            };

            await service.UpdateAsync(1, input);

            Assert.Equal("NewName", dogsList.First().Name);
        }

        [Fact]
        public async Task UpdatingDogGenderInDatabaseWorksCorrectly()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<MatchRequestReceived>> receivedRequestsMockRepo = MatchRequestsReceivedMock();
            Mock<IDeletableEntityRepository<MatchRequestSent>> sentRequestsMockRepo = MatchRequestsSentMock();
            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JudgeAppFormsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
            Mock<IDeletableEntityRepository<EyesColor>> eyesColorsMockRepo = EyesColorsMock();
            Mock<IDeletableEntityRepository<DogColor>> dogsColorMockRepo = DogColorsMock();

            var judgeSrvice = new JudgesService(
                appFormsMockRepo.Object,
                competitionsMockRepo.Object);

            var service = new OwnerDashboardsService(
                dogsMockRepo.Object,
                dogsColorMockRepo.Object,
                eyesColorsMockRepo.Object,
                competitionsMockRepo.Object,
                appFormsMockRepo.Object,
                judgeSrvice,
                sentRequestsMockRepo.Object,
                receivedRequestsMockRepo.Object);

            var breed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };
            var color = new DogColor
            {
                Id = 1,
                ColorName = "Black",
            };
            var eyesColor = new EyesColor
            {
                Id = 1,
                EyesColorName = "Brown",
            };

            var dog = new Dog
            {
                UserId = "firstUser",
                Id = 1,
                Name = "Test1",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
                BreedId = 1,
                Breed = breed,
                DogColorId = 1,
                DogColor = color,
                Sellable = true,
                EyesColorId = 1,
                EyesColor = eyesColor,
                DogVideoUrl = "https://www.youtube.com/watch?v=gpyB54lSpYg",
            };
            dogsList.Add(dog);

            var input = new EditDogDataInputModel
            {
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
                DogVideoUrl = "https://www.youtube.com/watch?v=gpyB54lSpYg",
            };

            await service.UpdateAsync(1, input);

            Assert.Equal("Female", dogsList.First().Gender.ToString());
        }

        [Fact]
        public async Task UpdatingDogBreedInDatabaseWorksCorrectly()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<MatchRequestReceived>> receivedRequestsMockRepo = MatchRequestsReceivedMock();
            Mock<IDeletableEntityRepository<MatchRequestSent>> sentRequestsMockRepo = MatchRequestsSentMock();
            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JudgeAppFormsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
            Mock<IDeletableEntityRepository<EyesColor>> eyesColorsMockRepo = EyesColorsMock();
            Mock<IDeletableEntityRepository<DogColor>> dogsColorMockRepo = DogColorsMock();

            var judgeSrvice = new JudgesService(
                appFormsMockRepo.Object,
                competitionsMockRepo.Object);

            var service = new OwnerDashboardsService(
                dogsMockRepo.Object,
                dogsColorMockRepo.Object,
                eyesColorsMockRepo.Object,
                competitionsMockRepo.Object,
                appFormsMockRepo.Object,
                judgeSrvice,
                sentRequestsMockRepo.Object,
                receivedRequestsMockRepo.Object);

            var breed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };
            var color = new DogColor
            {
                Id = 1,
                ColorName = "Black",
            };
            var eyesColor = new EyesColor
            {
                Id = 1,
                EyesColorName = "Brown",
            };

            var dog = new Dog
            {
                UserId = "firstUser",
                Id = 1,
                Name = "Test1",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
                BreedId = 1,
                Breed = breed,
                DogColorId = 1,
                DogColor = color,
                Sellable = true,
                EyesColorId = 1,
                EyesColor = eyesColor,
                DogVideoUrl = "https://www.youtube.com/watch?v=gpyB54lSpYg",
            };
            dogsList.Add(dog);

            var newBreed = new Breed
            {
                Id = 2,
                Name = "Bulldog",
            };

            var input = new EditDogDataInputModel
            {
                BreedId = 2,
                DogVideoUrl = "https://www.youtube.com/watch?v=gpyB54lSpYg",
            };

            await service.UpdateAsync(1, input);

            Assert.Equal(2, dogsList.First().BreedId);
        }

        [Fact]
        public async Task UpdatingDogColorAddsTheColorToDatabaseIfItDoesNotExist()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            var dogColorsList = new List<DogColor>();
            var dogColorsMockRepo = new Mock<IDeletableEntityRepository<DogColor>>();
            dogColorsMockRepo.Setup(x => x.All()).Returns(dogColorsList.AsQueryable());
            dogColorsMockRepo.Setup(x => x.AddAsync(It.IsAny<DogColor>())).Callback(
                (DogColor dogColor) => dogColorsList.Add(dogColor));

            Mock<IDeletableEntityRepository<MatchRequestReceived>> receivedRequestsMockRepo = MatchRequestsReceivedMock();
            Mock<IDeletableEntityRepository<MatchRequestSent>> sentRequestsMockRepo = MatchRequestsSentMock();
            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JudgeAppFormsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
            Mock<IDeletableEntityRepository<EyesColor>> eyesColorsMockRepo = EyesColorsMock();

            var judgeSrvice = new JudgesService(
                appFormsMockRepo.Object,
                competitionsMockRepo.Object);

            var service = new OwnerDashboardsService(
                dogsMockRepo.Object,
                dogColorsMockRepo.Object,
                eyesColorsMockRepo.Object,
                competitionsMockRepo.Object,
                appFormsMockRepo.Object,
                judgeSrvice,
                sentRequestsMockRepo.Object,
                receivedRequestsMockRepo.Object);

            var breed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };
            var color = new DogColor
            {
                Id = 1,
                ColorName = "Black",
            };
            dogColorsList.Add(color);
            var eyesColor = new EyesColor
            {
                Id = 1,
                EyesColorName = "Brown",
            };

            var dog = new Dog
            {
                UserId = "firstUser",
                Id = 1,
                Name = "Test1",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
                BreedId = 1,
                Breed = breed,
                DogColorId = 1,
                DogColor = color,
                Sellable = true,
                EyesColorId = 1,
                EyesColor = eyesColor,
                DogVideoUrl = "https://www.youtube.com/watch?v=gpyB54lSpYg",
            };
            dogsList.Add(dog);

            var input = new EditDogDataInputModel
            {
                DogColor = "White",
                DogVideoUrl = "https://www.youtube.com/watch?v=gpyB54lSpYg",
            };

            await service.UpdateAsync(1, input);

            Assert.Equal(0, dogsList.First().DogColorId);
            Assert.Equal(2, dogColorsList.Count());
            Assert.Equal("White", dogColorsList.Last().ColorName);
        }

        [Fact]
        public async Task UpdatingDogEyesColorAddsTheColorToDatabaseIfItDoesNotExist()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            var eyesColorsList = new List<EyesColor>();
            var eyesColorsMockRepo = new Mock<IDeletableEntityRepository<EyesColor>>();
            eyesColorsMockRepo.Setup(x => x.All()).Returns(eyesColorsList.AsQueryable());
            eyesColorsMockRepo.Setup(x => x.AddAsync(It.IsAny<EyesColor>())).Callback(
                (EyesColor dogEyesColor) => eyesColorsList.Add(dogEyesColor));

            Mock<IDeletableEntityRepository<MatchRequestReceived>> receivedRequestsMockRepo = MatchRequestsReceivedMock();
            Mock<IDeletableEntityRepository<MatchRequestSent>> sentRequestsMockRepo = MatchRequestsSentMock();
            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JudgeAppFormsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
            Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();

            var judgeSrvice = new JudgesService(
                appFormsMockRepo.Object,
                competitionsMockRepo.Object);

            var service = new OwnerDashboardsService(
                dogsMockRepo.Object,
                dogColorsMockRepo.Object,
                eyesColorsMockRepo.Object,
                competitionsMockRepo.Object,
                appFormsMockRepo.Object,
                judgeSrvice,
                sentRequestsMockRepo.Object,
                receivedRequestsMockRepo.Object);

            var breed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };
            var color = new DogColor
            {
                Id = 1,
                ColorName = "Black",
            };
            var eyesColor = new EyesColor
            {
                Id = 1,
                EyesColorName = "Brown",
            };

            var dog = new Dog
            {
                UserId = "firstUser",
                Id = 1,
                Name = "Test1",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
                BreedId = 1,
                Breed = breed,
                DogColorId = 1,
                DogColor = color,
                Sellable = true,
                EyesColorId = 1,
                EyesColor = eyesColor,
                DogVideoUrl = "https://www.youtube.com/watch?v=gpyB54lSpYg",
            };
            dogsList.Add(dog);

            var input = new EditDogDataInputModel
            {
                EyesColor = "Black",
                DogVideoUrl = "https://www.youtube.com/watch?v=gpyB54lSpYg",
            };

            await service.UpdateAsync(1, input);

            Assert.Equal(0, dogsList.First().EyesColorId);
            Assert.Equal(1, eyesColorsList.Count());
            Assert.Equal("Black", eyesColorsList.First().EyesColorName);
        }

        [Fact]
        public async Task UpdatingSellablePropertyofDogUpdatesDatabase()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<MatchRequestReceived>> receivedRequestsMockRepo = MatchRequestsReceivedMock();
            Mock<IDeletableEntityRepository<MatchRequestSent>> sentRequestsMockRepo = MatchRequestsSentMock();
            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JudgeAppFormsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
            Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();
            Mock<IDeletableEntityRepository<EyesColor>> eyesColorsMockRepo = EyesColorsMock();

            var judgeSrvice = new JudgesService(
                appFormsMockRepo.Object,
                competitionsMockRepo.Object);

            var service = new OwnerDashboardsService(
                dogsMockRepo.Object,
                dogColorsMockRepo.Object,
                eyesColorsMockRepo.Object,
                competitionsMockRepo.Object,
                appFormsMockRepo.Object,
                judgeSrvice,
                sentRequestsMockRepo.Object,
                receivedRequestsMockRepo.Object);

            var breed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };
            var color = new DogColor
            {
                Id = 1,
                ColorName = "Black",
            };
            var eyesColor = new EyesColor
            {
                Id = 1,
                EyesColorName = "Brown",
            };

            var dog = new Dog
            {
                UserId = "firstUser",
                Id = 1,
                Name = "Test1",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
                BreedId = 1,
                Breed = breed,
                DogColorId = 1,
                DogColor = color,
                Sellable = true,
                EyesColorId = 1,
                EyesColor = eyesColor,
                DogVideoUrl = "https://www.youtube.com/watch?v=gpyB54lSpYg",
            };
            dogsList.Add(dog);

            var input = new EditDogDataInputModel
            {
                Sellable = false,
                DogVideoUrl = "https://www.youtube.com/watch?v=gpyB54lSpYg",
            };

            await service.UpdateAsync(1, input);

            Assert.False(dogsList.First().Sellable);
        }

        [Fact]
        public void InvalidVideoUrlThrowsError()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<MatchRequestReceived>> receivedRequestsMockRepo = MatchRequestsReceivedMock();
            Mock<IDeletableEntityRepository<MatchRequestSent>> sentRequestsMockRepo = MatchRequestsSentMock();
            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JudgeAppFormsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
            Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();
            Mock<IDeletableEntityRepository<EyesColor>> eyesColorsMockRepo = EyesColorsMock();

            var judgeSrvice = new JudgesService(
                appFormsMockRepo.Object,
                competitionsMockRepo.Object);

            var service = new OwnerDashboardsService(
                dogsMockRepo.Object,
                dogColorsMockRepo.Object,
                eyesColorsMockRepo.Object,
                competitionsMockRepo.Object,
                appFormsMockRepo.Object,
                judgeSrvice,
                sentRequestsMockRepo.Object,
                receivedRequestsMockRepo.Object);

            var breed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };
            var color = new DogColor
            {
                Id = 1,
                ColorName = "Black",
            };
            var eyesColor = new EyesColor
            {
                Id = 1,
                EyesColorName = "Brown",
            };

            var dog = new Dog
            {
                UserId = "firstUser",
                Id = 1,
                Name = "Test1",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
                BreedId = 1,
                Breed = breed,
                DogColorId = 1,
                DogColor = color,
                Sellable = true,
                EyesColorId = 1,
                EyesColor = eyesColor,
                DogVideoUrl = "https://www.youtube.com/watch?v=gpyB54lSpYg",
            };
            dogsList.Add(dog);

            var input = new EditDogDataInputModel
            {
                DogVideoUrl = "https://www.youtu.com/watch?v=gpyB54lSpYg",
            };

            var data = service.UpdateAsync(1, input);
            Assert.Equal("Video should be from YouTube", data.Exception.InnerException.Message);
        }

        [Fact]
        public async Task ValidVideoUrlUpdatesDogData()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<MatchRequestReceived>> receivedRequestsMockRepo = MatchRequestsReceivedMock();
            Mock<IDeletableEntityRepository<MatchRequestSent>> sentRequestsMockRepo = MatchRequestsSentMock();
            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JudgeAppFormsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
            Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();
            Mock<IDeletableEntityRepository<EyesColor>> eyesColorsMockRepo = EyesColorsMock();

            var judgeSrvice = new JudgesService(
                appFormsMockRepo.Object,
                competitionsMockRepo.Object);

            var service = new OwnerDashboardsService(
                dogsMockRepo.Object,
                dogColorsMockRepo.Object,
                eyesColorsMockRepo.Object,
                competitionsMockRepo.Object,
                appFormsMockRepo.Object,
                judgeSrvice,
                sentRequestsMockRepo.Object,
                receivedRequestsMockRepo.Object);

            var breed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };
            var color = new DogColor
            {
                Id = 1,
                ColorName = "Black",
            };
            var eyesColor = new EyesColor
            {
                Id = 1,
                EyesColorName = "Brown",
            };

            var dog = new Dog
            {
                UserId = "firstUser",
                Id = 1,
                Name = "Test1",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
                BreedId = 1,
                Breed = breed,
                DogColorId = 1,
                DogColor = color,
                Sellable = true,
                EyesColorId = 1,
                EyesColor = eyesColor,
                DogVideoUrl = "https://www.youtube.com/watch?v=gpyB54lSpYg",
            };
            dogsList.Add(dog);

            var input = new EditDogDataInputModel
            {
                DogVideoUrl = "https://www.youtube.com/watch?v=xSwBb6Ksrew",
            };

            await service.UpdateAsync(1, input);
            Assert.Equal("https://www.youtube.com/watch?v=xSwBb6Ksrew", dogsList.First().DogVideoUrl);
        }

        [Fact]
        public async Task DogByIdIsRemovedFromDatabase()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.Delete(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Remove(dog));
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<MatchRequestReceived>> receivedRequestsMockRepo = MatchRequestsReceivedMock();
            Mock<IDeletableEntityRepository<MatchRequestSent>> sentRequestsMockRepo = MatchRequestsSentMock();
            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JudgeAppFormsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
            Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();
            Mock<IDeletableEntityRepository<EyesColor>> eyesColorsMockRepo = EyesColorsMock();

            var judgeSrvice = new JudgesService(
                appFormsMockRepo.Object,
                competitionsMockRepo.Object);

            var service = new OwnerDashboardsService(
                dogsMockRepo.Object,
                dogColorsMockRepo.Object,
                eyesColorsMockRepo.Object,
                competitionsMockRepo.Object,
                appFormsMockRepo.Object,
                judgeSrvice,
                sentRequestsMockRepo.Object,
                receivedRequestsMockRepo.Object);

            var breed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };
            var color = new DogColor
            {
                Id = 1,
                ColorName = "Black",
            };
            var eyesColor = new EyesColor
            {
                Id = 1,
                EyesColorName = "Brown",
            };

            var firstDog = new Dog
            {
                UserId = "firstUser",
                Id = 1,
                Name = "Test1",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
                BreedId = 1,
                Breed = breed,
                DogColorId = 1,
                DogColor = color,
                Sellable = true,
                EyesColorId = 1,
                EyesColor = eyesColor,
                DogVideoUrl = "https://www.youtube.com/watch?v=gpyB54lSpYg",
            };
            var secondDog = new Dog
            {
                UserId = "firstUser",
                Id = 2,
                Name = "Test2",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
                BreedId = 1,
                Breed = breed,
                DogColorId = 1,
                DogColor = color,
                Sellable = false,
                EyesColorId = 1,
                EyesColor = eyesColor,
                DogVideoUrl = "https://www.youtube.com/watch?v=gpyB54lSpYg",
            };
            dogsList.Add(firstDog);
            dogsList.Add(secondDog);

            await service.DeleteAsync(2);
            Assert.Equal(1, dogsList.Count());
            Assert.Equal("Test1", dogsList.First().Name);
        }

        [Fact]
        public void GivenUserIdReturnsOnlyCompetitionsThatHisDogsParticpatedIn()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.Delete(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Remove(dog));
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            Mock<IDeletableEntityRepository<MatchRequestReceived>> receivedRequestsMockRepo = MatchRequestsReceivedMock();
            Mock<IDeletableEntityRepository<MatchRequestSent>> sentRequestsMockRepo = MatchRequestsSentMock();
            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JudgeAppFormsMock();
            Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();
            Mock<IDeletableEntityRepository<EyesColor>> eyesColorsMockRepo = EyesColorsMock();

            var judgeSrvice = new JudgesService(
                appFormsMockRepo.Object,
                competitionsMockRepo.Object);

            var service = new OwnerDashboardsService(
                dogsMockRepo.Object,
                dogColorsMockRepo.Object,
                eyesColorsMockRepo.Object,
                competitionsMockRepo.Object,
                appFormsMockRepo.Object,
                judgeSrvice,
                sentRequestsMockRepo.Object,
                receivedRequestsMockRepo.Object);

            var competitionImage = new CompetitionImage
            {
                Id = "imageId",
                Extension = "jpg",
            };

            var firstCompetition = new Competition
            {
                Id = 1,
                Name = "Competition1",
                CompetitionImage = competitionImage,
            };
            var secondCompetition = new Competition
            {
                Id = 2,
                Name = "Competition2",
                CompetitionImage = competitionImage,
            };
            var thirdCompetition = new Competition
            {
                Id = 3,
                Name = "Competition3",
                CompetitionImage = competitionImage,
            };

            var firstDog = new Dog
            {
                UserId = "firstUser",
                Id = 1,
                Name = "TestDog1",
            };
            var secondDog = new Dog
            {
                UserId = "secondUser",
                Id = 2,
                Name = "TestDog2",
            };
            var thirdDog = new Dog
            {
                UserId = "secondUser",
                Id = 3,
                Name = "TestDog3",
            };
            var fourthDog = new Dog
            {
                UserId = "secondUser",
                Id = 4,
                Name = "TestDog4",
            };
            firstCompetition.DogsCompetitions.Add(new DogCompetition
            {
                DogId = 1,
                Dog = firstDog,
                CompetitionId = 1,
                Competition = firstCompetition,
            });
            firstCompetition.DogsCompetitions.Add(new DogCompetition
            {
                DogId = 2,
                Dog = secondDog,
                CompetitionId = 1,
                Competition = firstCompetition,
            });
            firstCompetition.DogsCompetitions.Add(new DogCompetition
            {
                DogId = 3,
                Dog = thirdDog,
                CompetitionId = 1,
                Competition = firstCompetition,
            });
            secondCompetition.DogsCompetitions.Add(new DogCompetition
            {
                CompetitionId = 2,
                Competition = secondCompetition,
                DogId = 1,
                Dog = firstDog,
            });
            secondCompetition.DogsCompetitions.Add(new DogCompetition
            {
                CompetitionId = 2,
                Competition = secondCompetition,
                DogId = 4,
                Dog = fourthDog,
            });
            thirdCompetition.DogsCompetitions.Add(new DogCompetition
            {
                CompetitionId = 3,
                Competition = thirdCompetition,
                DogId = 1,
                Dog = firstDog,
            });
            competitionsList.Add(firstCompetition);
            competitionsList.Add(secondCompetition);
            competitionsList.Add(thirdCompetition);

            var data = service.DogsInCompetitions("secondUser");

            Assert.Equal(2, data.Count());
            Assert.Equal("Competition1", data.First().CompetitionName);
            Assert.Equal("Competition2", data.Last().CompetitionName);
            Assert.Equal(2, data.First().AllDogsParticipants.Count());
            Assert.Equal("TestDog2", data.First().AllDogsParticipants.First().Name);
            Assert.Equal("TestDog3", data.First().AllDogsParticipants.Last().Name);
        }

        [Fact]
        public void GivenUserIdReturnsOnlyPastCompetitionsThatHisDogsParticpatedIn()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.Delete(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Remove(dog));
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            Mock<IDeletableEntityRepository<MatchRequestReceived>> receivedRequestsMockRepo = MatchRequestsReceivedMock();
            Mock<IDeletableEntityRepository<MatchRequestSent>> sentRequestsMockRepo = MatchRequestsSentMock();
            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JudgeAppFormsMock();
            Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();
            Mock<IDeletableEntityRepository<EyesColor>> eyesColorsMockRepo = EyesColorsMock();

            var judgeSrvice = new JudgesService(
                appFormsMockRepo.Object,
                competitionsMockRepo.Object);

            var service = new OwnerDashboardsService(
                dogsMockRepo.Object,
                dogColorsMockRepo.Object,
                eyesColorsMockRepo.Object,
                competitionsMockRepo.Object,
                appFormsMockRepo.Object,
                judgeSrvice,
                sentRequestsMockRepo.Object,
                receivedRequestsMockRepo.Object);

            var competitionImage = new CompetitionImage
            {
                Id = "imageId",
                Extension = "jpg",
            };

            var firstCompetition = new Competition
            {
                Id = 1,
                Name = "Competition1",
                CompetitionEnd = DateTime.UtcNow,
                CompetitionImage = competitionImage,
            };
            var secondCompetition = new Competition
            {
                Id = 2,
                Name = "Competition2",
                CompetitionEnd = DateTime.UtcNow.AddDays(3),
                CompetitionImage = competitionImage,
            };

            var firstDog = new Dog
            {
                UserId = "firstUser",
                Id = 1,
                Name = "TestDog1",
            };
            var secondDog = new Dog
            {
                UserId = "secondUser",
                Id = 2,
                Name = "TestDog2",
            };
            var thirdDog = new Dog
            {
                UserId = "secondUser",
                Id = 3,
                Name = "TestDog3",
            };
            var fourthDog = new Dog
            {
                UserId = "secondUser",
                Id = 4,
                Name = "TestDog4",
            };
            firstCompetition.DogsCompetitions.Add(new DogCompetition
            {
                DogId = 1,
                Dog = firstDog,
                CompetitionId = 1,
                Competition = firstCompetition,
            });
            firstCompetition.DogsCompetitions.Add(new DogCompetition
            {
                DogId = 2,
                Dog = secondDog,
                CompetitionId = 1,
                Competition = firstCompetition,
            });
            firstCompetition.DogsCompetitions.Add(new DogCompetition
            {
                DogId = 3,
                Dog = thirdDog,
                CompetitionId = 1,
                Competition = firstCompetition,
            });
            secondCompetition.DogsCompetitions.Add(new DogCompetition
            {
                CompetitionId = 2,
                Competition = secondCompetition,
                DogId = 1,
                Dog = firstDog,
            });
            secondCompetition.DogsCompetitions.Add(new DogCompetition
            {
                CompetitionId = 2,
                Competition = secondCompetition,
                DogId = 4,
                Dog = fourthDog,
            });
            competitionsList.Add(firstCompetition);
            competitionsList.Add(secondCompetition);

            var data = service.DogsInCompetitions("secondUser");

            Assert.Equal(1, data.Count());
            Assert.Equal("Competition1", data.First().CompetitionName);
            Assert.Equal(2, data.First().AllDogsParticipants.Count());
            Assert.Equal("TestDog2", data.First().AllDogsParticipants.First().Name);
        }

        [Fact]
        public void GivenUserIdReturnsNullIfThereAreNoUserDogsParticipatingInCompetitions()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.Delete(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Remove(dog));
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            Mock<IDeletableEntityRepository<MatchRequestReceived>> receivedRequestsMockRepo = MatchRequestsReceivedMock();
            Mock<IDeletableEntityRepository<MatchRequestSent>> sentRequestsMockRepo = MatchRequestsSentMock();
            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JudgeAppFormsMock();
            Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();
            Mock<IDeletableEntityRepository<EyesColor>> eyesColorsMockRepo = EyesColorsMock();

            var judgeSrvice = new JudgesService(
                appFormsMockRepo.Object,
                competitionsMockRepo.Object);

            var service = new OwnerDashboardsService(
                dogsMockRepo.Object,
                dogColorsMockRepo.Object,
                eyesColorsMockRepo.Object,
                competitionsMockRepo.Object,
                appFormsMockRepo.Object,
                judgeSrvice,
                sentRequestsMockRepo.Object,
                receivedRequestsMockRepo.Object);

            var competitionImage = new CompetitionImage
            {
                Id = "imageId",
                Extension = "jpg",
            };

            var firstCompetition = new Competition
            {
                Id = 1,
                Name = "Competition1",
                CompetitionEnd = DateTime.UtcNow,
                CompetitionImage = competitionImage,
            };
            var secondCompetition = new Competition
            {
                Id = 2,
                Name = "Competition2",
                CompetitionEnd = DateTime.UtcNow.AddDays(3),
                CompetitionImage = competitionImage,
            };

            var firstDog = new Dog
            {
                UserId = "secondUser",
                Id = 1,
                Name = "TestDog1",
            };
            var secondDog = new Dog
            {
                UserId = "secondUser",
                Id = 2,
                Name = "TestDog2",
            };
            var thirdDog = new Dog
            {
                UserId = "secondUser",
                Id = 3,
                Name = "TestDog3",
            };
            var fourthDog = new Dog
            {
                UserId = "secondUser",
                Id = 4,
                Name = "TestDog4",
            };
            firstCompetition.DogsCompetitions.Add(new DogCompetition
            {
                DogId = 1,
                Dog = firstDog,
                CompetitionId = 1,
                Competition = firstCompetition,
            });
            firstCompetition.DogsCompetitions.Add(new DogCompetition
            {
                DogId = 2,
                Dog = secondDog,
                CompetitionId = 1,
                Competition = firstCompetition,
            });
            firstCompetition.DogsCompetitions.Add(new DogCompetition
            {
                DogId = 3,
                Dog = thirdDog,
                CompetitionId = 1,
                Competition = firstCompetition,
            });
            secondCompetition.DogsCompetitions.Add(new DogCompetition
            {
                CompetitionId = 2,
                Competition = secondCompetition,
                DogId = 1,
                Dog = firstDog,
            });
            secondCompetition.DogsCompetitions.Add(new DogCompetition
            {
                CompetitionId = 2,
                Competition = secondCompetition,
                DogId = 4,
                Dog = fourthDog,
            });
            competitionsList.Add(firstCompetition);
            competitionsList.Add(secondCompetition);

            var data = service.DogsInCompetitions("firstUser");

            Assert.Equal(0, data.Count());
        }

        [Fact]
        public void GivenUserIdReturnsNullIfThereAreNoCompletedCompetitionsUserDogsParticipatedIn()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.Delete(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Remove(dog));
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            Mock<IDeletableEntityRepository<MatchRequestReceived>> receivedRequestsMockRepo = MatchRequestsReceivedMock();
            Mock<IDeletableEntityRepository<MatchRequestSent>> sentRequestsMockRepo = MatchRequestsSentMock();
            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JudgeAppFormsMock();
            Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();
            Mock<IDeletableEntityRepository<EyesColor>> eyesColorsMockRepo = EyesColorsMock();

            var judgeSrvice = new JudgesService(
                appFormsMockRepo.Object,
                competitionsMockRepo.Object);

            var service = new OwnerDashboardsService(
                dogsMockRepo.Object,
                dogColorsMockRepo.Object,
                eyesColorsMockRepo.Object,
                competitionsMockRepo.Object,
                appFormsMockRepo.Object,
                judgeSrvice,
                sentRequestsMockRepo.Object,
                receivedRequestsMockRepo.Object);

            var competitionImage = new CompetitionImage
            {
                Id = "imageId",
                Extension = "jpg",
            };

            var firstCompetition = new Competition
            {
                Id = 1,
                Name = "Competition1",
                CompetitionEnd = DateTime.Now.AddDays(6),
                CompetitionImage = competitionImage,
            };
            var secondCompetition = new Competition
            {
                Id = 2,
                Name = "Competition2",
                CompetitionEnd = DateTime.UtcNow.AddDays(3),
                CompetitionImage = competitionImage,
            };

            var firstDog = new Dog
            {
                UserId = "secondUser",
                Id = 1,
                Name = "TestDog1",
            };
            var secondDog = new Dog
            {
                UserId = "secondUser",
                Id = 2,
                Name = "TestDog2",
            };
            var thirdDog = new Dog
            {
                UserId = "secondUser",
                Id = 3,
                Name = "TestDog3",
            };
            var fourthDog = new Dog
            {
                UserId = "secondUser",
                Id = 4,
                Name = "TestDog4",
            };
            firstCompetition.DogsCompetitions.Add(new DogCompetition
            {
                DogId = 1,
                Dog = firstDog,
                CompetitionId = 1,
                Competition = firstCompetition,
            });
            firstCompetition.DogsCompetitions.Add(new DogCompetition
            {
                DogId = 2,
                Dog = secondDog,
                CompetitionId = 1,
                Competition = firstCompetition,
            });
            firstCompetition.DogsCompetitions.Add(new DogCompetition
            {
                DogId = 3,
                Dog = thirdDog,
                CompetitionId = 1,
                Competition = firstCompetition,
            });
            secondCompetition.DogsCompetitions.Add(new DogCompetition
            {
                CompetitionId = 2,
                Competition = secondCompetition,
                DogId = 1,
                Dog = firstDog,
            });
            secondCompetition.DogsCompetitions.Add(new DogCompetition
            {
                CompetitionId = 2,
                Competition = secondCompetition,
                DogId = 4,
                Dog = fourthDog,
            });
            competitionsList.Add(firstCompetition);
            competitionsList.Add(secondCompetition);

            var data = service.DogsInCompetitions("secondUser");

            Assert.Equal(0, data.Count());
        }

        [Fact]
        public void GivenUserIdReturnsVotingDetailsPerCompetition()
        {
            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
            Mock<IDeletableEntityRepository<MatchRequestReceived>> receivedRequestsMockRepo = MatchRequestsReceivedMock();
            Mock<IDeletableEntityRepository<MatchRequestSent>> sentRequestsMockRepo = MatchRequestsSentMock();
            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JudgeAppFormsMock();
            Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();
            Mock<IDeletableEntityRepository<EyesColor>> eyesColorsMockRepo = EyesColorsMock();

            var judgeSrvice = new JudgesService(
                appFormsMockRepo.Object,
                competitionsMockRepo.Object);

            var service = new OwnerDashboardsService(
                dogsMockRepo.Object,
                dogColorsMockRepo.Object,
                eyesColorsMockRepo.Object,
                competitionsMockRepo.Object,
                appFormsMockRepo.Object,
                judgeSrvice,
                sentRequestsMockRepo.Object,
                receivedRequestsMockRepo.Object);

            var firstCompetition = new Competition
            {
                Id = 1,
                Name = "Competition1",
                CompetitionStart = DateTime.UtcNow,
                CompetitionEnd = DateTime.Now,
            };
            var secondCompetition = new Competition
            {
                Id = 2,
                Name = "Competition2",
                CompetitionStart = DateTime.UtcNow,
                CompetitionEnd = DateTime.Now,
            };
            var thirdCompetition = new Competition
            {
                Id = 3,
                Name = "Competition3",
                CompetitionStart = DateTime.UtcNow,
                CompetitionEnd = DateTime.Now,
            };

            var firstEvaluationForm = new EvaluationForm
            {
                Id = 1,
                UserId = "firstUser",
            };
            var secondEvaluationForm = new EvaluationForm
            {
                Id = 2,
                UserId = "firstUser",
            };
            secondCompetition.EvaluationForms.Add(firstEvaluationForm);
            secondCompetition.EvaluationForms.Add(secondEvaluationForm);
            thirdCompetition.EvaluationForms.Add(firstEvaluationForm);

            competitionsList.Add(firstCompetition);
            competitionsList.Add(secondCompetition);
            competitionsList.Add(thirdCompetition);

            var data = service.VoteInCompetitionDetails("firstUser").ToList();

            Assert.Equal(2, data.Count());
            Assert.Equal("Competition2", data.First().Name);
        }

        [Fact]
        public void GivenUserIdReturnsNullIfDidNotVoteInCompetitions()
        {
            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
            Mock<IDeletableEntityRepository<MatchRequestReceived>> receivedRequestsMockRepo = MatchRequestsReceivedMock();
            Mock<IDeletableEntityRepository<MatchRequestSent>> sentRequestsMockRepo = MatchRequestsSentMock();
            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JudgeAppFormsMock();
            Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();
            Mock<IDeletableEntityRepository<EyesColor>> eyesColorsMockRepo = EyesColorsMock();

            var judgeSrvice = new JudgesService(
                appFormsMockRepo.Object,
                competitionsMockRepo.Object);

            var service = new OwnerDashboardsService(
                dogsMockRepo.Object,
                dogColorsMockRepo.Object,
                eyesColorsMockRepo.Object,
                competitionsMockRepo.Object,
                appFormsMockRepo.Object,
                judgeSrvice,
                sentRequestsMockRepo.Object,
                receivedRequestsMockRepo.Object);

            var firstCompetition = new Competition
            {
                Id = 1,
                Name = "Competition1",
                CompetitionStart = DateTime.UtcNow,
                CompetitionEnd = DateTime.Now,
            };
            var secondCompetition = new Competition
            {
                Id = 2,
                Name = "Competition2",
                CompetitionStart = DateTime.UtcNow,
                CompetitionEnd = DateTime.Now,
            };
            var thirdCompetition = new Competition
            {
                Id = 3,
                Name = "Competition3",
                CompetitionStart = DateTime.UtcNow,
                CompetitionEnd = DateTime.Now,
            };

            var firstEvaluationForm = new EvaluationForm
            {
                Id = 1,
                UserId = "firstUser",
            };
            var secondEvaluationForm = new EvaluationForm
            {
                Id = 2,
                UserId = "firstUser",
            };
            secondCompetition.EvaluationForms.Add(firstEvaluationForm);
            secondCompetition.EvaluationForms.Add(secondEvaluationForm);
            thirdCompetition.EvaluationForms.Add(firstEvaluationForm);

            competitionsList.Add(firstCompetition);
            competitionsList.Add(secondCompetition);
            competitionsList.Add(thirdCompetition);

            var data = service.VoteInCompetitionDetails("secondUser").ToList();

            Assert.Equal(0, data.Count());
        }

        [Fact]
        public void GivenUserIdReturnsNumberOfRequestsSentByHisDog()
        {
            var sentRequestsList = new List<MatchRequestSent>();
            var sentRequestsMockRepo = new Mock<IDeletableEntityRepository<MatchRequestSent>>();
            sentRequestsMockRepo.Setup(x => x.All()).Returns(sentRequestsList.AsQueryable());
            sentRequestsMockRepo.Setup(x => x.AddAsync(It.IsAny<MatchRequestSent>())).Callback(
                (MatchRequestSent request) => sentRequestsList.Add(request));

            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
            Mock<IDeletableEntityRepository<MatchRequestReceived>> receivedRequestsMockRepo = MatchRequestsReceivedMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JudgeAppFormsMock();
            Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();
            Mock<IDeletableEntityRepository<EyesColor>> eyesColorsMockRepo = EyesColorsMock();

            var judgeSrvice = new JudgesService(
                appFormsMockRepo.Object,
                competitionsMockRepo.Object);

            var service = new OwnerDashboardsService(
                dogsMockRepo.Object,
                dogColorsMockRepo.Object,
                eyesColorsMockRepo.Object,
                competitionsMockRepo.Object,
                appFormsMockRepo.Object,
                judgeSrvice,
                sentRequestsMockRepo.Object,
                receivedRequestsMockRepo.Object);

            var firstUser = new ApplicationUser
            {
                Id = "firstId",
            };
            var senderDog = new Dog
            {
                Id = 1,
                Name = "Test1",
                UserId = "firstId",
                User = firstUser,
            };

            var secondUser = new ApplicationUser
            {
                Id = "receiverUserId",
                Email = "test2@mail2.bg",
            };

            var firstReceiverDog = new Dog
            {
                Id = 4,
                Name = "Test4",
                UserId = "receiverUserId",
                User = secondUser,
            };
            var secondReceiverDog = new Dog
            {
                Id = 5,
                Name = "Test5",
                UserId = "receiverUserId",
                User = secondUser,
            };

            var firstSentRequest = new MatchRequestSent
            {
                Id = 1,
                UserId = "firstId",
                SenderDogId = 1,
                SenderDog = senderDog,
                ReceiverDogId = 4,
                ReceiverDog = firstReceiverDog,
                IsApproved = true,
                IsUnderReview = false,
                IsRejected = false,
            };
            var secondSentRequest = new MatchRequestSent
            {
                Id = 2,
                UserId = "firstId",
                SenderDogId = 1,
                SenderDog = senderDog,
                ReceiverDogId = 5,
                ReceiverDog = secondReceiverDog,
                IsApproved = false,
                IsUnderReview = false,
                IsRejected = true,
            };

            sentRequestsList.Add(firstSentRequest);
            sentRequestsList.Add(secondSentRequest);

            var data = service.GetPartnershipRequestsSent("firstId").ToList();

            Assert.Equal(2, data.Count());
            Assert.Equal("Test4", data.First().ReceiverDogName);
        }

        [Fact]
        public void GivenUserIdReturnsNullIfNoPartnershipRequestsSentByHisDog()
        {
            var sentRequestsList = new List<MatchRequestSent>();
            var sentRequestsMockRepo = new Mock<IDeletableEntityRepository<MatchRequestSent>>();
            sentRequestsMockRepo.Setup(x => x.All()).Returns(sentRequestsList.AsQueryable());
            sentRequestsMockRepo.Setup(x => x.AddAsync(It.IsAny<MatchRequestSent>())).Callback(
                (MatchRequestSent request) => sentRequestsList.Add(request));

            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
            Mock<IDeletableEntityRepository<MatchRequestReceived>> receivedRequestsMockRepo = MatchRequestsReceivedMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JudgeAppFormsMock();
            Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();
            Mock<IDeletableEntityRepository<EyesColor>> eyesColorsMockRepo = EyesColorsMock();

            var judgeSrvice = new JudgesService(
                appFormsMockRepo.Object,
                competitionsMockRepo.Object);

            var service = new OwnerDashboardsService(
                dogsMockRepo.Object,
                dogColorsMockRepo.Object,
                eyesColorsMockRepo.Object,
                competitionsMockRepo.Object,
                appFormsMockRepo.Object,
                judgeSrvice,
                sentRequestsMockRepo.Object,
                receivedRequestsMockRepo.Object);

            var senderDog = new Dog
            {
                Id = 1,
                Name = "Test1",
                UserId = "firstId",
            };

            var secondUser = new ApplicationUser
            {
                Id = "receiverUserId",
                Email = "test2@mail2.bg",
            };

            var firstReceiverDog = new Dog
            {
                Id = 4,
                Name = "Test4",
                UserId = "receiverUserId",
                User = secondUser,
            };
            var secondReceiverDog = new Dog
            {
                Id = 5,
                Name = "Test5",
                UserId = "receiverUserId",
                User = secondUser,
            };

            var firstSentRequest = new MatchRequestSent
            {
                Id = 1,
                UserId = "firstId",
                SenderDogId = 1,
                SenderDog = senderDog,
                ReceiverDogId = 4,
                ReceiverDog = firstReceiverDog,
                IsApproved = true,
                IsUnderReview = false,
                IsRejected = false,
            };
            var secondSentRequest = new MatchRequestSent
            {
                Id = 2,
                UserId = "firstId",
                SenderDogId = 1,
                SenderDog = senderDog,
                ReceiverDogId = 5,
                ReceiverDog = secondReceiverDog,
                IsApproved = false,
                IsUnderReview = false,
                IsRejected = true,
            };

            sentRequestsList.Add(firstSentRequest);
            sentRequestsList.Add(secondSentRequest);

            var data = service.GetPartnershipRequestsSent("someId").ToList();

            Assert.Equal(0, data.Count());
        }

        [Fact]
        public void GivenUserIdReturnsNumberOfRequestsReceivedForHisDog()
        {
            var receivedRequestsList = new List<MatchRequestReceived>();
            var receivedRequestsMockRepo = new Mock<IDeletableEntityRepository<MatchRequestReceived>>();
            receivedRequestsMockRepo.Setup(x => x.All()).Returns(receivedRequestsList.AsQueryable());
            receivedRequestsMockRepo.Setup(x => x.AddAsync(It.IsAny<MatchRequestReceived>())).Callback(
                (MatchRequestReceived request) => receivedRequestsList.Add(request));

            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
            Mock<IDeletableEntityRepository<MatchRequestSent>> sentRequestsMockRepo = MatchRequestsSentMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JudgeAppFormsMock();
            Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();
            Mock<IDeletableEntityRepository<EyesColor>> eyesColorsMockRepo = EyesColorsMock();

            var judgeSrvice = new JudgesService(
                appFormsMockRepo.Object,
                competitionsMockRepo.Object);

            var service = new OwnerDashboardsService(
                dogsMockRepo.Object,
                dogColorsMockRepo.Object,
                eyesColorsMockRepo.Object,
                competitionsMockRepo.Object,
                appFormsMockRepo.Object,
                judgeSrvice,
                sentRequestsMockRepo.Object,
                receivedRequestsMockRepo.Object);

            var firstUser = new ApplicationUser
            {
                Id = "firstId",
                Email = "test1@mail2.bg",
            };
            var receiverDog = new Dog
            {
                Id = 1,
                Name = "Test1",
                UserId = "firstId",
                User = firstUser,
            };

            var secondUser = new ApplicationUser
            {
                Id = "senderUserId",
                Email = "test2@mail2.bg",
            };

            var firstSenderDog = new Dog
            {
                Id = 4,
                Name = "Test4",
                UserId = "senderUserId",
                User = secondUser,
            };
            var secondSenderDog = new Dog
            {
                Id = 5,
                Name = "Test5",
                UserId = "senderUserId",
                User = secondUser,
            };

            var firstReceivedRequest = new MatchRequestReceived
            {
                Id = 1,
                UserId = "firstId",
                SenderDogId = 4,
                SenderDog = firstSenderDog,
                ReceiverDogId = 1,
                ReceiverDog = receiverDog,
                IsApproved = true,
                IsUnderReview = false,
                IsRejected = false,
            };
            var secondReceivedRequest = new MatchRequestReceived
            {
                Id = 2,
                UserId = "Id",
                SenderDogId = 5,
                SenderDog = secondSenderDog,
                ReceiverDogId = 4,
                ReceiverDog = firstSenderDog,
                IsApproved = false,
                IsUnderReview = false,
                IsRejected = true,
            };

            receivedRequestsList.Add(firstReceivedRequest);
            receivedRequestsList.Add(secondReceivedRequest);

            var data = service.GetPartnershipRequestsReceived("firstId").ToList();

            Assert.Equal(1, data.Count());
            Assert.Equal("Test4", data.First().SenderDogName);
        }

        [Fact]
        public void GivenUserIdReturnsNullIfThereAreNoPartnershipRequestsReceivedForHisDog()
        {
            var receivedRequestsList = new List<MatchRequestReceived>();
            var receivedRequestsMockRepo = new Mock<IDeletableEntityRepository<MatchRequestReceived>>();
            receivedRequestsMockRepo.Setup(x => x.All()).Returns(receivedRequestsList.AsQueryable());
            receivedRequestsMockRepo.Setup(x => x.AddAsync(It.IsAny<MatchRequestReceived>())).Callback(
                (MatchRequestReceived request) => receivedRequestsList.Add(request));

            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
            Mock<IDeletableEntityRepository<MatchRequestSent>> sentRequestsMockRepo = MatchRequestsSentMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JudgeAppFormsMock();
            Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();
            Mock<IDeletableEntityRepository<EyesColor>> eyesColorsMockRepo = EyesColorsMock();

            var judgeSrvice = new JudgesService(
                appFormsMockRepo.Object,
                competitionsMockRepo.Object);

            var service = new OwnerDashboardsService(
                dogsMockRepo.Object,
                dogColorsMockRepo.Object,
                eyesColorsMockRepo.Object,
                competitionsMockRepo.Object,
                appFormsMockRepo.Object,
                judgeSrvice,
                sentRequestsMockRepo.Object,
                receivedRequestsMockRepo.Object);

            var firstUser = new ApplicationUser
            {
                Id = "firstId",
                Email = "test1@mail2.bg",
            };
            var receiverDog = new Dog
            {
                Id = 1,
                Name = "Test1",
                UserId = "firstId",
                User = firstUser,
            };

            var secondUser = new ApplicationUser
            {
                Id = "senderUserId",
                Email = "test2@mail2.bg",
            };

            var firstSenderDog = new Dog
            {
                Id = 4,
                Name = "Test4",
                UserId = "senderUserId",
                User = secondUser,
            };
            var secondSenderDog = new Dog
            {
                Id = 5,
                Name = "Test5",
                UserId = "senderUserId",
                User = secondUser,
            };

            var firstReceivedRequest = new MatchRequestReceived
            {
                Id = 1,
                UserId = "firstId",
                SenderDogId = 4,
                SenderDog = firstSenderDog,
                ReceiverDogId = 1,
                ReceiverDog = receiverDog,
                IsApproved = true,
                IsUnderReview = false,
                IsRejected = false,
            };
            var secondReceivedRequest = new MatchRequestReceived
            {
                Id = 2,
                UserId = "Id",
                SenderDogId = 5,
                SenderDog = secondSenderDog,
                ReceiverDogId = 4,
                ReceiverDog = firstSenderDog,
                IsApproved = false,
                IsUnderReview = false,
                IsRejected = true,
            };

            receivedRequestsList.Add(firstReceivedRequest);
            receivedRequestsList.Add(secondReceivedRequest);

            var data = service.GetPartnershipRequestsReceived("someId").ToList();

            Assert.Equal(0, data.Count());
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

        private static Mock<IDeletableEntityRepository<JudgeApplicationForm>> JudgeAppFormsMock()
        {
            var appFormsList = new List<JudgeApplicationForm>();
            var appFormsMockRepo = new Mock<IDeletableEntityRepository<JudgeApplicationForm>>();
            appFormsMockRepo.Setup(x => x.All()).Returns(appFormsList.AsQueryable());
            appFormsMockRepo.Setup(x => x.AddAsync(It.IsAny<JudgeApplicationForm>())).Callback(
                (JudgeApplicationForm appFrom) => appFormsList.Add(appFrom));
            return appFormsMockRepo;
        }

        private static Mock<IDeletableEntityRepository<Competition>> CompetitionsMock()
        {
            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));
            return competitionsMockRepo;
        }

        private static Mock<IDeletableEntityRepository<EyesColor>> EyesColorsMock()
        {
            var eyesColorsList = new List<EyesColor>();
            var eyesColorsMockRepo = new Mock<IDeletableEntityRepository<EyesColor>>();
            eyesColorsMockRepo.Setup(x => x.All()).Returns(eyesColorsList.AsQueryable());
            eyesColorsMockRepo.Setup(x => x.AddAsync(It.IsAny<EyesColor>())).Callback(
                (EyesColor eyesColor) => eyesColorsList.Add(eyesColor));
            return eyesColorsMockRepo;
        }

        private static Mock<IDeletableEntityRepository<DogColor>> DogColorsMock()
        {
            var dogColorsList = new List<DogColor>();
            var dogColorsMockRepo = new Mock<IDeletableEntityRepository<DogColor>>();
            dogColorsMockRepo.Setup(x => x.All()).Returns(dogColorsList.AsQueryable());
            dogColorsMockRepo.Setup(x => x.AddAsync(It.IsAny<DogColor>())).Callback(
                (DogColor dogColor) => dogColorsList.Add(dogColor));
            return dogColorsMockRepo;
        }
    }
}
