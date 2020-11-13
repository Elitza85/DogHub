namespace DogHub.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models.Competitions;
    using DogHub.Web.ViewModels.Competitions;

    public class CompetitionsService : ICompetitionsService
    {
        private readonly DogHub.Data.Common.Repositories.IDeletableEntityRepository<Competition> competitionsRepository;
        private readonly IDeletableEntityRepository<Organiser> organisersRepository;

        public CompetitionsService(
            IDeletableEntityRepository<Competition> competitionsRepository,
            IDeletableEntityRepository<Organiser> organisersRepository)
        {
            this.competitionsRepository = competitionsRepository;
            this.organisersRepository = organisersRepository;
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

        //public IEnumerable<CompetitionsListViewModel> ListAllEvents()
        //{
        //    return this.competitionsRepository.All()
        //        .Select(x => new CompetitionsListViewModel
        //        {
        //            Name = x.Name,
        //            Breed = x.Breed.BreedName,
        //            CompetitionId = x.Id,
        //            Organiser = x.Organiser.OrganiserName,
        //            StartDate = x.CompetitionStart,
        //            EndDate = x.CompetitionEnd,
        //        }).ToList();
        //}
    }
}
