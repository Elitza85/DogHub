//namespace DogHub.Services.Data.Tests
//{
//    using System;
//    using System.Collections.Generic;
//    using System.IO;
//    using System.Linq;
//    using System.Threading.Tasks;

//    using DogHub.Data.Common.Repositories;
//    using DogHub.Data.Models;
//    using DogHub.Data.Models.CommonForms;
//    using DogHub.Data.Models.Competitions;
//    using DogHub.Data.Models.Dogs;
//    using DogHub.Services.Messaging;
//    using DogHub.Web.Areas.Administration.Services;
//    using DogHub.Web.ViewModels.Competitions;
//    using Microsoft.AspNetCore.Http;
//    using Moq;
//    using Xunit;

//    public class AdminDashboardServiceTests
//    {
//        [Fact]
//        public async Task CompetitionWithValidInputDataIsAddedToDatabase()
//        {
//            var competitionsList = new List<Competition>();
//            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
//            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
//            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
//                (Competition competition) => competitionsList.Add(competition));

//            Mock<IDeletableEntityRepository<Organiser>> organisersMockRepo = OrganisersMock();
//            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
//            Mock<IDeletableEntityRepository<Breed>> breedsMockRepo = BreedsMock();
//            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JugeAppFormsMock();
//            Mock<IDeletableEntityRepository<ApplicationUser>> usersMockRepo = UsersMock();
//            SendGridEmailSender mailSender = new SendGridEmailSender("key");

//            var service = new DashboardService(
//                organisersMockRepo.Object,
//                competitionsMockRepo.Object,
//                breedsMockRepo.Object,
//                appFormsMockRepo.Object,
//                usersMockRepo.Object,
//                dogsMockRepo.Object,
//                mailSender);

//            // Arrange mock image file
//            var fileMock = new Mock<IFormFile>();
//            var fileName = "image.jpg";
//            var ms = new MemoryStream();
//            var writer = new StreamWriter(ms);
//            ms.Position = 0;
//            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
//            fileMock.Setup(_ => _.FileName).Returns(fileName);
//            fileMock.Setup(_ => _.Length).Returns(ms.Length);
//            var imageFile = fileMock.Object;

//            var input = new CreateCompetitionInputModel
//            {
//                BreedId = 1,
//                Name = "TestName",
//                CompetitionStart = DateTime.Now,
//                CompetitionEnd = DateTime.Now.AddDays(1),
//                CompetitionImage = imageFile,
//                OrganisedBy = "Organiser",
//            };

//            await service.CreateCompetition(input, "path");

//            Assert.Equal(1, competitionsList.Count());
//            Assert.Equal("TestName", competitionsList.First().Name);
//        }

//        [Fact]
//        public async Task CompetitionWithValidInputReturnsCompetitionName()
//        {
//            var competitionsList = new List<Competition>();
//            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
//            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
//            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
//                (Competition competition) => competitionsList.Add(competition));

//            Mock<IDeletableEntityRepository<Organiser>> organisersMockRepo = OrganisersMock();
//            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
//            Mock<IDeletableEntityRepository<Breed>> breedsMockRepo = BreedsMock();
//            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JugeAppFormsMock();
//            Mock<IDeletableEntityRepository<ApplicationUser>> usersMockRepo = UsersMock();
//            SendGridEmailSender mailSender = new SendGridEmailSender("key");

//            var service = new DashboardService(
//                organisersMockRepo.Object,
//                competitionsMockRepo.Object,
//                breedsMockRepo.Object,
//                appFormsMockRepo.Object,
//                usersMockRepo.Object,
//                dogsMockRepo.Object,
//                mailSender);

//            // Arrange mock image file
//            var fileMock = new Mock<IFormFile>();
//            var fileName = "image.jpg";
//            var ms = new MemoryStream();
//            var writer = new StreamWriter(ms);
//            ms.Position = 0;
//            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
//            fileMock.Setup(_ => _.FileName).Returns(fileName);
//            fileMock.Setup(_ => _.Length).Returns(ms.Length);
//            var imageFile = fileMock.Object;

//            var input = new CreateCompetitionInputModel
//            {
//                BreedId = 1,
//                Name = "TestName",
//                CompetitionStart = DateTime.Now,
//                CompetitionEnd = DateTime.Now.AddDays(1),
//                CompetitionImage = imageFile,
//                OrganisedBy = "Organiser",
//            };

//            var name = await service.CreateCompetition(input, "path");

//            Assert.Equal("TestName" , name);
//        }

//        [Fact]
//        public void CompetitionWithInvalidInputImageReturnsError()
//        {
//            var competitionsList = new List<Competition>();
//            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
//            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
//            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
//                (Competition competition) => competitionsList.Add(competition));

//            Mock<IDeletableEntityRepository<Organiser>> organisersMockRepo = OrganisersMock();
//            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
//            Mock<IDeletableEntityRepository<Breed>> breedsMockRepo = BreedsMock();
//            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JugeAppFormsMock();
//            Mock<IDeletableEntityRepository<ApplicationUser>> usersMockRepo = UsersMock();
//            SendGridEmailSender mailSender = new SendGridEmailSender("key");

//            var service = new DashboardService(
//                organisersMockRepo.Object,
//                competitionsMockRepo.Object,
//                breedsMockRepo.Object,
//                appFormsMockRepo.Object,
//                usersMockRepo.Object,
//                dogsMockRepo.Object,
//                mailSender);

//            // Arrange mock image file
//            var fileMock = new Mock<IFormFile>();
//            var fileName = "image.doc";
//            var ms = new MemoryStream();
//            var writer = new StreamWriter(ms);
//            ms.Position = 0;
//            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
//            fileMock.Setup(_ => _.FileName).Returns(fileName);
//            fileMock.Setup(_ => _.Length).Returns(ms.Length);
//            var imageFile = fileMock.Object;

//            var input = new CreateCompetitionInputModel
//            {
//                BreedId = 1,
//                Name = "TestName",
//                CompetitionStart = DateTime.Now,
//                CompetitionEnd = DateTime.Now.AddDays(1),
//                CompetitionImage = imageFile,
//                OrganisedBy = "Organiser",
//            };

//            var data = service.CreateCompetition(input, "path");

//            Assert.Equal("Invalid image extenstion doc", data.Exception.InnerException.Message);
//        }

//        [Fact]
//        public void GettingAllBreedsReturnsBreedsListOfUnapprovedBreeds()
//        {
//            var breedsList = new List<Breed>();
//            var breedsMockRepo = new Mock<IDeletableEntityRepository<Breed>>();
//            breedsMockRepo.Setup(x => x.All()).Returns(breedsList.AsQueryable());
//            breedsMockRepo.Setup(x => x.AddAsync(It.IsAny<Breed>())).Callback(
//                (Breed breed) => breedsList.Add(breed));

//            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
//            Mock<IDeletableEntityRepository<Organiser>> organisersMockRepo = OrganisersMock();
//            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
//            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JugeAppFormsMock();
//            Mock<IDeletableEntityRepository<ApplicationUser>> usersMockRepo = UsersMock();
//            SendGridEmailSender mailSender = new SendGridEmailSender("key");

//            var service = new DashboardService(
//                organisersMockRepo.Object,
//                competitionsMockRepo.Object,
//                breedsMockRepo.Object,
//                appFormsMockRepo.Object,
//                usersMockRepo.Object,
//                dogsMockRepo.Object,
//                mailSender);

//            var firstBreed = new Breed
//            {
//                Id = 1,
//                Name = "Poodle",
//                IsUnderReview = false,
//            };
//            var secondBreed = new Breed
//            {
//                Id = 2,
//                Name = "Bulldog",
//                IsUnderReview = true,
//            };
//            var thirdBreed = new Breed
//            {
//                Id = 3,
//                Name = "Chao Chao",
//                IsUnderReview = true,
//            };
//            breedsList.Add(firstBreed);
//            breedsList.Add(secondBreed);
//            breedsList.Add(thirdBreed);

//            var data = service.BreedsListData();

//            Assert.Equal(2, data.AllBreeds.Count());
//        }

//        [Fact]
//        public void GettingAllBreedsReturnsBreedsListedByNameAsc()
//        {
//            var breedsList = new List<Breed>();
//            var breedsMockRepo = new Mock<IDeletableEntityRepository<Breed>>();
//            breedsMockRepo.Setup(x => x.All()).Returns(breedsList.AsQueryable());
//            breedsMockRepo.Setup(x => x.AddAsync(It.IsAny<Breed>())).Callback(
//                (Breed breed) => breedsList.Add(breed));

//            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
//            Mock<IDeletableEntityRepository<Organiser>> organisersMockRepo = OrganisersMock();
//            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
//            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JugeAppFormsMock();
//            Mock<IDeletableEntityRepository<ApplicationUser>> usersMockRepo = UsersMock();
//            SendGridEmailSender mailSender = new SendGridEmailSender("key");

//            var service = new DashboardService(
//                organisersMockRepo.Object,
//                competitionsMockRepo.Object,
//                breedsMockRepo.Object,
//                appFormsMockRepo.Object,
//                usersMockRepo.Object,
//                dogsMockRepo.Object,
//                mailSender);

//            var firstBreed = new Breed
//            {
//                Id = 1,
//                Name = "Poodle",
//                IsUnderReview = false,
//            };
//            var secondBreed = new Breed
//            {
//                Id = 2,
//                Name = "Chao Chao",
//                IsUnderReview = true,
//            };
//            var thirdBreed = new Breed
//            {
//                Id = 3,
//                Name = "Bulldog",
//                IsUnderReview = true,
//            };
//            breedsList.Add(firstBreed);
//            breedsList.Add(secondBreed);
//            breedsList.Add(thirdBreed);

//            var data = service.BreedsListData();

//            Assert.Equal(3, data.AllBreeds.First().BreedId);
//        }

//        [Fact]
//        public async Task ApprovingNewBreedChangesItsUnderReviewAndIsApprovedStatuses()
//        {
//            var breedsList = new List<Breed>();
//            var breedsMockRepo = new Mock<IDeletableEntityRepository<Breed>>();
//            breedsMockRepo.Setup(x => x.All()).Returns(breedsList.AsQueryable());
//            breedsMockRepo.Setup(x => x.AddAsync(It.IsAny<Breed>())).Callback(
//                (Breed breed) => breedsList.Add(breed));

//            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
//            Mock<IDeletableEntityRepository<Organiser>> organisersMockRepo = OrganisersMock();
//            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
//            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JugeAppFormsMock();
//            Mock<IDeletableEntityRepository<ApplicationUser>> usersMockRepo = UsersMock();
//            SendGridEmailSender mailSender = new SendGridEmailSender("key");

//            var service = new DashboardService(
//                organisersMockRepo.Object,
//                competitionsMockRepo.Object,
//                breedsMockRepo.Object,
//                appFormsMockRepo.Object,
//                usersMockRepo.Object,
//                dogsMockRepo.Object,
//                mailSender);

//            var firstBreed = new Breed
//            {
//                Id = 1,
//                Name = "Poodle",
//                IsUnderReview = true,
//            };
//            breedsList.Add(firstBreed);

//            await service.ApproveNewBreed(1);

//            Assert.True(breedsList.First().IsApproved);
//            Assert.False(breedsList.First().IsUnderReview);
//        }

//        [Fact]
//        public async Task ApprovingNewBreedReturnsBreedName()
//        {
//            var breedsList = new List<Breed>();
//            var breedsMockRepo = new Mock<IDeletableEntityRepository<Breed>>();
//            breedsMockRepo.Setup(x => x.All()).Returns(breedsList.AsQueryable());
//            breedsMockRepo.Setup(x => x.AddAsync(It.IsAny<Breed>())).Callback(
//                (Breed breed) => breedsList.Add(breed));

//            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
//            Mock<IDeletableEntityRepository<Organiser>> organisersMockRepo = OrganisersMock();
//            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
//            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JugeAppFormsMock();
//            Mock<IDeletableEntityRepository<ApplicationUser>> usersMockRepo = UsersMock();
//            SendGridEmailSender mailSender = new SendGridEmailSender("key");

//            var service = new DashboardService(
//                organisersMockRepo.Object,
//                competitionsMockRepo.Object,
//                breedsMockRepo.Object,
//                appFormsMockRepo.Object,
//                usersMockRepo.Object,
//                dogsMockRepo.Object,
//                mailSender);

//            var firstBreed = new Breed
//            {
//                Id = 1,
//                Name = "Poodle",
//                IsUnderReview = true,
//            };
//            breedsList.Add(firstBreed);

//            var name = await service.ApproveNewBreed(1);

//            Assert.Equal("Poodle", name);
//        }

//        [Fact]
//        public async Task RejectingNewBreedChangesItsUnderReviewAndIsRejectedStatuses()
//        {
//            var breedsList = new List<Breed>();
//            var breedsMockRepo = new Mock<IDeletableEntityRepository<Breed>>();
//            breedsMockRepo.Setup(x => x.All()).Returns(breedsList.AsQueryable());
//            breedsMockRepo.Setup(x => x.AddAsync(It.IsAny<Breed>())).Callback(
//                (Breed breed) => breedsList.Add(breed));

//            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
//            Mock<IDeletableEntityRepository<Organiser>> organisersMockRepo = OrganisersMock();
//            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
//            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JugeAppFormsMock();
//            Mock<IDeletableEntityRepository<ApplicationUser>> usersMockRepo = UsersMock();
//            SendGridEmailSender mailSender = new SendGridEmailSender("key");

//            var service = new DashboardService(
//                organisersMockRepo.Object,
//                competitionsMockRepo.Object,
//                breedsMockRepo.Object,
//                appFormsMockRepo.Object,
//                usersMockRepo.Object,
//                dogsMockRepo.Object,
//                mailSender);

//            var firstBreed = new Breed
//            {
//                Id = 1,
//                Name = "Poodle",
//                IsUnderReview = true,
//            };
//            breedsList.Add(firstBreed);

//            await service.RejectBreed(1);

//            Assert.True(breedsList.First().IsRejected);
//            Assert.False(breedsList.First().IsUnderReview);
//        }

//        [Fact]
//        public async Task RejectingNewBreedReturnsBreedName()
//        {
//            var breedsList = new List<Breed>();
//            var breedsMockRepo = new Mock<IDeletableEntityRepository<Breed>>();
//            breedsMockRepo.Setup(x => x.All()).Returns(breedsList.AsQueryable());
//            breedsMockRepo.Setup(x => x.AddAsync(It.IsAny<Breed>())).Callback(
//                (Breed breed) => breedsList.Add(breed));

//            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
//            Mock<IDeletableEntityRepository<Organiser>> organisersMockRepo = OrganisersMock();
//            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
//            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JugeAppFormsMock();
//            Mock<IDeletableEntityRepository<ApplicationUser>> usersMockRepo = UsersMock();
//            SendGridEmailSender mailSender = new SendGridEmailSender("key");

//            var service = new DashboardService(
//                organisersMockRepo.Object,
//                competitionsMockRepo.Object,
//                breedsMockRepo.Object,
//                appFormsMockRepo.Object,
//                usersMockRepo.Object,
//                dogsMockRepo.Object,
//                mailSender);

//            var firstBreed = new Breed
//            {
//                Id = 1,
//                Name = "Poodle",
//                IsUnderReview = true,
//            };
//            breedsList.Add(firstBreed);

//            var name = await service.RejectBreed(1);

//            Assert.Equal("Poodle", name);
//        }

//        [Fact]
//        public void GettingAllFormsReturnsJudgeAppFormsUnderReview()
//        {
//            var judgeAppFormsList = new List<JudgeApplicationForm>();
//            var judgeFromsMockRepo = new Mock<IDeletableEntityRepository<JudgeApplicationForm>>();
//            judgeFromsMockRepo.Setup(x => x.All()).Returns(judgeAppFormsList.AsQueryable());
//            judgeFromsMockRepo.Setup(x => x.AddAsync(It.IsAny<JudgeApplicationForm>())).Callback(
//                (JudgeApplicationForm judgeAppForm) => judgeAppFormsList.Add(judgeAppForm));

//            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
//            Mock<IDeletableEntityRepository<Organiser>> organisersMockRepo = OrganisersMock();
//            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
//            Mock<IDeletableEntityRepository<Breed>> breedsMockRepo = BreedsMock();
//            Mock<IDeletableEntityRepository<ApplicationUser>> usersMockRepo = UsersMock();
//            SendGridEmailSender mailSender = new SendGridEmailSender("key");

//            var service = new DashboardService(
//                organisersMockRepo.Object,
//                competitionsMockRepo.Object,
//                breedsMockRepo.Object,
//                judgeFromsMockRepo.Object,
//                usersMockRepo.Object,
//                dogsMockRepo.Object,
//                mailSender);

//            var firstForm = new JudgeApplicationForm
//            {
//                Id = 1,
//                FirstName = "Test1",
//                LastName = "Test2",
//                YearsOfExperience = 5,
//                HasBeenJudgeAssistant = true,
//                NumberOfChampionsOwned = 6,
//                RaisedLitters = 4,
//                JudgeInstituteCertificateUrl = "link",
//                IsUnderReview = false,
//            };

//            var secondForm = new JudgeApplicationForm
//            {
//                Id = 2,
//                FirstName = "Test3",
//                LastName = "Test4",
//                YearsOfExperience = 5,
//                HasBeenJudgeAssistant = true,
//                NumberOfChampionsOwned = 6,
//                RaisedLitters = 4,
//                JudgeInstituteCertificateUrl = "link",
//                IsUnderReview = true,
//            };
//            judgeAppFormsList.Add(firstForm);
//            judgeAppFormsList.Add(secondForm);

//            var data = service.JudgeAppForms();

//            Assert.Equal(1, data.FormsList.Count());
//        }

//        [Fact]
//        public async Task ApprovingApplicationChangesIsUnderReviewAndIsApprovedStatuses()
//        {
//            var judgeAppFormsList = new List<JudgeApplicationForm>();
//            var judgeFromsMockRepo = new Mock<IDeletableEntityRepository<JudgeApplicationForm>>();
//            judgeFromsMockRepo.Setup(x => x.All()).Returns(judgeAppFormsList.AsQueryable());
//            judgeFromsMockRepo.Setup(x => x.AddAsync(It.IsAny<JudgeApplicationForm>())).Callback(
//                (JudgeApplicationForm judgeAppForm) => judgeAppFormsList.Add(judgeAppForm));

//            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
//            Mock<IDeletableEntityRepository<Organiser>> organisersMockRepo = OrganisersMock();
//            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
//            Mock<IDeletableEntityRepository<Breed>> breedsMockRepo = BreedsMock();
//            Mock<IDeletableEntityRepository<ApplicationUser>> usersMockRepo = UsersMock();
//            SendGridEmailSender mailSender = new SendGridEmailSender("key");

//            var service = new DashboardService(
//                organisersMockRepo.Object,
//                competitionsMockRepo.Object,
//                breedsMockRepo.Object,
//                judgeFromsMockRepo.Object,
//                usersMockRepo.Object,
//                dogsMockRepo.Object,
//                mailSender);

//            var firstForm = new JudgeApplicationForm
//            {
//                Id = 1,
//                UserId = "firstId",
//                FirstName = "Test1",
//                LastName = "Test2",
//                YearsOfExperience = 5,
//                HasBeenJudgeAssistant = true,
//                NumberOfChampionsOwned = 6,
//                RaisedLitters = 4,
//                JudgeInstituteCertificateUrl = "link",
//                IsUnderReview = true,
//                IsApproved = false,
//            };
//            judgeAppFormsList.Add(firstForm);

//            await service.ApproveApplication("firstId");

//            Assert.True(judgeAppFormsList.First().IsApproved);
//            Assert.False(judgeAppFormsList.First().IsUnderReview);
//        }

//        [Fact]
//        public async Task ApprovingApplicationReturnsFullNameOfApplicant()
//        {
//            var judgeAppFormsList = new List<JudgeApplicationForm>();
//            var judgeFromsMockRepo = new Mock<IDeletableEntityRepository<JudgeApplicationForm>>();
//            judgeFromsMockRepo.Setup(x => x.All()).Returns(judgeAppFormsList.AsQueryable());
//            judgeFromsMockRepo.Setup(x => x.AddAsync(It.IsAny<JudgeApplicationForm>())).Callback(
//                (JudgeApplicationForm judgeAppForm) => judgeAppFormsList.Add(judgeAppForm));

//            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
//            Mock<IDeletableEntityRepository<Organiser>> organisersMockRepo = OrganisersMock();
//            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
//            Mock<IDeletableEntityRepository<Breed>> breedsMockRepo = BreedsMock();
//            Mock<IDeletableEntityRepository<ApplicationUser>> usersMockRepo = UsersMock();
//            SendGridEmailSender mailSender = new SendGridEmailSender("key");

//            var service = new DashboardService(
//                organisersMockRepo.Object,
//                competitionsMockRepo.Object,
//                breedsMockRepo.Object,
//                judgeFromsMockRepo.Object,
//                usersMockRepo.Object,
//                dogsMockRepo.Object,
//                mailSender);

//            var firstForm = new JudgeApplicationForm
//            {
//                Id = 1,
//                UserId = "firstId",
//                FirstName = "Test1",
//                LastName = "Test2",
//                YearsOfExperience = 5,
//                HasBeenJudgeAssistant = true,
//                NumberOfChampionsOwned = 6,
//                RaisedLitters = 4,
//                JudgeInstituteCertificateUrl = "link",
//                IsUnderReview = true,
//                IsApproved = false,
//            };
//            judgeAppFormsList.Add(firstForm);

//            var data = await service.ApproveApplication("firstId");

//            Assert.Equal("Test1 Test2", data);
//        }

//        [Fact]
//        public async Task SendingEmailApprovalThroughSendGridTest()
//        {
//            var judgeAppFormsList = new List<JudgeApplicationForm>();
//            var judgeFromsMockRepo = new Mock<IDeletableEntityRepository<JudgeApplicationForm>>();
//            judgeFromsMockRepo.Setup(x => x.All()).Returns(judgeAppFormsList.AsQueryable());
//            judgeFromsMockRepo.Setup(x => x.AddAsync(It.IsAny<JudgeApplicationForm>())).Callback(
//                (JudgeApplicationForm judgeAppForm) => judgeAppFormsList.Add(judgeAppForm));

//            var usersList = new List<ApplicationUser>();
//            var usersMockRepo = new Mock<IDeletableEntityRepository<ApplicationUser>>();
//            usersMockRepo.Setup(x => x.All()).Returns(usersList.AsQueryable());
//            usersMockRepo.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback(
//                (ApplicationUser user) => usersList.Add(user));

//            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
//            Mock<IDeletableEntityRepository<Organiser>> organisersMockRepo = OrganisersMock();
//            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
//            Mock<IDeletableEntityRepository<Breed>> breedsMockRepo = BreedsMock();
//            SendGridEmailSender mailSender = new SendGridEmailSender("key");

//            var service = new DashboardService(
//                organisersMockRepo.Object,
//                competitionsMockRepo.Object,
//                breedsMockRepo.Object,
//                judgeFromsMockRepo.Object,
//                usersMockRepo.Object,
//                dogsMockRepo.Object,
//                mailSender);

//            var user = new ApplicationUser
//            {
//                Id = "firstId",
//                Email = "mail@abv.bg",
//            };
//            usersList.Add(user);

//            var firstForm = new JudgeApplicationForm
//            {
//                Id = 1,
//                UserId = "firstId",
//                FirstName = "Test1",
//                LastName = "Test2",
//                YearsOfExperience = 5,
//                HasBeenJudgeAssistant = true,
//                NumberOfChampionsOwned = 6,
//                RaisedLitters = 4,
//                JudgeInstituteCertificateUrl = "link",
//                IsUnderReview = true,
//                IsApproved = false,
//            };
//            judgeAppFormsList.Add(firstForm);

//            var data = await service.SendEmailApproval("firstId");

//            Assert.Null(data);
//        }

//        [Fact]
//        public async Task RejectingApplicationChangesIsUnderReviewAndIsRejectedStatuses()
//        {
//            var judgeAppFormsList = new List<JudgeApplicationForm>();
//            var judgeFromsMockRepo = new Mock<IDeletableEntityRepository<JudgeApplicationForm>>();
//            judgeFromsMockRepo.Setup(x => x.All()).Returns(judgeAppFormsList.AsQueryable());
//            judgeFromsMockRepo.Setup(x => x.AddAsync(It.IsAny<JudgeApplicationForm>())).Callback(
//                (JudgeApplicationForm judgeAppForm) => judgeAppFormsList.Add(judgeAppForm));

//            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
//            Mock<IDeletableEntityRepository<Organiser>> organisersMockRepo = OrganisersMock();
//            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
//            Mock<IDeletableEntityRepository<Breed>> breedsMockRepo = BreedsMock();
//            Mock<IDeletableEntityRepository<ApplicationUser>> usersMockRepo = UsersMock();
//            SendGridEmailSender mailSender = new SendGridEmailSender("key");

//            var service = new DashboardService(
//                organisersMockRepo.Object,
//                competitionsMockRepo.Object,
//                breedsMockRepo.Object,
//                judgeFromsMockRepo.Object,
//                usersMockRepo.Object,
//                dogsMockRepo.Object,
//                mailSender);

//            var firstForm = new JudgeApplicationForm
//            {
//                Id = 1,
//                UserId = "firstId",
//                FirstName = "Test1",
//                LastName = "Test2",
//                YearsOfExperience = 5,
//                HasBeenJudgeAssistant = true,
//                NumberOfChampionsOwned = 6,
//                RaisedLitters = 4,
//                JudgeInstituteCertificateUrl = "link",
//                IsUnderReview = true,
//                IsRejected = false,
//            };
//            judgeAppFormsList.Add(firstForm);

//            await service.RejectApplication("firstId", "notes");

//            Assert.True(judgeAppFormsList.First().IsRejected);
//            Assert.False(judgeAppFormsList.First().IsUnderReview);
//        }

//        [Fact]
//        public async Task RejectingApplicationReturnsFullNameOfApplicant()
//        {
//            var judgeAppFormsList = new List<JudgeApplicationForm>();
//            var judgeFromsMockRepo = new Mock<IDeletableEntityRepository<JudgeApplicationForm>>();
//            judgeFromsMockRepo.Setup(x => x.All()).Returns(judgeAppFormsList.AsQueryable());
//            judgeFromsMockRepo.Setup(x => x.AddAsync(It.IsAny<JudgeApplicationForm>())).Callback(
//                (JudgeApplicationForm judgeAppForm) => judgeAppFormsList.Add(judgeAppForm));

//            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
//            Mock<IDeletableEntityRepository<Organiser>> organisersMockRepo = OrganisersMock();
//            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
//            Mock<IDeletableEntityRepository<Breed>> breedsMockRepo = BreedsMock();
//            Mock<IDeletableEntityRepository<ApplicationUser>> usersMockRepo = UsersMock();
//            SendGridEmailSender mailSender = new SendGridEmailSender("key");

//            var service = new DashboardService(
//                organisersMockRepo.Object,
//                competitionsMockRepo.Object,
//                breedsMockRepo.Object,
//                judgeFromsMockRepo.Object,
//                usersMockRepo.Object,
//                dogsMockRepo.Object,
//                mailSender);

//            var firstForm = new JudgeApplicationForm
//            {
//                Id = 1,
//                UserId = "firstId",
//                FirstName = "Test1",
//                LastName = "Test2",
//                YearsOfExperience = 5,
//                HasBeenJudgeAssistant = true,
//                NumberOfChampionsOwned = 6,
//                RaisedLitters = 4,
//                JudgeInstituteCertificateUrl = "link",
//                IsUnderReview = true,
//                IsRejected = false,
//            };
//            judgeAppFormsList.Add(firstForm);

//            var data = await service.RejectApplication("firstId", "notes");

//            Assert.Equal("Test1 Test2", data);
//        }

//        [Fact]
//        public async Task SendingEmailRejectionThroughSendGridTest()
//        {
//            var judgeAppFormsList = new List<JudgeApplicationForm>();
//            var judgeFromsMockRepo = new Mock<IDeletableEntityRepository<JudgeApplicationForm>>();
//            judgeFromsMockRepo.Setup(x => x.All()).Returns(judgeAppFormsList.AsQueryable());
//            judgeFromsMockRepo.Setup(x => x.AddAsync(It.IsAny<JudgeApplicationForm>())).Callback(
//                (JudgeApplicationForm judgeAppForm) => judgeAppFormsList.Add(judgeAppForm));

//            var usersList = new List<ApplicationUser>();
//            var usersMockRepo = new Mock<IDeletableEntityRepository<ApplicationUser>>();
//            usersMockRepo.Setup(x => x.All()).Returns(usersList.AsQueryable());
//            usersMockRepo.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback(
//                (ApplicationUser user) => usersList.Add(user));

//            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
//            Mock<IDeletableEntityRepository<Organiser>> organisersMockRepo = OrganisersMock();
//            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
//            Mock<IDeletableEntityRepository<Breed>> breedsMockRepo = BreedsMock();
//            SendGridEmailSender mailSender = new SendGridEmailSender("key");

//            var service = new DashboardService(
//                organisersMockRepo.Object,
//                competitionsMockRepo.Object,
//                breedsMockRepo.Object,
//                judgeFromsMockRepo.Object,
//                usersMockRepo.Object,
//                dogsMockRepo.Object,
//                mailSender);

//            var user = new ApplicationUser
//            {
//                Id = "firstId",
//                Email = "mail@abv.bg",
//            };
//            usersList.Add(user);

//            var firstForm = new JudgeApplicationForm
//            {
//                Id = 1,
//                UserId = "firstId",
//                FirstName = "Test1",
//                LastName = "Test2",
//                YearsOfExperience = 5,
//                HasBeenJudgeAssistant = true,
//                NumberOfChampionsOwned = 6,
//                RaisedLitters = 4,
//                JudgeInstituteCertificateUrl = "link",
//                IsUnderReview = true,
//                IsRejected = false,
//            };
//            judgeAppFormsList.Add(firstForm);

//            var data = await service.SendEmailRejection("firstId");

//            Assert.Null(data);
//        }

//        [Fact]
//        public void BreedsDataReturnsTotalCountOfDogsPerBreed()
//        {
//            var breedsList = new List<Breed>();
//            var breedsMockRepo = new Mock<IDeletableEntityRepository<Breed>>();
//            breedsMockRepo.Setup(x => x.All()).Returns(breedsList.AsQueryable());
//            breedsMockRepo.Setup(x => x.AddAsync(It.IsAny<Breed>())).Callback(
//                (Breed breed) => breedsList.Add(breed));

//            var dogsList = new List<Dog>();
//            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
//            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
//            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
//                (Dog dog) => dogsList.Add(dog));

//            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
//            Mock<IDeletableEntityRepository<Organiser>> organisersMockRepo = OrganisersMock();
//            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JugeAppFormsMock();
//            Mock<IDeletableEntityRepository<ApplicationUser>> usersMockRepo = UsersMock();
//            SendGridEmailSender mailSender = new SendGridEmailSender("key");

//            var service = new DashboardService(
//                organisersMockRepo.Object,
//                competitionsMockRepo.Object,
//                breedsMockRepo.Object,
//                appFormsMockRepo.Object,
//                usersMockRepo.Object,
//                dogsMockRepo.Object,
//                mailSender);

//            var firstBreed = new Breed
//            {
//                Id = 1,
//                Name = "Poodle",
//                IsApproved = true,
//            };
//            var secondBreed = new Breed
//            {
//                Id = 2,
//                Name = "Bulldog",
//                IsApproved = true,
//            };

//            var firstDog = new Dog
//            {
//                Id = 1,
//                BreedId = 1,
//                Breed = firstBreed,
//                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
//            };
//            firstBreed.BreedDogs.Add(firstDog);

//            var secondDog = new Dog
//            {
//                Id = 2,
//                BreedId = 1,
//                Breed = firstBreed,
//                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
//            };
//            firstBreed.BreedDogs.Add(secondDog);

//            var thirdDog = new Dog
//            {
//                Id = 3,
//                BreedId = 1,
//                Breed = firstBreed,
//                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
//            };
//            firstBreed.BreedDogs.Add(thirdDog);

//            var fourthDog = new Dog
//            {
//                Id = 4,
//                BreedId = 2,
//                Breed = secondBreed,
//                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
//            };
//            secondBreed.BreedDogs.Add(fourthDog);

//            breedsList.Add(firstBreed);
//            breedsList.Add(secondBreed);

//            var data = service.AllBreedsForReport();

//            Assert.Equal(3, data.First().TotalDogsOfBreed);
//            Assert.Equal(1, data.Last().TotalDogsOfBreed);
//        }

//        [Fact]
//        public void BreedsDataReturnsCountOfMaleAndFemaleDogsPerBreed()
//        {
//            var breedsList = new List<Breed>();
//            var breedsMockRepo = new Mock<IDeletableEntityRepository<Breed>>();
//            breedsMockRepo.Setup(x => x.All()).Returns(breedsList.AsQueryable());
//            breedsMockRepo.Setup(x => x.AddAsync(It.IsAny<Breed>())).Callback(
//                (Breed breed) => breedsList.Add(breed));

//            var dogsList = new List<Dog>();
//            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
//            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
//            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
//                (Dog dog) => dogsList.Add(dog));

//            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
//            Mock<IDeletableEntityRepository<Organiser>> organisersMockRepo = OrganisersMock();
//            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JugeAppFormsMock();
//            Mock<IDeletableEntityRepository<ApplicationUser>> usersMockRepo = UsersMock();
//            SendGridEmailSender mailSender = new SendGridEmailSender("key");

//            var service = new DashboardService(
//                organisersMockRepo.Object,
//                competitionsMockRepo.Object,
//                breedsMockRepo.Object,
//                appFormsMockRepo.Object,
//                usersMockRepo.Object,
//                dogsMockRepo.Object,
//                mailSender);

//            var firstBreed = new Breed
//            {
//                Id = 1,
//                Name = "Poodle",
//                IsApproved = true,
//            };
//            var secondBreed = new Breed
//            {
//                Id = 2,
//                Name = "Bulldog",
//                IsApproved = true,
//            };

//            var firstDog = new Dog
//            {
//                Id = 1,
//                BreedId = 1,
//                Breed = firstBreed,
//                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
//            };
//            firstBreed.BreedDogs.Add(firstDog);

//            var secondDog = new Dog
//            {
//                Id = 2,
//                BreedId = 1,
//                Breed = firstBreed,
//                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
//            };
//            firstBreed.BreedDogs.Add(secondDog);

//            var thirdDog = new Dog
//            {
//                Id = 3,
//                BreedId = 1,
//                Breed = firstBreed,
//                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
//            };
//            firstBreed.BreedDogs.Add(thirdDog);

//            var fourthDog = new Dog
//            {
//                Id = 4,
//                BreedId = 2,
//                Breed = secondBreed,
//                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
//            };
//            secondBreed.BreedDogs.Add(fourthDog);

//            breedsList.Add(firstBreed);
//            breedsList.Add(secondBreed);

//            dogsList.Add(firstDog);
//            dogsList.Add(secondDog);
//            dogsList.Add(thirdDog);
//            dogsList.Add(fourthDog);

//            var data = service.AllBreedsForReport();

//            Assert.Equal(2, data.First().MaleDogsOfBreed);
//            Assert.Equal(1, data.First().FemaleDogsOfBreed);
//            Assert.Equal(1, data.Last().MaleDogsOfBreed);
//            Assert.Equal(0, data.Last().FemaleDogsOfBreed);
//        }

//        [Fact]
//        public void FullReportOfDogsCountAndGenderDivisionPerBreedWorksCorrectly()
//        {
//            var breedsList = new List<Breed>();
//            var breedsMockRepo = new Mock<IDeletableEntityRepository<Breed>>();
//            breedsMockRepo.Setup(x => x.All()).Returns(breedsList.AsQueryable());
//            breedsMockRepo.Setup(x => x.AddAsync(It.IsAny<Breed>())).Callback(
//                (Breed breed) => breedsList.Add(breed));

//            var dogsList = new List<Dog>();
//            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
//            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
//            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
//                (Dog dog) => dogsList.Add(dog));

//            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
//            Mock<IDeletableEntityRepository<Organiser>> organisersMockRepo = OrganisersMock();
//            Mock<IDeletableEntityRepository<JudgeApplicationForm>> appFormsMockRepo = JugeAppFormsMock();
//            Mock<IDeletableEntityRepository<ApplicationUser>> usersMockRepo = UsersMock();
//            SendGridEmailSender mailSender = new SendGridEmailSender("key");

//            var service = new DashboardService(
//                organisersMockRepo.Object,
//                competitionsMockRepo.Object,
//                breedsMockRepo.Object,
//                appFormsMockRepo.Object,
//                usersMockRepo.Object,
//                dogsMockRepo.Object,
//                mailSender);

//            var firstBreed = new Breed
//            {
//                Id = 1,
//                Name = "Poodle",
//                IsApproved = true,
//            };
//            var secondBreed = new Breed
//            {
//                Id = 2,
//                Name = "Bulldog",
//                IsApproved = true,
//            };

//            var firstDog = new Dog
//            {
//                Id = 1,
//                BreedId = 1,
//                Breed = firstBreed,
//                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
//            };
//            firstBreed.BreedDogs.Add(firstDog);

//            var secondDog = new Dog
//            {
//                Id = 2,
//                BreedId = 1,
//                Breed = firstBreed,
//                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
//            };
//            firstBreed.BreedDogs.Add(secondDog);

//            var thirdDog = new Dog
//            {
//                Id = 3,
//                BreedId = 1,
//                Breed = firstBreed,
//                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
//            };
//            firstBreed.BreedDogs.Add(thirdDog);

//            var fourthDog = new Dog
//            {
//                Id = 4,
//                BreedId = 2,
//                Breed = secondBreed,
//                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
//            };
//            secondBreed.BreedDogs.Add(fourthDog);

//            breedsList.Add(firstBreed);
//            breedsList.Add(secondBreed);

//            dogsList.Add(firstDog);
//            dogsList.Add(secondDog);
//            dogsList.Add(thirdDog);
//            dogsList.Add(fourthDog);

//            var data = service.GetReportData();

//            Assert.Equal(2, data.GetBreedsData.First().MaleDogsOfBreed);
//            Assert.Equal(1, data.GetBreedsData.First().FemaleDogsOfBreed);
//            Assert.Equal(1, data.GetBreedsData.Last().MaleDogsOfBreed);
//            Assert.Equal(0, data.GetBreedsData.Last().FemaleDogsOfBreed);
//        }

//        private static Mock<IDeletableEntityRepository<JudgeApplicationForm>> JugeAppFormsMock()
//        {
//            var judgeAppFormsList = new List<JudgeApplicationForm>();
//            var judgeFromsMockRepo = new Mock<IDeletableEntityRepository<JudgeApplicationForm>>();
//            judgeFromsMockRepo.Setup(x => x.All()).Returns(judgeAppFormsList.AsQueryable());
//            judgeFromsMockRepo.Setup(x => x.AddAsync(It.IsAny<JudgeApplicationForm>())).Callback(
//                (JudgeApplicationForm judgeAppForm) => judgeAppFormsList.Add(judgeAppForm));
//            return judgeFromsMockRepo;
//        }

//        private static Mock<IDeletableEntityRepository<Dog>> DogsMock()
//        {
//            var dogsList = new List<Dog>();
//            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
//            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
//            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
//                (Dog dog) => dogsList.Add(dog));
//            return dogsMockRepo;
//        }

//        private static Mock<IDeletableEntityRepository<Competition>> CompetitionsMock()
//        {
//            var competitionsList = new List<Competition>();
//            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
//            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
//            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
//                (Competition competition) => competitionsList.Add(competition));
//            return competitionsMockRepo;
//        }

//        private static Mock<IDeletableEntityRepository<Breed>> BreedsMock()
//        {
//            var breedsList = new List<Breed>();
//            var breedsMockRepo = new Mock<IDeletableEntityRepository<Breed>>();
//            breedsMockRepo.Setup(x => x.All()).Returns(breedsList.AsQueryable());
//            breedsMockRepo.Setup(x => x.AddAsync(It.IsAny<Breed>())).Callback(
//                (Breed breed) => breedsList.Add(breed));
//            return breedsMockRepo;
//        }

//        private static Mock<IDeletableEntityRepository<Organiser>> OrganisersMock()
//        {
//            var organisersList = new List<Organiser>();
//            var organisersMockRepo = new Mock<IDeletableEntityRepository<Organiser>>();
//            organisersMockRepo.Setup(x => x.All()).Returns(organisersList.AsQueryable());
//            organisersMockRepo.Setup(x => x.AddAsync(It.IsAny<Organiser>())).Callback(
//                (Organiser organiser) => organisersList.Add(organiser));
//            return organisersMockRepo;
//        }

//        private static Mock<IDeletableEntityRepository<ApplicationUser>> UsersMock()
//        {
//            var usersList = new List<ApplicationUser>();
//            var usersMockRepo = new Mock<IDeletableEntityRepository<ApplicationUser>>();
//            usersMockRepo.Setup(x => x.All()).Returns(usersList.AsQueryable());
//            usersMockRepo.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback(
//                (ApplicationUser user) => usersList.Add(user));
//            return usersMockRepo;
//        }
//    }
//}
