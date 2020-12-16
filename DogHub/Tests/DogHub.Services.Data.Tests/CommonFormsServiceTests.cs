namespace DogHub.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models;
    using DogHub.Data.Models.CommonForms;
    using DogHub.Data.Models.Competitions;
    using DogHub.Data.Models.EvaluationForms;
    using DogHub.Web.ViewModels.CommonForms;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Xunit;

    public class CommonFormsServiceTests
    {
        [Fact]
        public async Task ApplyForJudgeWithCorrectInputDataAddsApplicationToList()
        {
            var judgeAppFormsList = new List<JudgeApplicationForm>();
            var judgeFormsMockRepo = new Mock<IDeletableEntityRepository<JudgeApplicationForm>>();
            judgeFormsMockRepo.Setup(x => x.All()).Returns(judgeAppFormsList.AsQueryable());
            judgeFormsMockRepo.Setup(x => x.AddAsync(It.IsAny<JudgeApplicationForm>())).Callback(
                (JudgeApplicationForm judgeAppForm) => judgeAppFormsList.Add(judgeAppForm));

            Mock<IDeletableEntityRepository<EvaluationForm>> evaluationFormsMockRepo = EvaluationFormsMock();
            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();

            var service = new CommonFormsService(
                judgeFormsMockRepo.Object,
                evaluationFormsMockRepo.Object,
                dogsMockRepo.Object,
                competitionsMockRepo.Object);

            // Arrange mock image file
            var fileMock = new Mock<IFormFile>();
            var fileName = "image.jpg";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);
            var imageFile = fileMock.Object;

            var input = new JudgeApplicationInputModel
            {
                FirstName = "Greta",
                LastName = "Fraun",
                YearsOfExperience = 6,
                RaisedLitters = 5,
                NumberOfChampionsOwned = 7,
                AttendedJudgeInstituteCourse = true,
                HasBeenJudgeAssistant = true,
                JudgeInstituteCertificateUrl = "some url",
                SelfDescription = "Description",
                UserId = "userId",
                JudgeImage = imageFile,
            };

            await service.ApplyForJudge(input, "imagePath");

            Assert.Equal(1, judgeAppFormsList.Count());
            Assert.Equal("Greta", judgeAppFormsList.First().FirstName);
        }

        [Fact]
        public void ApplyForJudgeWithInvalidImageFileThrowsError()
        {
            var judgeAppFormsList = new List<JudgeApplicationForm>();
            var judgeFormsMockRepo = new Mock<IDeletableEntityRepository<JudgeApplicationForm>>();
            judgeFormsMockRepo.Setup(x => x.All()).Returns(judgeAppFormsList.AsQueryable());
            judgeFormsMockRepo.Setup(x => x.AddAsync(It.IsAny<JudgeApplicationForm>())).Callback(
                (JudgeApplicationForm judgeAppForm) => judgeAppFormsList.Add(judgeAppForm));

            Mock<IDeletableEntityRepository<EvaluationForm>> evaluationFormsMockRepo = EvaluationFormsMock();
            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();

            var service = new CommonFormsService(
                judgeFormsMockRepo.Object,
                evaluationFormsMockRepo.Object,
                dogsMockRepo.Object,
                competitionsMockRepo.Object);

            // Arrange mock image file
            var fileMock = new Mock<IFormFile>();
            var fileName = "image.doc";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);
            var imageFile = fileMock.Object;

            var input = new JudgeApplicationInputModel
            {
                FirstName = "Greta",
                LastName = "Fraun",
                YearsOfExperience = 6,
                RaisedLitters = 5,
                NumberOfChampionsOwned = 7,
                AttendedJudgeInstituteCourse = true,
                HasBeenJudgeAssistant = true,
                JudgeInstituteCertificateUrl = "some url",
                SelfDescription = "Description",
                UserId = "userId",
                JudgeImage = imageFile,
            };

            Assert.Equal("Invalid image extenstion doc", service.ApplyForJudge(input, "imagePath").Exception.InnerException.Message);
        }

        [Fact]
        public void UserThatHasAlreadyAppliedForJudgeReturnsTrue()
        {
            var judgeAppFormsList = new List<JudgeApplicationForm>();
            var judgeFormsMockRepo = new Mock<IDeletableEntityRepository<JudgeApplicationForm>>();
            judgeFormsMockRepo.Setup(x => x.All()).Returns(judgeAppFormsList.AsQueryable());
            judgeFormsMockRepo.Setup(x => x.AddAsync(It.IsAny<JudgeApplicationForm>())).Callback(
                (JudgeApplicationForm judgeAppForm) => judgeAppFormsList.Add(judgeAppForm));

            Mock<IDeletableEntityRepository<EvaluationForm>> evaluationFormsMockRepo = EvaluationFormsMock();
            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();

            var service = new CommonFormsService(
                judgeFormsMockRepo.Object,
                evaluationFormsMockRepo.Object,
                dogsMockRepo.Object,
                competitionsMockRepo.Object);

            var judgeAppForm = new JudgeApplicationForm
            {
                FirstName = "Greta",
                LastName = "Fraun",
                YearsOfExperience = 6,
                RaisedLitters = 5,
                NumberOfChampionsOwned = 7,
                AttendedJudgeInstituteCourse = true,
                HasBeenJudgeAssistant = true,
                IsApproved = false,
                IsRejected = false,
                IsUnderReview = true,
                JudgeInstituteCertificateUrl = "some url",
                SelfDescription = "Description",
                UserId = "userId",
                JudgeImage = new JudgeImage { Extension = "jpg" },
            };
            judgeAppFormsList.Add(judgeAppForm);

            Assert.True(service.HasAlreadyAppliedForJudge("userId"));
        }

        [Fact]
        public void UserThatHasAlreadyVotedForDogReturnsFalse()
        {
            var evaluationFormsList = new List<EvaluationForm>();
            var evaluationFormsMockRepo = new Mock<IDeletableEntityRepository<EvaluationForm>>();
            evaluationFormsMockRepo.Setup(x => x.All()).Returns(evaluationFormsList.AsQueryable());
            evaluationFormsMockRepo.Setup(x => x.AddAsync(It.IsAny<EvaluationForm>())).Callback(
                (EvaluationForm evaluationForm) => evaluationFormsList.Add(evaluationForm));

            Mock<IDeletableEntityRepository<JudgeApplicationForm>> judgeAppFormsMockRepo = JugeAppFormsMock();
            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();

            var service = new CommonFormsService(
                judgeAppFormsMockRepo.Object,
                evaluationFormsMockRepo.Object,
                dogsMockRepo.Object,
                competitionsMockRepo.Object);

            var votingForm = new EvaluationForm
            {
                CompetitionId = 1,
                DogId = 1,
                TotalPoints = 25,
                UserId = "userId",
            };
            evaluationFormsList.Add(votingForm);

            Assert.False(service.CheckIfUserHasVoted("userId", 1, 1));
        }

        [Fact]
        public void UserAndDogOwnerAreNotTheSameReturnsTrue()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<JudgeApplicationForm>> judgeAppFormsMockRepo = JugeAppFormsMock();
            Mock<IDeletableEntityRepository<EvaluationForm>> evaluationFormsMockRepo = EvaluationFormsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();

            var service = new CommonFormsService(
                judgeAppFormsMockRepo.Object,
                evaluationFormsMockRepo.Object,
                dogsMockRepo.Object,
                competitionsMockRepo.Object);

            var dog = new Dog
            {
                Id = 1,
                UserId = "userId",
            };
            dogsList.Add(dog);

            Assert.True(service.CheckIfUserIsOwner("user", 1, 1));
        }

        [Fact]
        public void CompetitionInProgressReturnsTrue()
        {
            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            Mock<IDeletableEntityRepository<JudgeApplicationForm>> judgeAppFormsMockRepo = JugeAppFormsMock();
            Mock<IDeletableEntityRepository<EvaluationForm>> evaluationFormsMockRepo = EvaluationFormsMock();
            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();

            var service = new CommonFormsService(
                judgeAppFormsMockRepo.Object,
                evaluationFormsMockRepo.Object,
                dogsMockRepo.Object,
                competitionsMockRepo.Object);

            var competition = new Competition
            {
                Id = 1,
                CompetitionStart = DateTime.UtcNow,
                CompetitionEnd = DateTime.Now.AddDays(2),
            };
            competitionsList.Add(competition);

            Assert.True(service.IsCompetitionCurrentlyInProgress(1));
        }

        [Fact]
        public async Task VotingForDogAddsEvaluationFormToDatabaseWithPointsGivenForDog()
        {
            var evaluationFormsList = new List<EvaluationForm>();
            var evaluationFormsMockRepo = new Mock<IDeletableEntityRepository<EvaluationForm>>();
            evaluationFormsMockRepo.Setup(x => x.All()).Returns(evaluationFormsList.AsQueryable());
            evaluationFormsMockRepo.Setup(x => x.AddAsync(It.IsAny<EvaluationForm>())).Callback(
                (EvaluationForm evaluationForm) => evaluationFormsList.Add(evaluationForm));

            Mock<IDeletableEntityRepository<JudgeApplicationForm>> judgeAppFormsMockRepo = JugeAppFormsMock();
            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();

            var service = new CommonFormsService(
                judgeAppFormsMockRepo.Object,
                evaluationFormsMockRepo.Object,
                dogsMockRepo.Object,
                competitionsMockRepo.Object);

            var user = new ApplicationUser
            {
                Id = "userId",
            };

            var input = new VoteFormInputModel
            {
                CompetitionId = 1,
                DogId = 1,
                TotalPoints = 25,
                UserId = user.Id,
            };

            await service.VoteForDog(input, user);

            Assert.Equal(1, evaluationFormsList.Count());
            Assert.Equal(25, evaluationFormsList.First().TotalPoints);
        }

        [Fact]
        public async Task JudgeVotingForDogDoublesThePoints()
        {
            var evaluationFormsList = new List<EvaluationForm>();
            var evaluationFormsMockRepo = new Mock<IDeletableEntityRepository<EvaluationForm>>();
            evaluationFormsMockRepo.Setup(x => x.All()).Returns(evaluationFormsList.AsQueryable());
            evaluationFormsMockRepo.Setup(x => x.AddAsync(It.IsAny<EvaluationForm>())).Callback(
                (EvaluationForm evaluationForm) => evaluationFormsList.Add(evaluationForm));

            Mock<IDeletableEntityRepository<JudgeApplicationForm>> judgeAppFormsMockRepo = JugeAppFormsMock();
            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();

            var service = new CommonFormsService(
                judgeAppFormsMockRepo.Object,
                evaluationFormsMockRepo.Object,
                dogsMockRepo.Object,
                competitionsMockRepo.Object);

            var user = new ApplicationUser
            {
                Id = "userId",
            };

            var input = new VoteFormInputModel
            {
                CompetitionId = 1,
                DogId = 1,
                TotalPoints = 25,
                UserId = user.Id,
                IsUserJudge = true,
            };

            await service.VoteForDog(input, user);

            Assert.Equal(1, evaluationFormsList.Count());
            Assert.Equal(50, evaluationFormsList.First().TotalPoints);
        }

        [Fact]
        public void GivenDogIdReturnsUpdatedVideoStringThatIsViewableInIFrame()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<JudgeApplicationForm>> judgeAppFormsMockRepo = JugeAppFormsMock();
            Mock<IDeletableEntityRepository<EvaluationForm>> evaluationFormsMockRepo = EvaluationFormsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();

            var service = new CommonFormsService(
                judgeAppFormsMockRepo.Object,
                evaluationFormsMockRepo.Object,
                dogsMockRepo.Object,
                competitionsMockRepo.Object);

            var dog = new Dog
            {
                Id = 1,
                UserId = "userId",
                DogVideoUrl = "https://www.youtube.com/watch?v=28xjtYY3V3Q",
            };
            dogsList.Add(dog);

            var dogVideo = service.GetDogVideoByDogId(1);

            Assert.Equal("https://www.youtube.com/embed/28xjtYY3V3Q", dogVideo);
        }

        private static Mock<IDeletableEntityRepository<EvaluationForm>> EvaluationFormsMock()
        {
            var evaluationFormsList = new List<EvaluationForm>();
            var evaluationFormsMockRepo = new Mock<IDeletableEntityRepository<EvaluationForm>>();
            evaluationFormsMockRepo.Setup(x => x.All()).Returns(evaluationFormsList.AsQueryable());
            evaluationFormsMockRepo.Setup(x => x.AddAsync(It.IsAny<EvaluationForm>())).Callback(
                (EvaluationForm evaluationForm) => evaluationFormsList.Add(evaluationForm));
            return evaluationFormsMockRepo;
        }

        private static Mock<IDeletableEntityRepository<JudgeApplicationForm>> JugeAppFormsMock()
        {
            var judgeAppFormsList = new List<JudgeApplicationForm>();
            var judgeFromsMockRepo = new Mock<IDeletableEntityRepository<JudgeApplicationForm>>();
            judgeFromsMockRepo.Setup(x => x.All()).Returns(judgeAppFormsList.AsQueryable());
            judgeFromsMockRepo.Setup(x => x.AddAsync(It.IsAny<JudgeApplicationForm>())).Callback(
                (JudgeApplicationForm judgeAppForm) => judgeAppFormsList.Add(judgeAppForm));
            return judgeFromsMockRepo;
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

        private static Mock<IDeletableEntityRepository<Competition>> CompetitionsMock()
        {
            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));
            return competitionsMockRepo;
        }
    }
}
