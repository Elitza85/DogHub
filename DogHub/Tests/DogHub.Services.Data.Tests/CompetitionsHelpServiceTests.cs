using DogHub.Data.Common.Repositories;
using DogHub.Data.Models;
using DogHub.Data.Models.Competitions;
using DogHub.Data.Models.Dogs;
using DogHub.Web.ViewModels.Dogs;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DogHub.Services.Data.Tests
{
    public class CompetitionsHelpServiceTests
    {
        [Fact]
        public void GivenCompetitionIdReturnsTheCompetitionBreed()
        {
            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
            Mock<IRepository<DogCompetition>> dogCompetitionsMockRepo = DogsCompetitionsMock();

            var service = new CompetitionsHelpService(
                dogsMockRepo.Object,
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object);

            var breed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };

            var competition = new Competition
            {
                Id = 1,
                BreedId = breed.Id,
                Breed = breed,
            };
            competitionsList.Add(competition);

            var breedName = service.GetCompetitionRequiredBreed(1);

            Assert.Equal("Poodle", breedName);
        }

        [Fact]
        public void GivenDogIdReturnsTheDogBreed()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IRepository<DogCompetition>> dogCompetitionsMockRepo = DogsCompetitionsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();

            var service = new CompetitionsHelpService(
                dogsMockRepo.Object,
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object);

            var breed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };

            var dog = new Dog
            {
                Id = 1,
                BreedId = breed.Id,
                Breed = breed,
            };
            dogsList.Add(dog);

            var breedName = service.GetDogBreed(1);

            Assert.Equal("Poodle", breedName);
        }

        [Fact]
        public void GivenDogIdReturnsTrueIfDogIsSPayedOrNeutered()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IRepository<DogCompetition>> dogCompetitionsMockRepo = DogsCompetitionsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();

            var service = new CompetitionsHelpService(
                dogsMockRepo.Object,
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object);

            var dog = new Dog
            {
                Id = 1,
                IsSpayedOrNeutered = true,
            };
            dogsList.Add(dog);

            Assert.True(service.IsDogSpayedOrNeutered(1));
        }

        

        private static Mock<IRepository<DogCompetition>> DogsCompetitionsMock()
        {
            var dogsCompetitionsList = new List<DogCompetition>();
            var dogCompetitionsMockRepo = new Mock<IRepository<DogCompetition>>();
            dogCompetitionsMockRepo.Setup(x => x.All()).Returns(dogsCompetitionsList.AsQueryable());
            dogCompetitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<DogCompetition>())).Callback(
                (DogCompetition dogCompetition) => dogsCompetitionsList.Add(dogCompetition));
            return dogCompetitionsMockRepo;
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
