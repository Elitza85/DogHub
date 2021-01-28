namespace DogHub.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models;
    using DogHub.Web.ViewModels.ViewComponents;

    public class ViewComponentsService : IViewComponentsService
    {
        private readonly IDeletableEntityRepository<Dog> dogsRepository;

        public ViewComponentsService(IDeletableEntityRepository<Dog> dogsRepository)
        {
            this.dogsRepository = dogsRepository;
        }

        public IEnumerable<LastRegisteredDogViewModel> LastDogData()
        {
            var dogs = this.dogsRepository.All()
                .Select(x => new LastRegisteredDogViewModel
                {
                    Name = x.Name,
                    Breed = x.Breed.Name.ToString(),
                    ImageUrl = $"{x.DogImages.FirstOrDefault().FolderPath}" + $"Dashboard_{x.DogImages.FirstOrDefault().Id}" + "." + x.DogImages.FirstOrDefault().Extension,
                    RegisteredOn = x.CreatedOn,
                })
                .OrderByDescending(x => x.RegisteredOn)
                .Take(5)
                .ToList();

            return dogs;
        }

        public LastRegisteredDogsViewModel LastRegisteredDogsData()
        {
            var viewModel = new LastRegisteredDogsViewModel();
            viewModel.DogsData = this.LastDogData();

            return viewModel;
        }
    }
}
