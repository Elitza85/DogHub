namespace DogHub.Web.Controllers
{
    using DogHub.Services.Data;
    using DogHub.Web.ViewModels.Dogs;
    using DogHub.Web.ViewModels.Searches;
    using Microsoft.AspNetCore.Mvc;

    public class SearchesController : Controller
    {
        private readonly ISearchesService searchesService;

        public SearchesController(ISearchesService searchesService)
        {
            this.searchesService = searchesService;
        }

        [HttpGet]
        public IActionResult ListByCriteria(SearchListInputModel input)
        {
            var viewModel = new ListDataViewModel
            {
                DogsByColor = this.searchesService.GetDogsByColors(input.DogColors),
                DogsByBreed = this.searchesService.GetDogsByBreed<DogDataInCatalogueViewModel>(input.BreedId),
            };
            return this.View(viewModel);
        }
    }
}
