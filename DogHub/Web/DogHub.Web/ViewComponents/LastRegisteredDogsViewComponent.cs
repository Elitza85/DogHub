namespace DogHub.Web.ViewComponents
{
    using DogHub.Services.Data;
    using Microsoft.AspNetCore.Mvc;

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
