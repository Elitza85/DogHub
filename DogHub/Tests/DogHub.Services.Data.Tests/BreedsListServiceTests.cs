namespace DogHub.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models.Dogs;
    using DogHub.Web.ViewModels.Dogs;
    using Moq;
    using Xunit;

    public class BreedsListServiceTests
    {
        [Fact]
        public async Task BreedIsAddedCorrectlyAndIfSameBreedIsProposedItIsNotAdded()
        {
            var list = new List<Breed>();
            var mockRepo = new Mock<IDeletableEntityRepository<Breed>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Breed>())).Callback(
                (Breed breed) => list.Add(breed));

            var service = new BreedsListService(mockRepo.Object);
            var input = new BreedsListViewModel
            {
                BreedName = "American Bully",
                IsApproved = false,
                IsRejected = false,
                IsUnderReview = true,
            };

            await service.ProposeBreed(input);
            await service.ProposeBreed(input);

            Assert.Equal(input.BreedName, list.First().Name);
            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void GetAllBreedsReturnsTheBreedsApprovedOrderedByNameAsc()
        {
            var list = new List<Breed>();
            var mockRepo = new Mock<IDeletableEntityRepository<Breed>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Breed>())).Callback(
                (Breed breed) => list.Add(breed));

            var breedsService = new BreedsListService(mockRepo.Object);
            var inputOne = new Breed
            {
                Name = "Bulldog",
                IsApproved = true,
                IsRejected = false,
                IsUnderReview = false,
            };

            var inputTwo = new Breed
            {
                Name = "American Bully",
                IsApproved = true,
                IsRejected = false,
                IsUnderReview = false,
            };

            var inputThree = new Breed
            {
                Name = "Poodle",
                IsApproved = false,
                IsRejected = true,
                IsUnderReview = false,
            };

            list.Add(inputOne);
            list.Add(inputTwo);
            list.Add(inputThree);

            var data = breedsService.BreedsListData();

            Assert.Equal(2, data.AllBreeds.Count());
            Assert.Equal("American Bully", data.AllBreeds.First().BreedName);
        }

        [Fact]
        public void BreedsAsKVPReturnsApprovedBreedNameAndId()
        {
            var list = new List<Breed>();
            var mockRepo = new Mock<IDeletableEntityRepository<Breed>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Breed>())).Callback(
                (Breed breed) => list.Add(breed));

            var breedsService = new BreedsListService(mockRepo.Object);

            var firstBreed = new Breed
            {
                Id = 1,
                Name = "Poodle",
                IsApproved = false,
                IsRejected = true,
                IsUnderReview = false,
            };

            var secondBreed = new Breed
            {
                Id = 2,
                Name = "American Bully",
                IsApproved = true,
                IsRejected = false,
                IsUnderReview = false,
            };

            list.Add(firstBreed);
            list.Add(secondBreed);

            var data = breedsService.GetAllAsKVP();

            Assert.Equal(1, data.Count());
            Assert.Equal("2", data.First().Key);
            Assert.Equal("American Bully", data.First().Value);
        }


    }
}
