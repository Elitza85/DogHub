﻿namespace DogHub.Services.Data
{
    using DogHub.Web.ViewModels.CurrentShows;

    public interface ICurrentShowsService
    {
        CompetitorsListViewModel FullDataOfCurrentShow(int competitionId);

        CurrentShowOnIndexPageViewModel GetCurrentShowData();

        bool CheckIfCompetitionIsInProgress(int competitionId);
    }
}
