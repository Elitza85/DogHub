using DogHub.Data.Common.Repositories;
using DogHub.Data.Models;
using DogHub.Data.Models.Dogs;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DogHub.Services.Data.Tests
{
    public class ViewComponentsServiceTests
    {
        [Fact]
        public void OnlyFiveDogsAreReturned()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            var service = new ViewComponentsService(dogsMockRepo.Object);

            var breed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };
            var image = new DogImage
            {
                Id = "imageId",
                Extension = "jpg",
            };

            var firstDog = new Dog
            {
                Id = 1,
                Name = "Test1",
                BreedId = 1,
                Breed = breed,
                CreatedOn = DateTime.Now.AddDays(6),
            };
            firstDog.DogImages.Add(image);

            var secondDog = new Dog
            {
                Id = 2,
                Name = "Test",
                BreedId = 1,
                Breed = breed,
                CreatedOn = DateTime.Now.AddDays(3),
            };
            secondDog.DogImages.Add(image);

            var thirdDog = new Dog
            {
                Id = 3,
                Name = "Test3",
                BreedId = 1,
                Breed = breed,
                CreatedOn = DateTime.Now,
            };
            thirdDog.DogImages.Add(image);

            var fourthDog = new Dog
            {
                Id = 4,
                Name = "Test4",
                BreedId = 1,
                Breed = breed,
                CreatedOn = DateTime.Now.AddDays(7),
            };
            fourthDog.DogImages.Add(image);

            var fifthDog = new Dog
            {
                Id = 5,
                Name = "Test5",
                BreedId = 1,
                Breed = breed,
                CreatedOn = DateTime.Now.AddDays(1),
            };
            fifthDog.DogImages.Add(image);

            var sixthDog = new Dog
            {
                Id = 6,
                Name = "Test6",
                BreedId = 1,
                Breed = breed,
                CreatedOn = DateTime.Now.AddDays(2),
            };
            sixthDog.DogImages.Add(image);

            dogsList.Add(firstDog);
            dogsList.Add(secondDog);
            dogsList.Add(thirdDog);
            dogsList.Add(fourthDog);
            dogsList.Add(fifthDog);
            dogsList.Add(sixthDog);

            var data = service.LastDogData();

            Assert.Equal(5, data.Count());
        }

        [Fact]
        public void FiveDogsOrderedByRegisteredDateDescending()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            var service = new ViewComponentsService(dogsMockRepo.Object);

            var breed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };
            var image = new DogImage
            {
                Id = "imageId",
                Extension = "jpg",
            };

            var firstDog = new Dog
            {
                Id = 1,
                Name = "Test1",
                BreedId = 1,
                Breed = breed,
                CreatedOn = DateTime.Now.AddDays(6),
            };
            firstDog.DogImages.Add(image);

            var secondDog = new Dog
            {
                Id = 2,
                Name = "Test",
                BreedId = 1,
                Breed = breed,
                CreatedOn = DateTime.Now.AddDays(3),
            };
            secondDog.DogImages.Add(image);

            var thirdDog = new Dog
            {
                Id = 3,
                Name = "Test3",
                BreedId = 1,
                Breed = breed,
                CreatedOn = DateTime.Now.AddDays(2),
            };
            thirdDog.DogImages.Add(image);

            var fourthDog = new Dog
            {
                Id = 4,
                Name = "Test4",
                BreedId = 1,
                Breed = breed,
                CreatedOn = DateTime.Now.AddDays(7),
            };
            fourthDog.DogImages.Add(image);

            var fifthDog = new Dog
            {
                Id = 5,
                Name = "Test5",
                BreedId = 1,
                Breed = breed,
                CreatedOn = DateTime.Now.AddDays(1),
            };
            fifthDog.DogImages.Add(image);

            var sixthDog = new Dog
            {
                Id = 6,
                Name = "Test6",
                BreedId = 1,
                Breed = breed,
                CreatedOn = DateTime.Now.AddDays(2),
            };
            sixthDog.DogImages.Add(image);

            dogsList.Add(firstDog);
            dogsList.Add(secondDog);
            dogsList.Add(thirdDog);
            dogsList.Add(fourthDog);
            dogsList.Add(fifthDog);
            dogsList.Add(sixthDog);

            var data = service.LastDogData();

            Assert.Equal("Test4", data.First().Name);
            Assert.Equal("Test3", data.Last().Name);
        }

        [Fact]
        public void FullDataOfLastRegisteredDogs()
        {
            var dogsList = new List<Dog>();
            var dogsMockRepo = new Mock<IDeletableEntityRepository<Dog>>();
            dogsMockRepo.Setup(x => x.All()).Returns(dogsList.AsQueryable());
            dogsMockRepo.Setup(x => x.AddAsync(It.IsAny<Dog>())).Callback(
                (Dog dog) => dogsList.Add(dog));

            var service = new ViewComponentsService(dogsMockRepo.Object);

            var breed = new Breed
            {
                Id = 1,
                Name = "Poodle",
            };
            var image = new DogImage
            {
                Id = "imageId",
                Extension = "jpg",
            };

            var firstDog = new Dog
            {
                Id = 1,
                Name = "Test1",
                BreedId = 1,
                Breed = breed,
                CreatedOn = DateTime.Now.AddDays(6),
            };
            firstDog.DogImages.Add(image);

            var secondDog = new Dog
            {
                Id = 2,
                Name = "Test",
                BreedId = 1,
                Breed = breed,
                CreatedOn = DateTime.Now.AddDays(3),
            };
            secondDog.DogImages.Add(image);

            var thirdDog = new Dog
            {
                Id = 3,
                Name = "Test3",
                BreedId = 1,
                Breed = breed,
                CreatedOn = DateTime.Now.AddDays(2),
            };
            thirdDog.DogImages.Add(image);

            var fourthDog = new Dog
            {
                Id = 4,
                Name = "Test4",
                BreedId = 1,
                Breed = breed,
                CreatedOn = DateTime.Now.AddDays(7),
            };
            fourthDog.DogImages.Add(image);

            var fifthDog = new Dog
            {
                Id = 5,
                Name = "Test5",
                BreedId = 1,
                Breed = breed,
                CreatedOn = DateTime.Now.AddDays(1),
            };
            fifthDog.DogImages.Add(image);

            var sixthDog = new Dog
            {
                Id = 6,
                Name = "Test6",
                BreedId = 1,
                Breed = breed,
                CreatedOn = DateTime.Now.AddDays(2),
            };
            sixthDog.DogImages.Add(image);

            dogsList.Add(firstDog);
            dogsList.Add(secondDog);
            dogsList.Add(thirdDog);
            dogsList.Add(fourthDog);
            dogsList.Add(fifthDog);
            dogsList.Add(sixthDog);

            var data = service.LastRegisteredDogsData();

            Assert.Equal(5, data.DogsData.Count());
            Assert.Equal("Test4", data.DogsData.First().Name);
            Assert.Equal("Test3", data.DogsData.Last().Name);
        }
    }
}
