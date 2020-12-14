﻿using DogHub.Data.Common.Repositories;
using DogHub.Data.Models.CommonForms;
using DogHub.Data.Models.Competitions;
using DogHub.Data.Models.EvaluationForms;
using DogHub.Web.ViewModels.Judges;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DogHub.Services.Data.Tests
{
    public class JudgesServiceTests
    {
        //[Fact]
        //public void AllJudgesWithDetailsReturnedInList()
        //{
        //    var appFormsList = new List<JudgeApplicationForm>();
        //    var appFormsMockRepo = new Mock<IDeletableEntityRepository<JudgeApplicationForm>>();
        //    appFormsMockRepo.Setup(x => x.All()).Returns(appFormsList.AsQueryable());
        //    appFormsMockRepo.Setup(x => x.AddAsync(It.IsAny<JudgeApplicationForm>())).Callback(
        //        (JudgeApplicationForm appFrom) => appFormsList.Add(appFrom));

        //    Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();

        //    var service = new JudgesService(
        //        appFormsMockRepo.Object,
        //        competitionsMockRepo.Object);

        //    var image = new JudgeImage
        //    {
        //        Id = "image",
        //        Extension = "jpg",
        //    };
        //    var firstJudgeForm = new JudgeApplicationForm
        //    {
        //        FirstName = "Test11",
        //        LastName = "Test12",
        //        NumberOfChampionsOwned = 5,
        //        RaisedLitters = 5,
        //        YearsOfExperience = 7,
        //        JudgeImage = image,
        //        SelfDescription = "Description1",
        //        IsApproved = true,
        //    };
        //    var secondJudgeForm = new JudgeApplicationForm
        //    {
        //        FirstName = "Test21",
        //        LastName = "Test22",
        //        NumberOfChampionsOwned = 6,
        //        RaisedLitters = 6,
        //        YearsOfExperience = 10,
        //        JudgeImage = image,
        //        SelfDescription = "Description2",
        //        IsApproved = true,
        //    };
        //    appFormsList.Add(firstJudgeForm);
        //    appFormsList.Add(secondJudgeForm);

        //    var data = service.JudgeDetails<SingleJudgeViewModel>();

        //    Assert.Equal(2, data.Count());
        //}

        //[Fact]
        //public void OnlyApprovedJudgesListed()
        //{
        //    var appFormsList = new List<JudgeApplicationForm>();
        //    var appFormsMockRepo = new Mock<IDeletableEntityRepository<JudgeApplicationForm>>();
        //    appFormsMockRepo.Setup(x => x.All()).Returns(appFormsList.AsQueryable());
        //    appFormsMockRepo.Setup(x => x.AddAsync(It.IsAny<JudgeApplicationForm>())).Callback(
        //        (JudgeApplicationForm appFrom) => appFormsList.Add(appFrom));

        //    Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();

        //    var service = new JudgesService(
        //        appFormsMockRepo.Object,
        //        competitionsMockRepo.Object);

        //    var image = new JudgeImage
        //    {
        //        Id = "image",
        //        Extension = "jpg",
        //    };
        //    var firstJudgeForm = new JudgeApplicationForm
        //    {
        //        FirstName = "Test11",
        //        LastName = "Test12",
        //        NumberOfChampionsOwned = 5,
        //        RaisedLitters = 5,
        //        YearsOfExperience = 7,
        //        JudgeImage = image,
        //        SelfDescription = "Description1",
        //        IsApproved = false,
        //    };
        //    var secondJudgeForm = new JudgeApplicationForm
        //    {
        //        FirstName = "Test21",
        //        LastName = "Test22",
        //        NumberOfChampionsOwned = 6,
        //        RaisedLitters = 6,
        //        YearsOfExperience = 10,
        //        JudgeImage = image,
        //        SelfDescription = "Description2",
        //        IsApproved = true,
        //    };
        //    var thirdJudgeForm = new JudgeApplicationForm
        //    {
        //        FirstName = "Test31",
        //        LastName = "Test32",
        //        NumberOfChampionsOwned = 7,
        //        RaisedLitters = 7,
        //        YearsOfExperience = 9,
        //        JudgeImage = image,
        //        SelfDescription = "Description3",
        //        IsApproved = true,
        //    };
        //    appFormsList.Add(firstJudgeForm);
        //    appFormsList.Add(secondJudgeForm);
        //    appFormsList.Add(thirdJudgeForm);

        //    var data = service.JudgesList();

        //    Assert.Equal(2, data.JudgesList.Count());
        //}

        [Fact]
        public void CompetitionsWhereUserVotedAsJudgeAreReturned()
        {
            var appFormsList = new List<JudgeApplicationForm>();
            var appFormsMockRepo = new Mock<IDeletableEntityRepository<JudgeApplicationForm>>();
            appFormsMockRepo.Setup(x => x.All()).Returns(appFormsList.AsQueryable());
            appFormsMockRepo.Setup(x => x.AddAsync(It.IsAny<JudgeApplicationForm>())).Callback(
                (JudgeApplicationForm appFrom) => appFormsList.Add(appFrom));

            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

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
                UserId = "firstUser",
                IsApproved = true,
                ApprovalDate = DateTime.UtcNow.AddHours(3),
            };
            appFormsList.Add(firstJudgeForm);
            var firstCompetition = new Competition
            {
                Id = 1,
                Name = "Test",
                CompetitionStart = DateTime.UtcNow,
                CompetitionEnd = DateTime.UtcNow.AddDays(1),
            };
            var secondCompetition = new Competition
            {
                Id = 2,
                Name = "Test2",
                CompetitionStart = DateTime.UtcNow.AddHours(4),
                CompetitionEnd = DateTime.UtcNow.AddDays(4),
            };

            var evaluationForm = new EvaluationForm
            {
                UserId = "firstUser",
            };
            firstCompetition.EvaluationForms.Add(evaluationForm);
            secondCompetition.EvaluationForms.Add(evaluationForm);

            competitionsList.Add(firstCompetition);
            competitionsList.Add(secondCompetition);

            var data = service.VoteInCompetitionsAsJudge("firstUser");

            Assert.Equal(1, data.Count());
            Assert.Equal("Test", data.First().Name);
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