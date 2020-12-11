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

        [Fact]
        public void GetAllDogsOfSingleUser()
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

            var firstBreed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };
            var secondBreed = new Breed
            {
                Id = 2,
                Name = "Bulldog",
            };

            var firstCompetition = new Competition
            {
                Id = 1,
                CompetitionEnd = DateTime.UtcNow,
            };
            var secondCompetition = new Competition
            {
                Id = 2,
                CompetitionEnd = DateTime.UtcNow,
            };

            var firstDog = new Dog
            {
                Id = 1,
                Name = "Name1",
                BreedId = 1,
                Breed = firstBreed,
                IsSpayedOrNeutered = true,
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
                UserId = "firstUser",
            };
            firstDog.DogImages.Add(new DogImage
            {
                Id = "123",
                DogId = 1,
                Dog = firstDog,
                Extension = "jpg",
            });
            firstDog.DogsCompetiotions.Add(new DogCompetition
            {
                DogId = 1,
                Dog = firstDog,
                CompetitionId = 1,
                Competition = firstCompetition,
            });
            dogsList.Add(firstDog);

            var secondDog = new Dog
            {
                Id = 2,
                Name = "Name2",
                BreedId = 1,
                Breed = secondBreed,
                IsSpayedOrNeutered = false,
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
                UserId = "secondUser",
            };
            secondDog.DogImages.Add(new DogImage
            {
                Id = "345",
                DogId = 2,
                Dog = secondDog,
                Extension = "jpg",
            });
            secondDog.DogsCompetiotions.Add(new DogCompetition
            {
                DogId = 2,
                Dog = secondDog,
                CompetitionId = 2,
                Competition = secondCompetition,
            });
            dogsList.Add(secondDog);

            var thirdDog = new Dog
            {
                Id = 3,
                Name = "Name2",
                BreedId = 1,
                Breed = secondBreed,
                IsSpayedOrNeutered = false,
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
                UserId = "firstUser",
            };
            thirdDog.DogImages.Add(new DogImage
            {
                Id = "678",
                DogId = 3,
                Dog = thirdDog,
                Extension = "jpg",
            });
            thirdDog.DogsCompetiotions.Add(new DogCompetition
            {
                DogId = 3,
                Dog = thirdDog,
                CompetitionId = 2,
                Competition = secondCompetition,
            });
            dogsList.Add(thirdDog);

            var result = service.GetPossibleDogApplicants("firstUser").ToList();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GivenDogIsAddedToGivenCompetitionReturnsTrue()
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

            var firstCompetition = new Competition
            {
                Id = 1,
                CompetitionEnd = DateTime.UtcNow,
            };

            var firstDog = new Dog
            {
                Id = 1,
                Name = "Name1",
            };
            firstDog.DogsCompetiotions.Add(new DogCompetition
            {
                DogId = 1,
                Dog = firstDog,
                CompetitionId = 1,
                Competition = firstCompetition,
            });
            dogsList.Add(firstDog);

            Assert.True(service.IsDogAddedToCompetition(1, 1));
        }

        [Fact]
        public void DogIdGivenReturnsTheDog()
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

            var firstDog = new Dog
            {
                Id = 1,
                Name = "Name1",
            };
            dogsList.Add(firstDog);

            var foundDog = service.GetDogById(1);

            Assert.Equal(1, foundDog.Id);
        }

        [Fact]
        public void CompetitionIdProvidedReturnsTheCompetition()
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

            var competition = new Competition
            {
                Id = 1,
            };
            competitionsList.Add(competition);

            var foundCompetition = service.GetCompetitionById(1);

            Assert.Equal(1, foundCompetition.Id);
        }

        [Fact]
        public void CompetitionIdReturnsTheFemaleWinnersOfTheCompetitionOrderedDescending()
        {
            var dogsCompetitionsList = new List<DogCompetition>();
            var dogCompetitionsMockRepo = new Mock<IRepository<DogCompetition>>();
            dogCompetitionsMockRepo.Setup(x => x.All()).Returns(dogsCompetitionsList.AsQueryable());
            dogCompetitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<DogCompetition>())).Callback(
                (DogCompetition dogCompetition) => dogsCompetitionsList.Add(dogCompetition));

            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();

            var service = new CompetitionsHelpService(
                dogsMockRepo.Object,
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object);

            var competition = new Competition
            {
                Id = 1,
            };

            var firstFemaleDog = new Dog
            {
                Id = 1,
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
            };
            var secondFemaleDog = new Dog
            {
                Id = 2,
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
            };
            var thirdFemaleDog = new Dog
            {
                Id = 3,
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
            };
            var maleDog = new Dog
            {
                Id = 4,
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
            };
            var firstEvaluationForm = new EvaluationForm
            {
                Id = 1,
                CompetitionId = 1,
                Competitions = competition,
                DogId = 1,
                Dog = firstFemaleDog,
                TotalPoints = 25,
            };
            var secondEvaluationForm = new EvaluationForm
            {
                Id = 2,
                CompetitionId = 1,
                Competitions = competition,
                DogId = 1,
                Dog = firstFemaleDog,
                TotalPoints = 30,
            };
            var thirdEvaluationForm = new EvaluationForm
            {
                Id = 3,
                Competitions = competition,
                CompetitionId = 1,
                DogId = 2,
                Dog = secondFemaleDog,
                TotalPoints = 45,
            };

            var fourthEvaluationForm = new EvaluationForm
            {
                Id = 4,
                Competitions = competition,
                CompetitionId = 1,
                DogId = 3,
                Dog = thirdFemaleDog,
                TotalPoints = 60,
            };
            firstFemaleDog.EvaluationForms.Add(firstEvaluationForm);
            firstFemaleDog.EvaluationForms.Add(secondEvaluationForm);

            secondFemaleDog.EvaluationForms.Add(thirdEvaluationForm);

            thirdFemaleDog.EvaluationForms.Add(fourthEvaluationForm);

            dogsCompetitionsList.Add(
                new DogCompetition
                {
                    DogId = 1,
                    Dog = firstFemaleDog,
                    CompetitionId = 1,
                    Competition = competition,
                });
            dogsCompetitionsList.Add(
                new DogCompetition
                {
                    DogId = 2,
                    Dog = secondFemaleDog,
                    CompetitionId = 1,
                    Competition = competition,
                });
            dogsCompetitionsList.Add(
                new DogCompetition
                {
                    DogId = 3,
                    Dog = thirdFemaleDog,
                    CompetitionId = 1,
                    Competition = competition,
                });
            dogsCompetitionsList.Add(
                new DogCompetition
                {
                    DogId = 4,
                    Dog = maleDog,
                    CompetitionId = 1,
                    Competition = competition,
                });
            var dogsData = service.FemaleWinners(1);

            Assert.Equal(3, dogsData.Count());
            Assert.Equal(3, dogsData.First().Id);
        }

        [Fact]
        public void CompetitionIdReturnsTheMaleWinnersOfTheCompetitionOrderedDescending()
        {
            var dogsCompetitionsList = new List<DogCompetition>();
            var dogCompetitionsMockRepo = new Mock<IRepository<DogCompetition>>();
            dogCompetitionsMockRepo.Setup(x => x.All()).Returns(dogsCompetitionsList.AsQueryable());
            dogCompetitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<DogCompetition>())).Callback(
                (DogCompetition dogCompetition) => dogsCompetitionsList.Add(dogCompetition));

            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();

            var service = new CompetitionsHelpService(
                dogsMockRepo.Object,
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object);

            var competition = new Competition
            {
                Id = 1,
            };

            var firstMaleDog = new Dog
            {
                Id = 1,
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
            };
            var secondMaleDog = new Dog
            {
                Id = 2,
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
            };
            var thirdMaleDog = new Dog
            {
                Id = 3,
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
            };
            var femaleDog = new Dog
            {
                Id = 4,
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
            };
            var firstEvaluationForm = new EvaluationForm
            {
                Id = 1,
                CompetitionId = 1,
                Competitions = competition,
                DogId = 1,
                Dog = firstMaleDog,
                TotalPoints = 25,
            };
            var secondEvaluationForm = new EvaluationForm
            {
                Id = 2,
                CompetitionId = 1,
                Competitions = competition,
                DogId = 2,
                Dog = secondMaleDog,
                TotalPoints = 30,
            };
            var thirdEvaluationForm = new EvaluationForm
            {
                Id = 3,
                Competitions = competition,
                CompetitionId = 1,
                DogId = 2,
                Dog = secondMaleDog,
                TotalPoints = 45,
            };

            var fourthEvaluationForm = new EvaluationForm
            {
                Id = 4,
                Competitions = competition,
                CompetitionId = 1,
                DogId = 3,
                Dog = femaleDog,
                TotalPoints = 60,
            };
            firstMaleDog.EvaluationForms.Add(firstEvaluationForm);

            secondMaleDog.EvaluationForms.Add(secondEvaluationForm);
            secondMaleDog.EvaluationForms.Add(thirdEvaluationForm);

            thirdMaleDog.EvaluationForms.Add(fourthEvaluationForm);

            dogsCompetitionsList.Add(
                new DogCompetition
                {
                    DogId = 1,
                    Dog = firstMaleDog,
                    CompetitionId = 1,
                    Competition = competition,
                });
            dogsCompetitionsList.Add(
                new DogCompetition
                {
                    DogId = 2,
                    Dog = secondMaleDog,
                    CompetitionId = 1,
                    Competition = competition,
                });
            dogsCompetitionsList.Add(
                new DogCompetition
                {
                    DogId = 3,
                    Dog = thirdMaleDog,
                    CompetitionId = 1,
                    Competition = competition,
                });
            dogsCompetitionsList.Add(
                new DogCompetition
                {
                    DogId = 4,
                    Dog = femaleDog,
                    CompetitionId = 1,
                    Competition = competition,
                });
            var dogsData = service.MaleWinners(1);

            Assert.Equal(3, dogsData.Count());
            Assert.Equal(2, dogsData.First().Id);
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
