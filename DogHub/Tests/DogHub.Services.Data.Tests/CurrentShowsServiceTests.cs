namespace DogHub.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models;
    using DogHub.Data.Models.Competitions;
    using DogHub.Data.Models.Dogs;
    using DogHub.Data.Models.EvaluationForms;
    using Moq;
    using Xunit;

    public class CurrentShowsServiceTests
    {
        [Fact]
        public void CompetitionIdReturnsFullDataOfCompetition()
        {
            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            var service = new CurrentShowsService(competitionsMockRepo.Object);

            var breed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };

            var competitionOne = new Competition
            {
                Id = 1,
                Name = "Test",
                BreedId = 1,
                Breed = breed,
                CompetitionStart = DateTime.UtcNow,
                CompetitionEnd = DateTime.UtcNow.AddDays(5),
            };

            var competitionTwo = new Competition
            {
                Id = 2,
                Name = "Test2",
                BreedId = 1,
                Breed = breed,
                CompetitionStart = DateTime.UtcNow,
                CompetitionEnd = DateTime.UtcNow.AddDays(3),
            };
            breed.BreedCompetitions.Add(competitionOne);
            breed.BreedCompetitions.Add(competitionTwo);

            var image = new DogImage
            {
                Id = "image",
                Extension = "jpg",
            };

            var dog = new Dog
            {
                Id = 1,
                Name = "Test Dog",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
            };
            dog.DogsCompetiotions.Add(new DogCompetition
            {
                DogId = 1,
                Dog = dog,
                CompetitionId = 1,
                Competition = competitionOne,
            });
            dog.DogImages.Add(image);

            var firstEvaluationForm = new EvaluationForm
            {
                DogId = 1,
                Dog = dog,
                CompetitionId = 1,
                TotalPoints = 25,
            };
            var secondEvaluationForm = new EvaluationForm
            {
                DogId = 1,
                Dog = dog,
                CompetitionId = 1,
                TotalPoints = 30,
            };
            var thirdEvaluationForm = new EvaluationForm
            {
                DogId = 1,
                Dog = dog,
                CompetitionId = 2,
                TotalPoints = 10,
            };

            dog.EvaluationForms.Add(firstEvaluationForm);
            dog.EvaluationForms.Add(secondEvaluationForm);
            dog.EvaluationForms.Add(thirdEvaluationForm);
            competitionOne.EvaluationForms.Add(firstEvaluationForm);
            competitionOne.EvaluationForms.Add(secondEvaluationForm);
            competitionTwo.EvaluationForms.Add(thirdEvaluationForm);

            competitionOne.DogsCompetitions.Add(new DogCompetition
            {
                DogId = 1,
                Dog = dog,
                CompetitionId = 1,
                Competition = competitionOne,
            });
            competitionTwo.DogsCompetitions.Add(new DogCompetition
            {
                DogId = 1,
                Dog = dog,
                CompetitionId = 2,
                Competition = competitionTwo,
            });

            competitionsList.Add(competitionOne);
            competitionsList.Add(competitionTwo);

            var result = service.FullDataOfCurrentShow(1);

            Assert.Equal(1, result.CompetitionId);
            Assert.Equal(1, result.CompetitorDogs.Count());
            Assert.Equal(55, result.CompetitorDogs.FirstOrDefault().CurrentTotalPoints);
        }

        [Fact]
        public void GetFullDataOfShowReturnsNullIfShowIsNotInProgress()
        {
            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            var service = new CurrentShowsService(competitionsMockRepo.Object);

            var competition = new Competition
            {
                Id = 1,
                Name = "Test",
                CompetitionStart = DateTime.UtcNow,
                CompetitionEnd = DateTime.UtcNow.AddHours(1),
            };

            competitionsList.Add(competition);

            Assert.Null(service.GetCurrentShowData());
        }

        [Fact]
        public void GetShowInProgressReturnsCurrentShowFullData()
        {
            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            var service = new CurrentShowsService(competitionsMockRepo.Object);

            var competition = new Competition
            {
                Id = 1,
                Name = "Test",
                CompetitionStart = DateTime.UtcNow,
                CompetitionEnd = DateTime.UtcNow.AddDays(1),
            };

            competitionsList.Add(competition);

            var data = service.GetCurrentShowData();

            Assert.Equal(1, data.CompetitionId);
            Assert.Equal("Test", data.CompetitionName);
        }
    }
}
