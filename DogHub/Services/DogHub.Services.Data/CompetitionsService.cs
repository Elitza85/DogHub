namespace DogHub.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models;
    using DogHub.Data.Models.Competitions;
    using DogHub.Web.ViewModels.Competitions;
    using DogHub.Web.ViewModels.Dogs;

    public class CompetitionsService : ICompetitionsService
    {
        private readonly DogHub.Data.Common.Repositories.IDeletableEntityRepository<Competition> competitionsRepository;
        private readonly IDeletableEntityRepository<Organiser> organisersRepository;
        private readonly IDeletableEntityRepository<Dog> dogsRepository;

        public CompetitionsService(
            IDeletableEntityRepository<Competition> competitionsRepository,
            IDeletableEntityRepository<Organiser> organisersRepository,
            IDeletableEntityRepository<Dog> dogsRepository)
        {
            this.competitionsRepository = competitionsRepository;
            this.organisersRepository = organisersRepository;
            this.dogsRepository = dogsRepository;
        }

        public AllEventsViewModel AllEvents()
        {
            var viewModel = new AllEventsViewModel();
            viewModel.CurrentEvent = this.GetCurrentCompetition();
            viewModel.PastEvents = this.GetPastCompetitions();
            viewModel.UpcomingEvents = this.GetUpcomingCompetitions();

            return viewModel;
        }

        public CompetitionDetailsViewModel CompetitionDetails(int id)
        {
            return this.competitionsRepository.All()
                .Where(x => x.Id == id)
                .Select(y => new CompetitionDetailsViewModel
                {
                    CompetitionId = y.Id,
                    Name = y.Name,
                    StartDate = y.CompetitionStart,
                    EndDate = y.CompetitionEnd,
                    Status = y.CompetitionStart < DateTime.UtcNow
                    && DateTime.UtcNow < y.CompetitionEnd ? "In Progress"
                    : y.CompetitionEnd < DateTime.UtcNow ? "Complete"
                    : "Upcoming",
                    ParticipantsCount = y.DogsCompetitions.Count(),
                }).FirstOrDefault();
        }

        public async Task Create(CreateCompetitionInputModel input)
        {
            var competition = new Competition
            {
                BreedId = input.BreedId,
                CompetitionEnd = input.CompetitionEnd,
                CompetitionStart = input.CompetitionStart,
                Name = input.Name,
            };

            var organiser = this.organisersRepository.All()
                .FirstOrDefault(x => x.OrganiserName == input.OrganisedBy);
            if (organiser == null)
            {
                organiser = new Organiser
                {
                    OrganiserName = input.OrganisedBy,
                };
            }

            competition.Organiser = organiser;

            await this.competitionsRepository.AddAsync(competition);
            await this.competitionsRepository.SaveChangesAsync();
        }

        public CurrentCompetitionViewModel GetCurrentCompetition()
        {
            var competition = this.competitionsRepository.All()
                .Where(x => x.CompetitionStart < DateTime.UtcNow
                && DateTime.UtcNow < x.CompetitionEnd)
                .Select(y => new CurrentCompetitionViewModel
                {
                    Name = y.Name,
                    Breed = y.Breed.BreedName,
                    CompetitionId = y.Id,
                    Organiser = y.Organiser.OrganiserName,
                }).FirstOrDefault();

            if (competition == null)
            {
                return null;
            }

            return competition;
        }

        public IEnumerable<PastCompetitionsViewModel> GetPastCompetitions()
        {
            return this.competitionsRepository.All()
                .Where(x => x.CompetitionEnd < DateTime.UtcNow)
                .Select(y => new PastCompetitionsViewModel
                {
                    Name = y.Name,
                    Breed = y.Breed.BreedName,
                    CompetitionId = y.Id,
                    Organiser = y.Organiser.OrganiserName,
                }).ToList();
        }

        public IEnumerable<UpcomingCompetitionsViewModel> GetUpcomingCompetitions()
        {
            return this.competitionsRepository.All()
                .Where(x => DateTime.UtcNow < x.CompetitionStart)
                .Select(y => new UpcomingCompetitionsViewModel
                {
                    Name = y.Name,
                    Breed = y.Breed.BreedName,
                    CompetitionId = y.Id,
                    Organiser = y.Organiser.OrganiserName,
                }).ToList();
        }

        public AddDogToCompetitionInputModel DogsToAddToCpmpetition(int id, string userId)
        {
            var result = this.competitionsRepository.All()
                .Where(x => x.Id == id)
                .Select(c => new AddDogToCompetitionInputModel
                {
                    CompetitionId = c.Id,
                    CompetitionName = c.Name,
                    CompetitionBreed = c.Breed.BreedName,
                }).FirstOrDefault();
            result.PossibleDogApplicants = this.GetPossibleDogApplicants(userId);

            return result;
        }

        IEnumerable<PossibleDogApplicantsViewModel> GetPossibleDogApplicants(string userId)
        {
            return this.dogsRepository.All()
            .Where(c => c.UserId == userId)
                    .Select(p => new PossibleDogApplicantsViewModel
                    {
                        DogId = p.Id,
                        DogName = p.Name,
                        DogBreed = p.Breed.BreedName,
                        IsSpayedOrNeutered = p.IsSpayedOrNeutered,
                        CompetitionsParticipatedIn = p.DogsCompetiotions.Count(),
                    }).ToList();
        }
    }
}
