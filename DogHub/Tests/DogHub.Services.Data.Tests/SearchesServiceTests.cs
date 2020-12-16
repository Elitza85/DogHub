namespace DogHub.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using AutoMapper;
    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models;
    using DogHub.Data.Models.Dogs;
    using DogHub.Services.Mapping;
    using DogHub.Web.ViewModels.Dogs;
    using DogHub.Web.ViewModels.Searches;
    using Moq;
    using Xunit;

    public class SearchesServiceTests : BaseServiceTest
    {
        [Fact]
        public void GetAllColorsReturnAllAddedColors()
        {
            AutoMapperConfig.RegisterMappings(Assembly.Load("DogHub.Services.Data.Tests"));

            var dogColorsList = new List<DogColor>();
            var dogColorsMockRepo = new Mock<IDeletableEntityRepository<DogColor>>();
            dogColorsMockRepo.Setup(x => x.All()).Returns(dogColorsList.AsQueryable());
            dogColorsMockRepo.Setup(x => x.AddAsync(It.IsAny<DogColor>())).Callback(
                (DogColor dogColor) => dogColorsList.Add(dogColor));

            Mock<IDeletableEntityRepository<Dog>> dogsMockRepo = DogsMock();

            var service = new SearchesService(dogColorsMockRepo.Object, dogsMockRepo.Object);

            var firstColor = new DogColor
            {
                Id = 1,
                ColorName = "White",
            };
            var secondColor = new DogColor
            {
                Id = 2,
                ColorName = "Black",
            };

            dogColorsList.Add(firstColor);
            dogColorsList.Add(secondColor);

            service.GetAllColors<ColorNameViewModel>().ToList();

            Assert.Equal(2, dogColorsList.Count());
        }

        [Fact]
        public void GetDogsByColorReturnsDogsWithTheRequiredColors()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();

            var service = new SearchesService(dogColorsMockRepo.Object, dogsMockRepo.Object);

            var firstColor = new DogColor
            {
                Id = 1,
                ColorName = "White",
            };
            var secondColor = new DogColor
            {
                Id = 2,
                ColorName = "Black",
            };
            var thirdColor = new DogColor
            {
                Id = 3,
                ColorName = "Brown",
            };

            var image = new DogImage { Id = "imageId", Extension = "jpg" };

            var firstDog = new Dog
            {
                Id = 1,
                Name = "Test1",
                DogColorId = 1,
                DogColor = firstColor,
            };
            firstDog.DogImages.Add(image);

            var secondDog = new Dog
            {
                Id = 2,
                Name = "Test2",
                DogColorId = 2,
                DogColor = secondColor,
            };
            secondDog.DogImages.Add(image);

            var thirdDog = new Dog
            {
                Id = 3,
                Name = "Test3",
                DogColorId = 3,
                DogColor = thirdColor,
            };
            thirdDog.DogImages.Add(image);

            dogsList.Add(firstDog);
            dogsList.Add(secondDog);
            dogsList.Add(thirdDog);

            var dogs = service.GetDogsByColors(new List<int> { 1, 3 });

            Assert.Equal(2, dogs.Count());
            Assert.Equal("White", dogs.First().DogColorColorName);
        }

        [Fact]
        public void NoColorGivenToSearchReturnsNullDogs()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();

            var service = new SearchesService(dogColorsMockRepo.Object, dogsMockRepo.Object);

            var firstColor = new DogColor
            {
                Id = 1,
                ColorName = "White",
            };
            var secondColor = new DogColor
            {
                Id = 2,
                ColorName = "Black",
            };
            var thirdColor = new DogColor
            {
                Id = 3,
                ColorName = "Brown",
            };

            var image = new DogImage { Id = "imageId", Extension = "jpg" };

            var firstDog = new Dog
            {
                Id = 1,
                Name = "Test1",
                DogColorId = 1,
                DogColor = firstColor,
            };
            firstDog.DogImages.Add(image);

            var secondDog = new Dog
            {
                Id = 2,
                Name = "Test2",
                DogColorId = 2,
                DogColor = secondColor,
            };
            secondDog.DogImages.Add(image);

            var thirdDog = new Dog
            {
                Id = 3,
                Name = "Test3",
                DogColorId = 3,
                DogColor = thirdColor,
            };
            thirdDog.DogImages.Add(image);

            dogsList.Add(firstDog);
            dogsList.Add(secondDog);
            dogsList.Add(thirdDog);

            var dogs = service.GetDogsByColors(new List<int> { });

            Assert.Equal(0, dogs.Count());
        }

        [Fact]
        public void GivenBreedIdReturnsDogsOfTheRequiredBreed()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();

            var service = new SearchesService(dogColorsMockRepo.Object, dogsMockRepo.Object);

            var image = new DogImage
            {
                Id = "imageId",
                Extension = "jpg",
            };
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
            var color = new DogColor
            {
                Id = 1,
                ColorName = "Black",
            };

            var firstDog = new Dog
            {
                UserId = "firstUser",
                Id = 1,
                Name = "Test1",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
                BreedId = 1,
                Breed = firstBreed,
                DogColorId = 1,
                DogColor = color,
                Sellable = true,
            };
            firstDog.DogImages.Add(image);
            dogsList.Add(firstDog);

            var secondDog = new Dog
            {
                UserId = "secondUser",
                Id = 2,
                Name = "Test2",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
                BreedId = 2,
                Breed = secondBreed,
                DogColorId = 1,
                DogColor = color,
                Sellable = false,
            };
            secondDog.DogImages.Add(image);
            dogsList.Add(secondDog);

            var thirdDog = new Dog
            {
                UserId = "secondUser",
                Id = 3,
                Name = "Test3",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
                BreedId = 1,
                Breed = firstBreed,
                DogColorId = 1,
                DogColor = color,
                Sellable = false,
            };
            thirdDog.DogImages.Add(image);
            dogsList.Add(thirdDog);

            var dogs = service.GetDogsByBreed<DogDataInCatalogueViewModel>(1);

            Assert.Equal(2, dogs.Count());
            Assert.Equal("Poodle", dogs.First().BreedName);
        }

        [Fact]
        public void UnexistentBreedIdReturnsNull()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            Mock<IDeletableEntityRepository<DogColor>> dogColorsMockRepo = DogColorsMock();

            var service = new SearchesService(dogColorsMockRepo.Object, dogsMockRepo.Object);

            var image = new DogImage
            {
                Id = "imageId",
                Extension = "jpg",
            };
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
            var color = new DogColor
            {
                Id = 1,
                ColorName = "Black",
            };

            var firstDog = new Dog
            {
                UserId = "firstUser",
                Id = 1,
                Name = "Test1",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Male,
                BreedId = 1,
                Breed = firstBreed,
                DogColorId = 1,
                DogColor = color,
                Sellable = true,
            };
            firstDog.DogImages.Add(image);
            dogsList.Add(firstDog);

            var secondDog = new Dog
            {
                UserId = "secondUser",
                Id = 2,
                Name = "Test2",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
                BreedId = 2,
                Breed = secondBreed,
                DogColorId = 1,
                DogColor = color,
                Sellable = false,
            };
            secondDog.DogImages.Add(image);
            dogsList.Add(secondDog);

            var thirdDog = new Dog
            {
                UserId = "secondUser",
                Id = 3,
                Name = "Test3",
                Gender = DogHub.Data.Models.Enums.DogGenderEnum.Female,
                BreedId = 1,
                Breed = firstBreed,
                DogColorId = 1,
                DogColor = color,
                Sellable = false,
            };
            thirdDog.DogImages.Add(image);
            dogsList.Add(thirdDog);

            var dogs = service.GetDogsByBreed<DogDataInCatalogueViewModel>(100);

            Assert.Equal(0, dogs.Count());
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
    }
}
