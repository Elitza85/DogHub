namespace DogHub.Services.Data.Tests
{
    using System.Reflection;

    using DogHub.Services.Mapping;
    using DogHub.Web.ViewModels;

    public abstract class BaseServiceTest
    {
        public BaseServiceTest()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
        }
    }
}
