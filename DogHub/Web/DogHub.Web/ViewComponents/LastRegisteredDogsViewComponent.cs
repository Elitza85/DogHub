using DogHub.Services.Data;
using DogHub.Web.ViewModels.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogHub.Web.ViewComponents
{
    public class LastRegisteredDogsViewComponent : ViewComponent
    {
        private readonly IViewComponentsService viewComponentsService;

        public LastRegisteredDogsViewComponent(IViewComponentsService viewComponentsService)
        {
            this.viewComponentsService = viewComponentsService;
        }

        public IViewComponentResult Invoke(string title)
        {
            var viewModel = this.viewComponentsService.LastRegisteredDogsData();
            viewModel.Title = title;

            return this.View(viewModel);
        }
    }
}
