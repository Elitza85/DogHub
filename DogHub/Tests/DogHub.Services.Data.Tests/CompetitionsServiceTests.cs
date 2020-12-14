namespace DogHub.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models;
    using DogHub.Data.Models.Competitions;
    using DogHub.Data.Models.Dogs;
    using DogHub.Data.Models.EvaluationForms;
    using Moq;
    using Xunit;

    public class CompetitionsServiceTests
    {
        [Fact]
        public void GettingDataOfCompleteCompetitionByIdWorksCorrectlyForFemaleDogWinners()
        {
            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            var dogsCompetitionsList = new List<DogCompetition>();
            var dogCompetitionsMockRepo = new Mock<IRepository<DogCompetition>>();
            dogCompetitionsMockRepo.Setup(x => x.All()).Returns(dogsCompetitionsList.AsQueryable());
            dogCompetitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<DogCompetition>())).Callback(
                (DogCompetition dogCompetition) => dogsCompetitionsList.Add(dogCompetition));

            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();

            var helpService = new CompetitionsHelpService(
                dogsMockRepo.Object,
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object);

            var service = new CompetitionsService(
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object,
                helpService);

            var competition = new Competition
            {
                Id = 1,
                Name = "TestComp",
                CompetitionStart = DateTime.UtcNow,
                CompetitionEnd = DateTime.UtcNow.AddHours(1),
            };
            var image = new CompetitionImage
            {
                Id = "imageId",
                Extension = "jpg",
            };
            competition.CompetitionImage = image;
            var firstDog = new Dog
            {
                Id = 1,
                Name = "DogOne",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
            };
            var secondDog = new Dog
            {
                Id = 2,
                Name = "DogTwo",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
            };
            var thirdDog = new Dog
            {
                Id = 3,
                Name = "DogThree",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
            };

            var firstEvaluationForm = new EvaluationForm
            {
                Id = 1,
                CompetitionId = 1,
                Competitions = competition,
                DogId = 1,
                Dog = firstDog,
                TotalPoints = 20,
            };
            var secondEvaluationForm = new EvaluationForm
            {
                Id = 2,
                CompetitionId = 1,
                Competitions = competition,
                DogId = 2,
                Dog = secondDog,
                TotalPoints = 30,
            };

            var thirdEvaluationForm = new EvaluationForm
            {
                Id = 3,
                Competitions = competition,
                CompetitionId = 1,
                DogId = 3,
                Dog = thirdDog,
                TotalPoints = 25,
            };

            var fourthEvaluationForm = new EvaluationForm
            {
                Id = 4,
                Competitions = competition,
                CompetitionId = 1,
                DogId = 3,
                Dog = thirdDog,
                TotalPoints = 25,
            };

            firstDog.EvaluationForms.Add(firstEvaluationForm);
            secondDog.EvaluationForms.Add(secondEvaluationForm);
            thirdDog.EvaluationForms.Add(thirdEvaluationForm);
            thirdDog.EvaluationForms.Add(fourthEvaluationForm);

            competition.DogsCompetitions.Add(new DogCompetition
            {
                DogId = 1,
                Dog = firstDog,
                CompetitionId = 1,
                Competition = competition,
            });
            competition.DogsCompetitions.Add(new DogCompetition
            {
                DogId = 2,
                Dog = secondDog,
                CompetitionId = 1,
                Competition = competition,
            });
            competition.DogsCompetitions.Add(new DogCompetition
            {
                DogId = 3,
                Dog = thirdDog,
                CompetitionId = 1,
                Competition = competition,
            });

            dogsCompetitionsList.Add(new DogCompetition
            {
                DogId = 1,
                Dog = firstDog,
                CompetitionId = 1,
                Competition = competition,
            });
            dogsCompetitionsList.Add(new DogCompetition
            {
                DogId = 2,
                Dog = secondDog,
                CompetitionId = 1,
                Competition = competition,
            });
            dogsCompetitionsList.Add(new DogCompetition
            {
                DogId = 3,
                Dog = thirdDog,
                CompetitionId = 1,
                Competition = competition,
            });

            competitionsList.Add(competition);

            var data = service.CompetitionDetails(1);

            Assert.Equal(1, data.CompetitionId);
            Assert.Equal("TestComp", data.Name);
            Assert.Equal(3, data.ParticipantsCount);
            Assert.Equal("Complete", data.Status);
            Assert.Equal(3, data.FemaleDogWinners.First().Id);
            Assert.Equal(50, data.FemaleDogWinners.First().TotalPoints);
        }

        [Fact]
        public void GettingDataOfCompleteCompetitionByIdWorksCorrectlyForMaleDogWinners()
        {
            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            var dogsCompetitionsList = new List<DogCompetition>();
            var dogCompetitionsMockRepo = new Mock<IRepository<DogCompetition>>();
            dogCompetitionsMockRepo.Setup(x => x.All()).Returns(dogsCompetitionsList.AsQueryable());
            dogCompetitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<DogCompetition>())).Callback(
                (DogCompetition dogCompetition) => dogsCompetitionsList.Add(dogCompetition));

            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();

            var helpService = new CompetitionsHelpService(
                dogsMockRepo.Object,
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object);

            var service = new CompetitionsService(
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object,
                helpService);

            var competition = new Competition
            {
                Id = 1,
                Name = "TestComp",
                CompetitionStart = DateTime.UtcNow,
                CompetitionEnd = DateTime.UtcNow.AddHours(1),
            };
            var image = new CompetitionImage
            {
                Id = "imageId",
                Extension = "jpg",
            };
            competition.CompetitionImage = image;
            var firstDog = new Dog
            {
                Id = 1,
                Name = "DogOne",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
            };
            var secondDog = new Dog
            {
                Id = 2,
                Name = "DogTwo",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
            };
            var thirdDog = new Dog
            {
                Id = 3,
                Name = "DogThree",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
            };

            var firstEvaluationForm = new EvaluationForm
            {
                Id = 1,
                CompetitionId = 1,
                Competitions = competition,
                DogId = 1,
                Dog = firstDog,
                TotalPoints = 20,
            };
            var secondEvaluationForm = new EvaluationForm
            {
                Id = 2,
                CompetitionId = 1,
                Competitions = competition,
                DogId = 2,
                Dog = secondDog,
                TotalPoints = 30,
            };

            var thirdEvaluationForm = new EvaluationForm
            {
                Id = 3,
                Competitions = competition,
                CompetitionId = 1,
                DogId = 3,
                Dog = thirdDog,
                TotalPoints = 25,
            };

            var fourthEvaluationForm = new EvaluationForm
            {
                Id = 4,
                Competitions = competition,
                CompetitionId = 1,
                DogId = 3,
                Dog = thirdDog,
                TotalPoints = 35,
            };

            firstDog.EvaluationForms.Add(firstEvaluationForm);
            secondDog.EvaluationForms.Add(secondEvaluationForm);
            thirdDog.EvaluationForms.Add(thirdEvaluationForm);
            thirdDog.EvaluationForms.Add(fourthEvaluationForm);

            competition.DogsCompetitions.Add(new DogCompetition
            {
                DogId = 1,
                Dog = firstDog,
                CompetitionId = 1,
                Competition = competition,
            });
            competition.DogsCompetitions.Add(new DogCompetition
            {
                DogId = 2,
                Dog = secondDog,
                CompetitionId = 1,
                Competition = competition,
            });
            competition.DogsCompetitions.Add(new DogCompetition
            {
                DogId = 3,
                Dog = thirdDog,
                CompetitionId = 1,
                Competition = competition,
            });

            dogsCompetitionsList.Add(new DogCompetition
            {
                DogId = 1,
                Dog = firstDog,
                CompetitionId = 1,
                Competition = competition,
            });
            dogsCompetitionsList.Add(new DogCompetition
            {
                DogId = 2,
                Dog = secondDog,
                CompetitionId = 1,
                Competition = competition,
            });
            dogsCompetitionsList.Add(new DogCompetition
            {
                DogId = 3,
                Dog = thirdDog,
                CompetitionId = 1,
                Competition = competition,
            });

            competitionsList.Add(competition);

            var data = service.CompetitionDetails(1);

            Assert.Equal(1, data.CompetitionId);
            Assert.Equal("TestComp", data.Name);
            Assert.Equal(3, data.ParticipantsCount);
            Assert.Equal("Complete", data.Status);
            Assert.Equal(3, data.MaleDogWinners.First().Id);
            Assert.Equal(60, data.MaleDogWinners.First().TotalPoints);
        }

        [Fact]
        public void GettingDataOfCompetitionInProgressByIdWorksCorrectly()
        {
            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
            Mock<IRepository<DogCompetition>> dogCompetitionsMockRepo = DogsCompetitionsMock();

            var helpService = new CompetitionsHelpService(
                dogsMockRepo.Object,
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object);

            var service = new CompetitionsService(
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object,
                helpService);

            var competition = new Competition
            {
                Id = 1,
                Name = "TestComp",
                CompetitionStart = DateTime.UtcNow,
                CompetitionEnd = DateTime.UtcNow.AddHours(3),
            };
            var competitionTwo = new Competition
            {
                Id = 2,
                Name = "TestComp2",
                CompetitionStart = DateTime.UtcNow,
                CompetitionEnd = DateTime.UtcNow.AddHours(3),
            };
            var image = new CompetitionImage
            {
                Id = "imageId",
                Extension = "jpg",
            };
            competitionTwo.CompetitionImage = image;
            var firstDog = new Dog
            {
                Id = 1,
            };
            var secondDog = new Dog
            {
                Id = 2,
            };
            competitionTwo.DogsCompetitions.Add(new DogCompetition
            {
                DogId = 1,
                Dog = firstDog,
                CompetitionId = 1,
                Competition = competition,
            });
            competitionTwo.DogsCompetitions.Add(new DogCompetition
            {
                DogId = 2,
                Dog = secondDog,
                CompetitionId = 1,
                Competition = competition,
            });

            competitionsList.Add(competition);
            competitionsList.Add(competitionTwo);

            var data = service.CompetitionDetails(2);

            Assert.Equal(2, data.CompetitionId);
            Assert.Equal("TestComp2", data.Name);
            Assert.Equal(2, data.ParticipantsCount);
            Assert.Equal("In Progress", data.Status);
        }

        [Fact]
        public void GettingDataOfUpcomingCompetitionByIdWorksCorrectly()
        {
            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
            Mock<IRepository<DogCompetition>> dogCompetitionsMockRepo = DogsCompetitionsMock();

            var helpService = new CompetitionsHelpService(
                dogsMockRepo.Object,
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object);

            var service = new CompetitionsService(
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object,
                helpService);

            var competition = new Competition
            {
                Id = 1,
                Name = "TestComp",
                CompetitionStart = DateTime.UtcNow.AddDays(1),
                CompetitionEnd = DateTime.UtcNow.AddDays(3),
            };
            var competitionTwo = new Competition
            {
                Id = 2,
                Name = "TestComp2",
                CompetitionStart = DateTime.UtcNow.AddDays(1),
                CompetitionEnd = DateTime.UtcNow.AddDays(3),
            };
            var image = new CompetitionImage
            {
                Id = "imageId",
                Extension = "jpg",
            };
            competitionTwo.CompetitionImage = image;

            competitionsList.Add(competition);
            competitionsList.Add(competitionTwo);

            var data = service.CompetitionDetails(2);

            Assert.Equal(2, data.CompetitionId);
            Assert.Equal("TestComp2", data.Name);
            Assert.Equal(0, data.ParticipantsCount);
            Assert.Equal("Upcoming", data.Status);
        }

        [Fact]
        public void CurrentCompetitionDataWorksCorrectly()
        {
            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
            Mock<IRepository<DogCompetition>> dogCompetitionsMockRepo = DogsCompetitionsMock();

            var helpService = new CompetitionsHelpService(
                dogsMockRepo.Object,
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object);

            var service = new CompetitionsService(
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object,
                helpService);

            var breed = new Breed
            {
                Id = 1,
                Name = "Bulldog",
            };

            var organiser = new Organiser
            {
                Id = 1,
            };

            var competitionOne = new Competition
            {
                Id = 1,
                Name = "TestComp",
                CompetitionStart = DateTime.UtcNow.AddDays(1),
                CompetitionEnd = DateTime.UtcNow.AddDays(3),
                OrganiserId = 1,
                Organiser = organiser,
                BreedId = 1,
                Breed = breed,
            };
            var competitionTwo = new Competition
            {
                Id = 2,
                Name = "TestComp2",
                CompetitionStart = DateTime.UtcNow,
                CompetitionEnd = DateTime.UtcNow.AddDays(1),
                OrganiserId = 1,
                Organiser = organiser,
                BreedId = 1,
                Breed = breed,
            };
            competitionsList.Add(competitionOne);
            competitionsList.Add(competitionTwo);

            var data = service.GetCurrentCompetition();

            Assert.Equal(2, data.CompetitionId);
        }

        [Fact]
        public void CurrentCompetitionReturnsNullIfThereIsNoCompetitionInProgress()
        {
            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
            Mock<IRepository<DogCompetition>> dogCompetitionsMockRepo = DogsCompetitionsMock();

            var helpService = new CompetitionsHelpService(
                dogsMockRepo.Object,
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object);

            var service = new CompetitionsService(
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object,
                helpService);

            var breed = new Breed
            {
                Id = 1,
                Name = "Bulldog",
            };

            var organiser = new Organiser
            {
                Id = 1,
            };

            var competitionOne = new Competition
            {
                Id = 1,
                Name = "TestComp",
                CompetitionStart = DateTime.UtcNow.AddDays(1),
                CompetitionEnd = DateTime.UtcNow.AddDays(3),
                OrganiserId = 1,
                Organiser = organiser,
                BreedId = 1,
                Breed = breed,
            };
            var competitionTwo = new Competition
            {
                Id = 2,
                Name = "TestComp2",
                CompetitionStart = DateTime.UtcNow,
                CompetitionEnd = DateTime.UtcNow.AddMinutes(50),
                OrganiserId = 1,
                Organiser = organiser,
                BreedId = 1,
                Breed = breed,
            };
            competitionsList.Add(competitionOne);
            competitionsList.Add(competitionTwo);

            Assert.Null(service.GetCurrentCompetition());
        }

        [Fact]
        public void PastCompetitionsListDataReturnsOnlyPastCompetitionsOrderedDescendingByStartDate()
        {
            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
            Mock<IRepository<DogCompetition>> dogCompetitionsMockRepo = DogsCompetitionsMock();

            var helpService = new CompetitionsHelpService(
                dogsMockRepo.Object,
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object);

            var service = new CompetitionsService(
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object,
                helpService);

            var breed = new Breed
            {
                Id = 1,
                Name = "Bulldog",
            };

            var organiser = new Organiser
            {
                Id = 1,
            };

            var competitionOne = new Competition
            {
                Id = 1,
                Name = "TestComp",
                CompetitionStart = DateTime.UtcNow,
                CompetitionEnd = DateTime.UtcNow.AddMinutes(30),
                OrganiserId = 1,
                Organiser = organiser,
                BreedId = 1,
                Breed = breed,
            };
            var competitionTwo = new Competition
            {
                Id = 2,
                Name = "TestComp2",
                CompetitionStart = DateTime.UtcNow,
                CompetitionEnd = DateTime.UtcNow.AddDays(1),
                OrganiserId = 1,
                Organiser = organiser,
                BreedId = 1,
                Breed = breed,
            };
            var competitionThree = new Competition
            {
                Id = 3,
                Name = "TestComp",
                CompetitionStart = DateTime.UtcNow.AddMinutes(30),
                CompetitionEnd = DateTime.UtcNow.AddHours(1),
                OrganiserId = 1,
                Organiser = organiser,
                BreedId = 1,
                Breed = breed,
            };
            competitionsList.Add(competitionOne);
            competitionsList.Add(competitionTwo);
            competitionsList.Add(competitionThree);

            var data = service.GetPastCompetitions();

            Assert.Equal(2, data.Count());
            Assert.Equal(3, data.Select(x => x.CompetitionId).First());
        }

        [Fact]
        public void UpcomingCompetitionsListDataReturnsOnlyUpcomingCompetitionsOrderedDescendingByStartDate()
        {
            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();
            Mock<IRepository<DogCompetition>> dogCompetitionsMockRepo = DogsCompetitionsMock();

            var helpService = new CompetitionsHelpService(
                dogsMockRepo.Object,
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object);

            var service = new CompetitionsService(
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object,
                helpService);

            var breed = new Breed
            {
                Id = 1,
                Name = "Bulldog",
            };

            var organiser = new Organiser
            {
                Id = 1,
            };

            var competitionOne = new Competition
            {
                Id = 1,
                Name = "TestComp",
                CompetitionStart = DateTime.UtcNow.AddDays(1),
                CompetitionEnd = DateTime.UtcNow.AddDays(3),
                OrganiserId = 1,
                Organiser = organiser,
                BreedId = 1,
                Breed = breed,
            };
            var competitionTwo = new Competition
            {
                Id = 2,
                Name = "TestComp2",
                CompetitionStart = DateTime.UtcNow,
                CompetitionEnd = DateTime.UtcNow.AddDays(1),
                OrganiserId = 1,
                Organiser = organiser,
                BreedId = 1,
                Breed = breed,
            };
            var competitionThree = new Competition
            {
                Id = 3,
                Name = "TestComp",
                CompetitionStart = DateTime.UtcNow.AddDays(3),
                CompetitionEnd = DateTime.UtcNow.AddDays(4),
                OrganiserId = 1,
                Organiser = organiser,
                BreedId = 1,
                Breed = breed,
            };
            competitionsList.Add(competitionOne);
            competitionsList.Add(competitionTwo);
            competitionsList.Add(competitionThree);

            var data = service.GetUpcomingCompetitions();

            Assert.Equal(2, data.Count());
            Assert.Equal(1, data.Select(x => x.CompetitionId).First());
        }

        [Fact]
        public void DogOfGivenUserThatIsAddedToGivenCompetitionReturnsTrue()
        {
            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IRepository<DogCompetition>> dogCompetitionsMockRepo = DogsCompetitionsMock();
            var helpService = new CompetitionsHelpService(
                dogsMockRepo.Object,
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object);

            var service = new CompetitionsService(
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object,
                helpService);

            var breed = new Breed
            {
                Id = 1,
                Name = "Bulldog",
            };

            var competition = new Competition
            {
                Id = 1,
                Name = "Test",
                BreedId = 1,
                Breed = breed,
            };
            var competitionTwo = new Competition
            {
                Id = 2,
                Name = "Test2",
                BreedId = 1,
                Breed = breed,
            };
            competitionsList.Add(competition);
            competitionsList.Add(competitionTwo);

            var image = new DogImage
            {
                Id = "string",
                Extension = "jpg",
            };
            var firstDog = new Dog
            {
                Id = 1,
                UserId = "firstUser",
                Name = "Test1",
                BreedId = 1,
                Breed = breed,
                IsSpayedOrNeutered = false,
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
            };
            var secondDog = new Dog
            {
                Id = 2,
                Name = "Test2",
                UserId = "firstUser",
                BreedId = 1,
                Breed = breed,
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
            };
            var thirdDog = new Dog
            {
                Id = 3,
                Name = "Test3",
                UserId = "secondUser",
                BreedId = 1,
                Breed = breed,
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
            };
            firstDog.DogImages.Add(image);
            secondDog.DogImages.Add(image);
            thirdDog.DogImages.Add(image);
            dogsList.Add(firstDog);
            dogsList.Add(secondDog);
            dogsList.Add(thirdDog);

            firstDog.DogsCompetiotions.Add(new DogCompetition
            {
                DogId = 1,
                Dog = firstDog,
                CompetitionId = 1,
                Competition = competition,
            });

            var data = service.DogsToAddToCompetition(1, "firstUser");

            Assert.Equal(2, data.PossibleDogApplicants.Count());
            Assert.Equal(1, data.CompetitionId);
            Assert.True(data.PossibleDogApplicants.First().AlreadyAddedToCompetition);
        }

        [Fact]
        public void DogOfGivenUserThatIsNOTAddedToGivenCompetitionReturnsFalse()
        {
            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IRepository<DogCompetition>> dogCompetitionsMockRepo = DogsCompetitionsMock();
            
            var helpService = new CompetitionsHelpService(
                dogsMockRepo.Object,
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object);

            var service = new CompetitionsService(
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object,
                helpService);

            var breed = new Breed
            {
                Id = 1,
                Name = "Bulldog",
            };

            var competition = new Competition
            {
                Id = 1,
                Name = "Test",
                BreedId = 1,
                Breed = breed,
            };
            competitionsList.Add(competition);

            var image = new DogImage
            {
                Id = "string",
                Extension = "jpg",
            };
            var firstDog = new Dog
            {
                Id = 1,
                UserId = "firstUser",
                Name = "Test1",
                BreedId = 1,
                Breed = breed,
                IsSpayedOrNeutered = false,
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
            };
            var secondDog = new Dog
            {
                Id = 2,
                Name = "Test2",
                UserId = "firstUser",
                BreedId = 1,
                Breed = breed,
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
            };
            var thirdDog = new Dog
            {
                Id = 3,
                Name = "Test3",
                UserId = "secondUser",
                BreedId = 1,
                Breed = breed,
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
            };
            firstDog.DogImages.Add(image);
            secondDog.DogImages.Add(image);
            thirdDog.DogImages.Add(image);
            dogsList.Add(firstDog);
            dogsList.Add(secondDog);
            dogsList.Add(thirdDog);

            var data = service.DogsToAddToCompetition(1, "firstUser");

            Assert.Equal(2, data.PossibleDogApplicants.Count());
            Assert.False(data.PossibleDogApplicants.FirstOrDefault().AlreadyAddedToCompetition);
        }

        [Fact]
        public void GivenUserIdThatHasNoDogsReturns0PossibleDogApplicants()
        {
            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IRepository<DogCompetition>> dogCompetitionsMockRepo = DogsCompetitionsMock();

            var helpService = new CompetitionsHelpService(
                dogsMockRepo.Object,
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object);

            var service = new CompetitionsService(
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object,
                helpService);

            var breed = new Breed
            {
                Id = 1,
                Name = "Bulldog",
            };

            var competition = new Competition
            {
                Id = 1,
                Name = "Test",
                BreedId = 1,
                Breed = breed,
            };
            competitionsList.Add(competition);

            var image = new DogImage
            {
                Id = "string",
                Extension = "jpg",
            };
            var firstDog = new Dog
            {
                Id = 1,
                UserId = "firstUser",
                Name = "Test1",
                BreedId = 1,
                Breed = breed,
                IsSpayedOrNeutered = false,
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
            };
            var secondDog = new Dog
            {
                Id = 2,
                Name = "Test2",
                UserId = "firstUser",
                BreedId = 1,
                Breed = breed,
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
            };
            firstDog.DogImages.Add(image);
            secondDog.DogImages.Add(image);
            dogsList.Add(firstDog);
            dogsList.Add(secondDog);

            var data = service.DogsToAddToCompetition(1, "secondUser");

            Assert.Equal(0, data.PossibleDogApplicants.Count());
        }

        [Fact]
        public void DogMeetsAllTheRequirementsToParticipateInCompetitionReturnsTrue()
        {
            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));
            Mock<IRepository<DogCompetition>> dogCompetitionsMockRepo = DogsCompetitionsMock();

            var helpService = new CompetitionsHelpService(
                dogsMockRepo.Object,
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object);

            var service = new CompetitionsService(
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object,
                helpService);

            var breed = new Breed
            {
                Id = 1,
                Name = "Bulldog",
            };

            var competition = new Competition
            {
                Id = 1,
                Name = "Test",
                BreedId = 1,
                Breed = breed,
            };
            competitionsList.Add(competition);

            var firstDog = new Dog
            {
                Id = 1,
                UserId = "firstUser",
                Name = "Test1",
                BreedId = 1,
                Breed = breed,
                IsSpayedOrNeutered = false,
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
            };
            dogsList.Add(firstDog);

            Assert.True(service.DoesDogMeetTheCompetitionRequirements(1, 1));
        }

        [Fact]
        public void DogBreedIsDifferentThanTheRequiredCompetitionBreedReturnsFalse()
        {
            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IRepository<DogCompetition>> dogCompetitionsMockRepo = DogsCompetitionsMock();

            var helpService = new CompetitionsHelpService(
                dogsMockRepo.Object,
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object);

            var service = new CompetitionsService(
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object,
                helpService);

            var breed = new Breed
            {
                Id = 1,
                Name = "Bulldog",
            };
            var secondBreed = new Breed
            {
                Id = 2,
                Name = "Poodle",
            };

            var competition = new Competition
            {
                Id = 1,
                Name = "Test",
                BreedId = 1,
                Breed = breed,
            };
            competitionsList.Add(competition);

            var firstDog = new Dog
            {
                Id = 1,
                UserId = "firstUser",
                Name = "Test1",
                BreedId = 2,
                Breed = secondBreed,
                IsSpayedOrNeutered = false,
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
            };
            dogsList.Add(firstDog);

            Assert.False(service.DoesDogMeetTheCompetitionRequirements(1, 1));
        }

        [Fact]
        public void SpayedOrNeuteredDogDoesNotMeetTheCompetitionRequirementsThereforeReturnsFalse()
        {
            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IRepository<DogCompetition>> dogCompetitionsMockRepo = DogsCompetitionsMock();
            
            var helpService = new CompetitionsHelpService(
                dogsMockRepo.Object,
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object);

            var service = new CompetitionsService(
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object,
                helpService);

            var breed = new Breed
            {
                Id = 1,
                Name = "Bulldog",
            };

            var competition = new Competition
            {
                Id = 1,
                Name = "Test",
                BreedId = 1,
                Breed = breed,
            };
            competitionsList.Add(competition);

            var firstDog = new Dog
            {
                Id = 1,
                UserId = "firstUser",
                Name = "Test1",
                BreedId = 1,
                Breed = breed,
                IsSpayedOrNeutered = true,
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
            };
            dogsList.Add(firstDog);

            Assert.False(service.DoesDogMeetTheCompetitionRequirements(1, 1));
        }

        [Fact]
        public void SpayedOrNeuteredDogOrDogWithNotRequiredBreedDoesNotMeetTheCompetitionRequirementsThereforeReturnsFalse()
        {
            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IRepository<DogCompetition>> dogCompetitionsMockRepo = DogsCompetitionsMock();

            var helpService = new CompetitionsHelpService(
                dogsMockRepo.Object,
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object);

            var service = new CompetitionsService(
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object,
                helpService);

            var breed = new Breed
            {
                Id = 1,
                Name = "Bulldog",
            };
            var secondBreed = new Breed
            {
                Id = 2,
                Name = "Poodle",
            };

            var competition = new Competition
            {
                Id = 1,
                Name = "Test",
                BreedId = 1,
                Breed = breed,
            };
            competitionsList.Add(competition);

            var firstDog = new Dog
            {
                Id = 1,
                UserId = "firstUser",
                Name = "Test1",
                BreedId = 2,
                Breed = secondBreed,
                IsSpayedOrNeutered = true,
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
            };
            dogsList.Add(firstDog);

            Assert.False(service.DoesDogMeetTheCompetitionRequirements(1, 1));
        }

        [Fact]
        public void DogIsAddedToCompetitionWorksCorrectly()
        {
            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            var dogsCompetitionsList = new List<DogCompetition>();
            var dogCompetitionsMockRepo = new Mock<IRepository<DogCompetition>>();
            dogCompetitionsMockRepo.Setup(x => x.All()).Returns(dogsCompetitionsList.AsQueryable());
            dogCompetitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<DogCompetition>())).Callback(
                (DogCompetition dogCompetition) => dogsCompetitionsList.Add(dogCompetition));

            var helpService = new CompetitionsHelpService(
                dogsMockRepo.Object,
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object);

            var service = new CompetitionsService(
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object,
                helpService);

            var breed = new Breed
            {
                Id = 1,
                Name = "Bulldog",
            };

            var competition = new Competition
            {
                Id = 1,
                Name = "Test",
                BreedId = 1,
                Breed = breed,
            };
            competitionsList.Add(competition);

            var firstDog = new Dog
            {
                Id = 1,
                UserId = "firstUser",
                Name = "Test1",
                BreedId = 1,
                Breed = breed,
                IsSpayedOrNeutered = false,
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
            };
            dogsList.Add(firstDog);

            var data = service.SuccessfullyAddDogToCompetitionAsync(1, 1);

            Assert.Equal(1, dogsCompetitionsList.Count());
            Assert.Equal("Test1", dogsCompetitionsList.Select(x => x.Dog.Name).First());
            Assert.Equal("Test", dogsCompetitionsList.Select(x => x.Competition.Name).First());
        }

        [Fact]
        public async Task RemoveDogFromCompetitionWorksCorrectly()
        {
            var competitionsList = new List<Competition>();
            var competitionsMockRepo = new Mock<IDeletableEntityRepository<Competition>>();
            competitionsMockRepo.Setup(x => x.All()).Returns(competitionsList.AsQueryable());
            competitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<Competition>())).Callback(
                (Competition competition) => competitionsList.Add(competition));

            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            var dogsCompetitionsList = new List<DogCompetition>();
            var dogCompetitionsMockRepo = new Mock<IRepository<DogCompetition>>();
            dogCompetitionsMockRepo.Setup(x => x.All()).Returns(dogsCompetitionsList.AsQueryable());
            dogCompetitionsMockRepo.Setup(x => x.AddAsync(It.IsAny<DogCompetition>())).Callback(
                (DogCompetition dogCompetition) => dogsCompetitionsList.Add(dogCompetition));
            dogCompetitionsMockRepo.Setup(x => x.Delete(It.IsAny<DogCompetition>())).Callback(
                (DogCompetition dogCompetition) => dogsCompetitionsList.Remove(dogCompetition));

            var helpService = new CompetitionsHelpService(
                dogsMockRepo.Object,
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object);

            var service = new CompetitionsService(
                competitionsMockRepo.Object,
                dogCompetitionsMockRepo.Object,
                helpService);

            var breed = new Breed
            {
                Id = 1,
                Name = "Bulldog",
            };

            var competition = new Competition
            {
                Id = 1,
                Name = "Test",
                BreedId = 1,
                Breed = breed,
            };
            competitionsList.Add(competition);

            var firstDog = new Dog
            {
                Id = 1,
                UserId = "firstUser",
                Name = "Test1",
                BreedId = 1,
                Breed = breed,
                IsSpayedOrNeutered = false,
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
            };
            dogsList.Add(firstDog);

            await service.SuccessfullyAddDogToCompetitionAsync(1, 1);
            await service.RemoveDogFromUpcomingCompetition(1, 1);

            Assert.Equal(0, dogsCompetitionsList.Count());
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
