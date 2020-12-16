namespace DogHub.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models;
    using DogHub.Data.Models.CommonForms;
    using DogHub.Data.Models.Competitions;
    using DogHub.Data.Models.Dogs;
    using DogHub.Data.Models.EvaluationForms;
    using DogHub.Web.ViewModels.Dogs;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Xunit;

    public class DogsServiceTests
    {
        [Fact]
        public void RegisteringDogWithCorrectDataAddsDog()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();
            Mock<IDeletableEntityRepository<EyesColor>> eyesColorMockRepo = EyesColorsMock();
            Mock<IDeletableEntityRepository<JudgeApplicationForm>> judgeAppFormsMockRepo = JugeAppFormsMock();
            Mock<IDeletableEntityRepository<EvaluationForm>> evaluationFormsMockRepo = EvaluationFormsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
            var relatedService = new CommonFormsService(
                judgeAppFormsMockRepo.Object,
                evaluationFormsMockRepo.Object,
                dogsMockRepo.Object,
                competitionsMockRepo.Object);

            var service = new DogsService(
                dogsMockRepo.Object,
                dogColorsMockRepo.Object,
                eyesColorMockRepo.Object,
                relatedService);

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
            List<IFormFile> images = new List<IFormFile>();
            images.Add(imageFile);
            images.Add(imageFile);

            var dogColor = new DogColor
            {
                Id = 1,
                ColorName = "Black",
            };
            var eyesColor = new EyesColor
            {
                Id = 1,
                EyesColorName = "Brown",
            };
            var breed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };

            var input = new RegisterDogInputModel
            {
                DogName = "Test1",
                Description = "TestDescription",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
                Sellable = true,
                IsSpayedOrNeutered = false,
                UserId = "user",
                Weight = 25,
                BreedId = 1,
                DogColor = dogColor.ColorName,
                EyesColor = eyesColor.EyesColorName,
                DogVideoUrl = "https://www.youtube.com/watch?v=XChw5CkhSkg",
                DogImages = images,
            };

            service.Register(input, "path").GetAwaiter().GetResult();
            Assert.Equal(1, dogsList.Count());
            Assert.Equal("Black", dogsList.First().DogColor.ColorName);
            Assert.Equal("Brown", dogsList.First().EyesColor.EyesColorName);
        }

        [Fact]
        public void RegisteringDogWithInvalidImageThrowsError()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();
            Mock<IDeletableEntityRepository<EyesColor>> eyesColorMockRepo = EyesColorsMock();
            Mock<IDeletableEntityRepository<JudgeApplicationForm>> judgeAppFormsMockRepo = JugeAppFormsMock();
            Mock<IDeletableEntityRepository<EvaluationForm>> evaluationFormsMockRepo = EvaluationFormsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
            var relatedService = new CommonFormsService(
                judgeAppFormsMockRepo.Object,
                evaluationFormsMockRepo.Object,
                dogsMockRepo.Object,
                competitionsMockRepo.Object);

            var service = new DogsService(
                dogsMockRepo.Object,
                dogColorsMockRepo.Object,
                eyesColorMockRepo.Object,
                relatedService);

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
            List<IFormFile> images = new List<IFormFile>();
            images.Add(imageFile);
            images.Add(imageFile);

            var dogColor = new DogColor
            {
                Id = 1,
                ColorName = "Black",
            };
            var eyesColor = new EyesColor
            {
                Id = 1,
                EyesColorName = "Brown",
            };
            var breed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };

            var input = new RegisterDogInputModel
            {
                DogName = "Test1",
                Description = "TestDescription",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
                Sellable = true,
                IsSpayedOrNeutered = false,
                UserId = "user",
                Weight = 25,
                BreedId = 1,
                DogColor = dogColor.ColorName,
                EyesColor = eyesColor.EyesColorName,
                DogVideoUrl = "https://www.youtube.com/watch?v=XChw5CkhSkg",
                DogImages = images,
            };

            Assert.Equal("Invalid image extenstion doc", service.Register(input, "path").Exception.InnerException.Message);
        }

        [Fact]
        public void RegisteringDogWithInvalidVideoLinkThrowsError()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();
            Mock<IDeletableEntityRepository<EyesColor>> eyesColorMockRepo = EyesColorsMock();
            Mock<IDeletableEntityRepository<JudgeApplicationForm>> judgeAppFormsMockRepo = JugeAppFormsMock();
            Mock<IDeletableEntityRepository<EvaluationForm>> evaluationFormsMockRepo = EvaluationFormsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
            var relatedService = new CommonFormsService(
                judgeAppFormsMockRepo.Object,
                evaluationFormsMockRepo.Object,
                dogsMockRepo.Object,
                competitionsMockRepo.Object);

            var service = new DogsService(
                dogsMockRepo.Object,
                dogColorsMockRepo.Object,
                eyesColorMockRepo.Object,
                relatedService);

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
            List<IFormFile> images = new List<IFormFile>();
            images.Add(imageFile);
            images.Add(imageFile);

            var dogColor = new DogColor
            {
                Id = 1,
                ColorName = "Black",
            };
            var eyesColor = new EyesColor
            {
                Id = 1,
                EyesColorName = "Brown",
            };
            var breed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };

            var input = new RegisterDogInputModel
            {
                DogName = "Test1",
                Description = "TestDescription",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
                Sellable = true,
                IsSpayedOrNeutered = false,
                UserId = "user",
                Weight = 25,
                BreedId = 1,
                DogColor = dogColor.ColorName,
                EyesColor = eyesColor.EyesColorName,
                DogVideoUrl = "https://www.youtu.com/watch?v=XChw5CkhSkg",
                DogImages = images,
            };

            Assert.Equal("The video should be from YouTube.", service.Register(input, "path").Exception.InnerException.Message);
        }

        [Fact]
        public void GivenDogIdReturnsDogProfileViewModelWithUpdatedVideoUrl()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();
            Mock<IDeletableEntityRepository<EyesColor>> eyesColorMockRepo = EyesColorsMock();
            Mock<IDeletableEntityRepository<JudgeApplicationForm>> judgeAppFormsMockRepo = JugeAppFormsMock();
            Mock<IDeletableEntityRepository<EvaluationForm>> evaluationFormsMockRepo = EvaluationFormsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
            var relatedService = new CommonFormsService(
                judgeAppFormsMockRepo.Object,
                evaluationFormsMockRepo.Object,
                dogsMockRepo.Object,
                competitionsMockRepo.Object);

            var service = new DogsService(
                dogsMockRepo.Object,
                dogColorsMockRepo.Object,
                eyesColorMockRepo.Object,
                relatedService);

            var firstDog = new Dog
            {
                Id = 1,
                Name = "Test1",
                Description = "TestDescription",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
                Sellable = true,
                IsSpayedOrNeutered = false,
                UserId = "user",
                Weight = 25,
                DogVideoUrl = "https://www.youtube.com/watch?v=XChw5CkhSkg",
            };

            var secondDog = new Dog
            {
                Id = 2,
                Name = "Test2",
                Description = "TestDescription",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
                Sellable = false,
                IsSpayedOrNeutered = false,
                UserId = "user",
                Weight = 15,
                DogVideoUrl = "https://www.youtube.com/watch?v=XChw5CkhSkg",
            };

            var firstCompetition = new Competition
            {
                Id = 1,
            };
            var secondCompetition = new Competition
            {
                Id = 2,
            };

            firstDog.DogsCompetiotions.Add(new DogCompetition
            {
                DogId = 1,
                Dog = firstDog,
                CompetitionId = 1,
                Competition = firstCompetition,
            });

            secondDog.DogsCompetiotions.Add(new DogCompetition
            {
                DogId = 2,
                Dog = secondDog,
                CompetitionId = 1,
                Competition = firstCompetition,
            });
            secondDog.DogsCompetiotions.Add(new DogCompetition
            {
                DogId = 2,
                Dog = secondDog,
                CompetitionId = 2,
                Competition = secondCompetition,
            });

            var breed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };
            firstDog.Breed = breed;
            secondDog.Breed = breed;

            var color = new DogColor
            {
                Id = 1,
                ColorName = "Black",
            };
            firstDog.DogColor = color;
            secondDog.DogColor = color;

            var eyesColor = new EyesColor
            {
                Id = 1,
                EyesColorName = "Brown",
            };
            firstDog.EyesColor = eyesColor;
            secondDog.EyesColor = eyesColor;

            var image = new DogImage
            {
                Id = "image",
                DogId = 2,
                Extension = "jpg",
            };
            secondDog.DogImages.Add(image);
            dogsList.Add(firstDog);
            dogsList.Add(secondDog);

            var data = service.DogProfile(2);

            Assert.Equal("Test2", data.Name);
            Assert.Equal(2, data.CompetitionsCount);
            Assert.Equal("https://www.youtube.com/embed/XChw5CkhSkg", data.DogVideoUrl);
        }

        //[Fact]
        //public void GenericMethodReturnsDataForDogCatalogue()
        //{
        //    var dogsList = new List<Dog>();
        //    var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
        //    dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
        //    dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
        //        (Dog dog) => dogsList.Add(dog));

        //    Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();
        //    Mock<IDeletableEntityRepository<EyesColor>> eyesColorMockRepo = EyesColorsMock();
        //    Mock<IDeletableEntityRepository<JudgeApplicationForm>> judgeAppFormsMockRepo = JugeAppFormsMock();
        //    Mock<IDeletableEntityRepository<EvaluationForm>> evaluationFormsMockRepo = EvaluationFormsMock();
        //    Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
        //    var relatedService = new CommonFormsService(
        //        judgeAppFormsMockRepo.Object,
        //        evaluationFormsMockRepo.Object,
        //        dogsMockRepo.Object,
        //        competitionsMockRepo.Object);

        //    var service = new DogsService(
        //        dogsMockRepo.Object,
        //        dogColorsMockRepo.Object,
        //        eyesColorMockRepo.Object,
        //        relatedService);

        //    var firstDog = new Dog
        //    {
        //        Id = 1,
        //        Name = "Test1",
        //        Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
        //        Sellable = true,
        //    };

        //    var secondDog = new Dog
        //    {
        //        Id = 2,
        //        Name = "Test2",
        //        Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
        //        Sellable = false,
        //    };

        //    var color = new DogColor
        //    {
        //        Id = 1,
        //        ColorName = "Black",
        //    };
        //    color.ColorDogs.Add(firstDog);
        //    color.ColorDogs.Add(secondDog);

        //    var breed = new Breed
        //    {
        //        Id = 1,
        //        Name = "Poodle",
        //    };
        //    breed.BreedDogs.Add(firstDog);
        //    breed.BreedDogs.Add(secondDog);

        //    firstDog.BreedId = 1;
        //    firstDog.Breed = breed;
        //    firstDog.DogColorId = 1;
        //    firstDog.DogColor = color;

        //    secondDog.BreedId = 1;
        //    secondDog.Breed = breed;
        //    secondDog.DogColorId = 1;
        //    secondDog.DogColor = color;

        //    var firstImage = new DogImage
        //    {
        //        Id = "image1",
        //        DogId = 1,
        //        Dog = firstDog,
        //        Extension = "jpg",
        //    };
        //    var secondImage = new DogImage
        //    {
        //        Id = "image2",
        //        DogId = 2,
        //        Dog = secondDog,
        //        Extension = "jpg",
        //    };
        //    var evaluationForm = new EvaluationForm
        //    {
        //        Id = 1,
        //        DogId = 1,
        //        Dog = firstDog,
        //        TotalPoints = 10,
        //    };
        //    var secondEvaluationForm = new EvaluationForm
        //    {
        //        Id = 2,
        //        DogId = 2,
        //        Dog = secondDog,
        //        TotalPoints = 20,
        //    };

        //    firstDog.DogImages.Add(firstImage);
        //    firstDog.EvaluationForms.Add(evaluationForm);
        //    secondDog.DogImages.Add(secondImage);
        //    secondDog.EvaluationForms.Add(secondEvaluationForm);

        //    dogsList.Add(firstDog);
        //    dogsList.Add(secondDog);

        //    var data = service.GetAll<DogDataInCatalogueViewModel>(1, 2).ToList();

        //    Assert.Equal(2, data.Count());
        //}

        //[Fact]
        //public void GenericMethodReturnsDataForDogCatalogue()
        //{
        //    var dogsList = new List<Dog>();
        //    var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
        //    dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
        //    dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
        //        (Dog dog) => dogsList.Add(dog));

        //    Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();
        //    Mock<IDeletableEntityRepository<EyesColor>> eyesColorMockRepo = EyesColorsMock();
        //    Mock<IDeletableEntityRepository<JudgeApplicationForm>> judgeAppFormsMockRepo = JugeAppFormsMock();
        //    Mock<IDeletableEntityRepository<EvaluationForm>> evaluationFormsMockRepo = EvaluationFormsMock();
        //    Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
        //    var relatedService = new CommonFormsService(
        //        judgeAppFormsMockRepo.Object,
        //        evaluationFormsMockRepo.Object,
        //        dogsMockRepo.Object,
        //        competitionsMockRepo.Object);

        //    var service = new DogsService(
        //        dogsMockRepo.Object,
        //        dogColorsMockRepo.Object,
        //        eyesColorMockRepo.Object,
        //        relatedService);

        //    var firstDog = new RegisterDogInputModel
        //    {
        //        DogName = "Test1",
        //        Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
        //        Sellable = true,
        //        Description = "Test",
        //        DogVideoUrl = "https://www.youtube.com/embed/XChw5CkhSkg",
        //        IsSpayedOrNeutered = false,
        //        Weight = 35,
        //    };

        //    var user = new ApplicationUser
        //    {
        //        Id = "user",
        //    };
        //    firstDog.UserId = user.Id;

        //    var eyesColor = new EyesColor
        //    {
        //        Id = 1,
        //        EyesColorName = "Brown",
        //    };
        //    firstDog.EyesColor = eyesColor.EyesColorName;

        //    var color = new DogColor
        //    {
        //        Id = 1,
        //        ColorName = "Black",
        //    };

        //    var breed = new Breed
        //    {
        //        Id = 1,
        //        Name = "Poodle",
        //    };

        //    firstDog.BreedId = 1;
        //    firstDog.DogColor = color.ColorName;

        //    var firstImage = new DogImage
        //    {
        //        Id = "image1",
        //        DogId = 1,
        //        Extension = "jpg",
        //    };

        //    firstDog.DogImages.Add(firstImage);

        //    //dogsList.Add(firstDog);
        //    using Stream fileStream = new FileStream(filePath, FileMode.Create);
        //    await image.CopyToAsync(fileStream);

        //    var data = service.Register(firstDog, "SomePath");

        //    Assert.Equal(1, dogsList.Count());
        //}

        [Fact]
        public void AllDogsCountIsCorrect()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();
            Mock<IDeletableEntityRepository<EyesColor>> eyesColorMockRepo = EyesColorsMock();
            Mock<IDeletableEntityRepository<JudgeApplicationForm>> judgeAppFormsMockRepo = JugeAppFormsMock();
            Mock<IDeletableEntityRepository<EvaluationForm>> evaluationFormsMockRepo = EvaluationFormsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
            var relatedService = new CommonFormsService(
                judgeAppFormsMockRepo.Object,
                evaluationFormsMockRepo.Object,
                dogsMockRepo.Object,
                competitionsMockRepo.Object);

            var service = new DogsService(
                dogsMockRepo.Object,
                dogColorsMockRepo.Object,
                eyesColorMockRepo.Object,
                relatedService);

            var firstDog = new Dog
            {
                Id = 1,
                Name = "Test1",
                Description = "TestDescription",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
                Sellable = true,
                IsSpayedOrNeutered = false,
                UserId = "user",
                Weight = 25,
                DogVideoUrl = "https://www.youtube.com/watch?v=XChw5CkhSkg",
            };

            var secondDog = new Dog
            {
                Id = 2,
                Name = "Test2",
                Description = "TestDescription",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
                Sellable = false,
                IsSpayedOrNeutered = false,
                UserId = "user",
                Weight = 15,
                DogVideoUrl = "https://www.youtube.com/watch?v=XChw5CkhSkg",
            };

            var firstCompetition = new Competition
            {
                Id = 1,
            };
            var secondCompetition = new Competition
            {
                Id = 2,
            };

            firstDog.DogsCompetiotions.Add(new DogCompetition
            {
                DogId = 1,
                Dog = firstDog,
                CompetitionId = 1,
                Competition = firstCompetition,
            });

            secondDog.DogsCompetiotions.Add(new DogCompetition
            {
                DogId = 2,
                Dog = secondDog,
                CompetitionId = 1,
                Competition = firstCompetition,
            });
            secondDog.DogsCompetiotions.Add(new DogCompetition
            {
                DogId = 2,
                Dog = secondDog,
                CompetitionId = 2,
                Competition = secondCompetition,
            });

            var breed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };
            firstDog.Breed = breed;
            secondDog.Breed = breed;

            var color = new DogColor
            {
                Id = 1,
                ColorName = "Black",
            };
            firstDog.DogColor = color;
            secondDog.DogColor = color;

            var eyesColor = new EyesColor
            {
                Id = 1,
                EyesColorName = "Brown",
            };
            firstDog.EyesColor = eyesColor;
            secondDog.EyesColor = eyesColor;

            var image = new DogImage
            {
                Id = "image",
                DogId = 2,
                Extension = "jpg",
            };
            secondDog.DogImages.Add(image);
            dogsList.Add(firstDog);
            dogsList.Add(secondDog);

            var data = service.GetCount();

            Assert.Equal(2, data);
        }

        [Fact]
        public void VideoThatIsNotFromYouTubeReturnsFalse()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();
            Mock<IDeletableEntityRepository<EyesColor>> eyesColorMockRepo = EyesColorsMock();
            Mock<IDeletableEntityRepository<JudgeApplicationForm>> judgeAppFormsMockRepo = JugeAppFormsMock();
            Mock<IDeletableEntityRepository<EvaluationForm>> evaluationFormsMockRepo = EvaluationFormsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
            var relatedService = new CommonFormsService(
                judgeAppFormsMockRepo.Object,
                evaluationFormsMockRepo.Object,
                dogsMockRepo.Object,
                competitionsMockRepo.Object);

            var service = new DogsService(
                dogsMockRepo.Object,
                dogColorsMockRepo.Object,
                eyesColorMockRepo.Object,
                relatedService);

            Assert.False(service.IsVideoFromYouTube("someVideoLink"));
        }

        [Fact]
        public void VideoThatIsFromYouTubeReturnsTrue()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();
            Mock<IDeletableEntityRepository<EyesColor>> eyesColorMockRepo = EyesColorsMock();
            Mock<IDeletableEntityRepository<JudgeApplicationForm>> judgeAppFormsMockRepo = JugeAppFormsMock();
            Mock<IDeletableEntityRepository<EvaluationForm>> evaluationFormsMockRepo = EvaluationFormsMock();
            Mock<IDeletableEntityRepository<Competition>> competitionsMockRepo = CompetitionsMock();
            var relatedService = new CommonFormsService(
                judgeAppFormsMockRepo.Object,
                evaluationFormsMockRepo.Object,
                dogsMockRepo.Object,
                competitionsMockRepo.Object);

            var service = new DogsService(
                dogsMockRepo.Object,
                dogColorsMockRepo.Object,
                eyesColorMockRepo.Object,
                relatedService);

            Assert.True(service.IsVideoFromYouTube("https://www.youtube.com/watch?v=XChw5CkhSkg"));
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

        private static Mock<IDeletableEntityRepository<DogColor>> DogColorsMock()
        {
            var dogColorsList = new List<DogColor>();
            var dogColorsMockRepo = new Mock<IDeletableEntityRepository<DogColor>>();
            dogColorsMockRepo.Setup(x => x.All()).Returns(dogColorsList.AsQueryable());
            dogColorsMockRepo.Setup(x => x.AddAsync(It.IsAny<DogColor>())).Callback(
                (DogColor dogColor) => dogColorsList.Add(dogColor));
            return dogColorsMockRepo;
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
