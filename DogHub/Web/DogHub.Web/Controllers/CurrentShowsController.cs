﻿namespace DogHub.Web.Controllers
{
    using System;

    using DogHub.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    public class CurrentShowsController : Controller
    {
        private readonly ICurrentShowsService currentShowsService;

        public CurrentShowsController(ICurrentShowsService currentShowsService)
        {
            this.currentShowsService = currentShowsService;
        }

        public IActionResult Competitors(int competitionId)
        {
            var viewModel = this.currentShowsService.FullDataOfCurrentShow(competitionId);
            if (this.currentShowsService.CheckIfCompetitionIsInProgress(competitionId))
            {
                return this.View(viewModel);
            }
            else
            {
                return this.Redirect("/Errors/NotPossibleToVote");
            }
        }
    }
}
