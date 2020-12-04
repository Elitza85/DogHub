using DogHub.Services.Data;
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

        public IActionResult ListByColor(SearchListInputModel input)
        {
            return this.View();
        }
    }
}
