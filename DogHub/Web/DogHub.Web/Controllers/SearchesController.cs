using DogHub.Services.Data;
using DogHub.Web.ViewModels.Dogs;
using DogHub.Web.ViewModels.Searches;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogHub.Web.Controllers
{
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
