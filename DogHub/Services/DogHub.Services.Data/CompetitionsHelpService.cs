namespace DogHub.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models;
    using DogHub.Data.Models.Competitions;
    using DogHub.Web.ViewModels.Dogs;

    public class CompetitionsHelpService : ICompetitionsHelpService
    {
        private readonly IDeletableEntityRepository<Dog> dogsRepository;
        private readonly IDeletableEntityRepository<Competition> competitionsRepository;

        public CompetitionsHelpService(
            IDeletableEntityRepository<Dog> dogsRepository,
            IDeletableEntityRepository<Competition> competitionsRepository)
        {
            this.dogsRepository = dogsRepository;
            this.competitionsRepository = competitionsRepository;
        }

        public string GetCompetitionRequiredBreed(int competitionId)
        {
            return this.competitionsRepository.All()
                .Where(x => x.Id == competitionId)
                .Select(b => b.Breed.BreedName)
                .FirstOrDefault();
        }

        public string GetDogBreed(int dogId)
        {
            return this.dogsRepository.All()
                .Where(x => x.Id == dogId)
                .Select(b => b.Breed.BreedName)
                .FirstOrDefault();
        }

        public bool IsDogSpayedOrNeutered(int dogId)
        {
            var result = this.dogsRepository.All()
                .Where(x => x.Id == dogId)
                .Select(d => d.IsSpayedOrNeutered)
                .FirstOrDefault();
            return result ?? false;
        }

        public IEnumerable<PossibleDogApplicantsViewModel> GetPossibleDogApplicants(string userId, int id)
        {
            var result = this.dogsRepository.All()
            .Where(c => c.UserId == userId)
                    .Select(p => new PossibleDogApplicantsViewModel
                    {
                        DogId = p.Id,
                        DogName = p.Name,
                        DogBreed = p.Breed.BreedName,
                        IsSpayedOrNeutered = p.IsSpayedOrNeutered,
                        Gender = p.Gender.ToString(),
                        CompetitionsParticipatedIn = p.DogsCompetiotions
                        .Where(x => x.Competition.CompetitionEnd < DateTime.UtcNow).Count(),
                    }).ToList();
            return result;
        }

        public bool IsDogAddedToCompetition(int dogId, int competitionId)
        {
            return this.dogsRepository.All()
                .Where(x => x.Id == dogId)
                .Select(y => y.DogsCompetiotions
                .Any(z => z.CompetitionId == competitionId)).FirstOrDefault();
        }

        public Dog GetDogById(int dogId)
        {
            return this.dogsRepository.All()
                .FirstOrDefault(x => x.Id == dogId);
        }

        public Competition GetCompetitionById(int competitionId)
        {
            return this.competitionsRepository.All()
                .FirstOrDefault(x => x.Id == competitionId);
        }
    }
}
