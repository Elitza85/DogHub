namespace DogHub.Services.Data
{
    using System;
    using System.Linq;

    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models.Competitions;
    using DogHub.Web.ViewModels.CurrentShows;

    public class CurrentShowsService : ICurrentShowsService
    {
        private readonly IDeletableEntityRepository<Competition> competitionsRepository;

        public CurrentShowsService(
            IDeletableEntityRepository<Competition> competitionsRepository)
        {
            this.competitionsRepository = competitionsRepository;
        }

        public CompetitorsListViewModel FullDataOfCurrentShow(int competitionId)
        {
            var result = this.competitionsRepository.All()
                .Where(x => x.Id == competitionId)
                .Select(y => new CompetitorsListViewModel
                {
                    CompetitionId = y.Id,
                    CompetitionName = y.Name,
                    CompetitionBreed = y.Breed.Name,
                    StartDate = y.CompetitionStart,
                    EndDate = y.CompetitionEnd,
                    CompetitorDogs = y.DogsCompetitions
                    .Select(d => new CompetitorViewModel
                    {
                        DogId = d.DogId,
                        DogName = d.Dog.Name,
                        Gender = d.Dog.Gender.ToString(),
                        ImageUrl =
                        "/images/dogs/" + d.Dog.DogImages.FirstOrDefault().Id + "." + d.Dog.DogImages.FirstOrDefault().Extension,
                        CurrentTotalPoints = d.Dog.EvaluationForms.Where(c => c.CompetitionId == competitionId).Sum(p => p.TotalPoints),
                    }).ToList(),
                }).FirstOrDefault();
            return result;
        }

        public bool CheckIfCompetitionIsInProgress(int competitionId)
        {
            var competitionData = this.FullDataOfCurrentShow(competitionId);

            if (competitionData.StartDate < DateTime.Now && DateTime.Now < competitionData.EndDate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public CurrentShowOnIndexPageViewModel GetCurrentShowData()
        {
            var competition = this.competitionsRepository.All()
                .Where(x => x.CompetitionStart <= DateTime.Now
                && DateTime.Now <= x.CompetitionEnd)
                .FirstOrDefault();

            if (competition != null)
            {
                var viewModel = new CurrentShowOnIndexPageViewModel
                {
                    CompetitionId = competition.Id,
                    CompetitionName = competition.Name,
                    CompetitionStart = competition.CompetitionStart,
                    CompetitionEnd = competition.CompetitionEnd,
                };

                return viewModel;
            }
            else
            {
                return null;
            }
        }
    }
}
