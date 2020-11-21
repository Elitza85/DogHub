namespace DogHub.Services.Data
{
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
            return this.competitionsRepository.All()
                .Where(x => x.Id == competitionId)
                .Select(y => new CompetitorsListViewModel
                {
                    CompetitionId = y.Id,
                    CompetitionName = y.Name,
                    CompetitionBreed = y.Breed.Name,
                    CompetitorDogs = y.DogsCompetitions
                    .Select(d => new CompetitorViewModel
                    {
                        DogId = d.DogId,
                        DogName = d.Dog.Name,
                        CurrentTotalPoints = d.Dog.EvaluationForms.Where(c => c.CompetitionId == competitionId).Sum(p => p.TotalPoints),
                    }).ToList(),
                }).FirstOrDefault();
        }
    }
}
