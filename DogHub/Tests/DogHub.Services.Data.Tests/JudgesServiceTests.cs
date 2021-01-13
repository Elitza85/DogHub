namespace DogHub.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models.CommonForms;
    using DogHub.Data.Models.Competitions;
    using DogHub.Services.Mapping;
    using DogHub.Web.ViewModels.Judges;
    using Moq;
    using Xunit;

    public class JudgesServiceTests : BaseServiceTest
    {
        [Fact]
        public void AllJudgesWithDetailsReturnedInList()
        {
            AutoMapperConfig.RegisterMappings(Assembly.Load("DogHub.Services.Data.Tests"));

            var appFormsList = new List<JudgeApplicationForm>();
            var appFormsMockRepo = new Mock<IDeletableEntityRepository<JudgeApplicationForm>>();
            appFormsMockRepo.Setup(x => x.All()).Returns(appFormsList.AsQueryable());
            appFormsMockRepo.Setup(x => x.AddAsync(It.IsAny<JudgeApplicationForm>())).Callback(
                (JudgeApplicationForm appFrom) => appFormsList.Add(appFrom));

            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();

            var service = new JudgesService(
                appFormsMockRepo.Object,
                competitionsMockRepo.Object);

            var image = new JudgeImage
            {
                Id = "image",
                Extension = "jpg",
            };
            var firstJudgeForm = new JudgeApplicationForm
            {
                FirstName = "Test11",
                LastName = "Test12",
                NumberOfChampionsOwned = 5,
                RaisedLitters = 5,
                YearsOfExperience = 7,
                JudgeImage = image,
                SelfDescription = "Description1",
                IsApproved = true,
            };
            var secondJudgeForm = new JudgeApplicationForm
            {
                FirstName = "Test21",
                LastName = "Test22",
                NumberOfChampionsOwned = 6,
                RaisedLitters = 6,
                YearsOfExperience = 10,
                JudgeImage = image,
                SelfDescription = "Description2",
                IsApproved = true,
            };
            appFormsList.Add(firstJudgeForm);
            appFormsList.Add(secondJudgeForm);

            var data = service.JudgeDetails<SingleJudgeViewModel>();

            Assert.Equal(2, data.Count());
            Assert.Equal("Test11", data.First().FirstName);
        }

        [Fact]
        public void OnlyApprovedJudgesListed()
        {
            AutoMapperConfig.RegisterMappings(Assembly.Load("DogHub.Services.Data.Tests"));

            var appFormsList = new List<JudgeApplicationForm>();
            var appFormsMockRepo = new Mock<IDeletableEntityRepository<JudgeApplicationForm>>();
            appFormsMockRepo.Setup(x => x.All()).Returns(appFormsList.AsQueryable());
            appFormsMockRepo.Setup(x => x.AddAsync(It.IsAny<JudgeApplicationForm>())).Callback(
                (JudgeApplicationForm appFrom) => appFormsList.Add(appFrom));

            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();

            var service = new JudgesService(
                appFormsMockRepo.Object,
                competitionsMockRepo.Object);

            var image = new JudgeImage
            {
                Id = "image",
                Extension = "jpg",
            };
            var firstJudgeForm = new JudgeApplicationForm
            {
                FirstName = "Test11",
                LastName = "Test12",
                NumberOfChampionsOwned = 5,
                RaisedLitters = 5,
                YearsOfExperience = 7,
                JudgeImage = image,
                SelfDescription = "Description1",
                IsApproved = false,
            };
            var secondJudgeForm = new JudgeApplicationForm
            {
                FirstName = "Test21",
                LastName = "Test22",
                NumberOfChampionsOwned = 6,
                RaisedLitters = 6,
                YearsOfExperience = 10,
                JudgeImage = image,
                SelfDescription = "Description2",
                IsApproved = true,
            };
            var thirdJudgeForm = new JudgeApplicationForm
            {
                FirstName = "Test31",
                LastName = "Test32",
                NumberOfChampionsOwned = 7,
                RaisedLitters = 7,
                YearsOfExperience = 9,
                JudgeImage = image,
                SelfDescription = "Description3",
                IsApproved = true,
            };
            appFormsList.Add(firstJudgeForm);
            appFormsList.Add(secondJudgeForm);
            appFormsList.Add(thirdJudgeForm);

            var data = service.JudgesList();

            Assert.Equal(2, data.JudgesList.Count());
            Assert.Equal("Test21", data.JudgesList.First().FirstName);
        }

        [Fact]
        public void JudgeApplicationFormApprovalDateReturnedCorrectly()
        {
            var appFormsList = new List<JudgeApplicationForm>();
            var appFormsMockRepo = new Mock<IDeletableEntityRepository<JudgeApplicationForm>>();
            appFormsMockRepo.Setup(x => x.All()).Returns(appFormsList.AsQueryable());
            appFormsMockRepo.Setup(x => x.AddAsync(It.IsAny<JudgeApplicationForm>())).Callback(
                (JudgeApplicationForm appFrom) => appFormsList.Add(appFrom));

            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();

            var service = new JudgesService(
                appFormsMockRepo.Object,
                competitionsMockRepo.Object);

            var firstJudgeForm = new JudgeApplicationForm
            {
                FirstName = "Test11",
                LastName = "Test12",
                SelfDescription = "Description1",
                IsApproved = false,
                UserId = "firstUser",
            };
            var secondJudgeForm = new JudgeApplicationForm
            {
                FirstName = "Test21",
                LastName = "Test22",
                IsApproved = true,
                ApprovalDate = DateTime.UtcNow,
                UserId = "secondUser",
            };
            var thirdJudgeForm = new JudgeApplicationForm
            {
                FirstName = "Test31",
                LastName = "Test32",
                IsApproved = true,
                UserId = "thirdUser",
            };
            appFormsList.Add(firstJudgeForm);
            appFormsList.Add(secondJudgeForm);
            appFormsList.Add(thirdJudgeForm);

            Assert.Equal(DateTime.UtcNow.ToString("f"), service.JudgeApplicationFormApprovalDate("secondUser").ToString("f"));
        }

        [Fact]
        public void JudgeApplicationFormApprovalDateReturnedMinValueIfNotAvailable()
        {
            var appFormsList = new List<JudgeApplicationForm>();
            var appFormsMockRepo = new Mock<IDeletableEntityRepository<JudgeApplicationForm>>();
            appFormsMockRepo.Setup(x => x.All()).Returns(appFormsList.AsQueryable());
            appFormsMockRepo.Setup(x => x.AddAsync(It.IsAny<JudgeApplicationForm>())).Callback(
                (JudgeApplicationForm appFrom) => appFormsList.Add(appFrom));

            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();

            var service = new JudgesService(
                appFormsMockRepo.Object,
                competitionsMockRepo.Object);

            var firstJudgeForm = new JudgeApplicationForm
            {
                FirstName = "Test11",
                LastName = "Test12",
                SelfDescription = "Description1",
                IsApproved = false,
                UserId = "firstUser",
            };
            var secondJudgeForm = new JudgeApplicationForm
            {
                FirstName = "Test21",
                LastName = "Test22",
                IsApproved = true,
                ApprovalDate = DateTime.UtcNow,
                UserId = "secondUser",
            };
            var thirdJudgeForm = new JudgeApplicationForm
            {
                FirstName = "Test31",
                LastName = "Test32",
                IsApproved = true,
                UserId = "thirdUser",
            };
            appFormsList.Add(firstJudgeForm);
            appFormsList.Add(secondJudgeForm);
            appFormsList.Add(thirdJudgeForm);

            Assert.Equal("01 January 0001 00:00", service.JudgeApplicationFormApprovalDate("firstUser").ToString("f"));
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

        private static Mock<IDeletableEntityRepository<JudgeApplicationForm>> JudgeAppFormsMock()
        {
            var appFormsList = new List<JudgeApplicationForm>();
            var appFormsMockRepo = new Mock<IDeletableEntityRepository<JudgeApplicationForm>>();
            appFormsMockRepo.Setup(x => x.All()).Returns(appFormsList.AsQueryable());
            appFormsMockRepo.Setup(x => x.AddAsync(It.IsAny<JudgeApplicationForm>())).Callback(
                (JudgeApplicationForm appFrom) => appFormsList.Add(appFrom));
            return appFormsMockRepo;
        }
    }
}
