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
    using DogHub.Web.ViewModels.Searches;
    using Moq;
    using Xunit;

    public class SearchesServiceTests
    {
        [Fact]
        public void Test()
        {
            //AutoMapperConfig.RegisterMappings(Assembly.Load("DogHub.Services.Data.Tests"));

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
