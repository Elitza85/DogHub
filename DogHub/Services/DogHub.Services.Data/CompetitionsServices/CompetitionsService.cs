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

    public class CompetitionsService : ICompetitionsService
    {
        private readonly IDeletableEntityRepository<Competition> competitionsRepository;
        private readonly IRepository<DogCompetition> dogsCompetitionsRepository;
        private readonly ICompetitionsHelpService competitionsHelpService;

        public CompetitionsService(
            IDeletableEntityRepository<Competition> competitionsRepository,
            IRepository<DogCompetition> dogsCompetitionsRepository,
            ICompetitionsHelpService competitionsHelpService)
        {
            this.competitionsRepository = competitionsRepository;
            this.dogsCompetitionsRepository = dogsCompetitionsRepository;
            this.competitionsHelpService = competitionsHelpService;
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
            var result = this.competitionsRepository.All()
                .Where(x => x.Id == id)
                .Select(y => new CompetitionDetailsViewModel
                {
                    CompetitionId = y.Id,
                    Name = y.Name,
                    StartDate = y.CompetitionStart,
                    EndDate = y.CompetitionEnd,
                    Status = y.CompetitionStart < DateTime.Now
                    && DateTime.Now < y.CompetitionEnd ? "In Progress"
                    : y.CompetitionEnd < DateTime.Now ? "Complete"
                    : "Upcoming",
                    ParticipantsCount = y.DogsCompetitions.Count(),
                    CompetitionImage =
                    "/images/competitions/" + y.CompetitionImage.Id + "." + y.CompetitionImage.Extension,
                }).FirstOrDefault();

            result.FemaleDogWinners = this.competitionsHelpService.FemaleWinners(id);
            result.MaleDogWinners = this.competitionsHelpService.MaleWinners(id);

            return result;
        }

        public CurrentCompetitionViewModel GetCurrentCompetition()
        {
            var competition = this.competitionsRepository.All()
                .Where(x => x.CompetitionStart < DateTime.Now
                && DateTime.Now < x.CompetitionEnd)
                .Select(y => new CurrentCompetitionViewModel
                {
                    Name = y.Name,
                    Breed = y.Breed.Name,
                    CompetitionId = y.Id,
                    Organiser = y.Organiser.Name,
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
                .Where(x => x.CompetitionEnd < DateTime.Now)
                .OrderByDescending(d => d.CompetitionStart)
                .Select(y => new PastCompetitionsViewModel
                {
                    Name = y.Name,
                    Breed = y.Breed.Name,
                    CompetitionId = y.Id,
                    Organiser = y.Organiser.Name,
                }).ToList();
        }

        public IEnumerable<UpcomingCompetitionsViewModel> GetUpcomingCompetitions()
        {
            return this.competitionsRepository.All()
                .Where(x => DateTime.Now < x.CompetitionStart)
                .OrderBy(d => d.CompetitionStart)
                .Select(y => new UpcomingCompetitionsViewModel
                {
                    Name = y.Name,
                    Breed = y.Breed.Name,
                    CompetitionId = y.Id,
                    Organiser = y.Organiser.Name,
                }).ToList();
        }

        public AddDogToCompetitionInputModel DogsToAddToCompetition(int id, string userId)
        {
            var result = this.competitionsRepository.All()
                .Where(x => x.Id == id)
                .Select(c => new AddDogToCompetitionInputModel
                {
                    CompetitionId = c.Id,
                    CompetitionName = c.Name,
                    CompetitionBreed = c.Breed.Name,
                }).FirstOrDefault();

            result.PossibleDogApplicants = this.competitionsHelpService.GetPossibleDogApplicants(userId);
            this.CheckIfDogIsAddedToCurrentCompetition(id, result);

            return result;
        }

        public bool DoesDogMeetTheCompetitionRequirements(int dogId, int competitionId)
        {
            string dogBreed = this.competitionsHelpService.GetDogBreed(dogId);
            string competitionBreed = this.competitionsHelpService.GetCompetitionRequiredBreed(competitionId);
            bool isDogSpayedOrNeutered = this.competitionsHelpService.IsDogSpayedOrNeutered(dogId);

            if (dogBreed == competitionBreed && !isDogSpayedOrNeutered)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task SuccessfullyAddDogToCompetitionAsync(int dogId, int competitionId)
        {
            Dog dog = this.competitionsHelpService.GetDogById(dogId);
            Competition competition = this.competitionsHelpService.GetCompetitionById(competitionId);

            await this.dogsCompetitionsRepository.AddAsync(new DogCompetition
            {
                DogId = dogId,
                Dog = dog,
                CompetitionId = competitionId,
                Competition = competition,
            });
            await this.dogsCompetitionsRepository.SaveChangesAsync();
        }

        public async Task RemoveDogFromUpcomingCompetition(int dogId, int competitionId)
        {
            var record = this.dogsCompetitionsRepository.All()
                .Where(x => x.DogId == dogId && x.CompetitionId == competitionId)
                .FirstOrDefault();
            this.dogsCompetitionsRepository.Delete(record);
            await this.dogsCompetitionsRepository.SaveChangesAsync();
        }

        private void CheckIfDogIsAddedToCurrentCompetition(int id, AddDogToCompetitionInputModel result)
        {
            foreach (var dogViewModel in result.PossibleDogApplicants)
            {
                if (this.competitionsHelpService.IsDogAddedToCompetition(dogViewModel.DogId, id))
                {
                    dogViewModel.AlreadyAddedToCompetition = true;
                }
                else
                {
                    dogViewModel.AlreadyAddedToCompetition = false;
                }
            }
        }
    }
}
