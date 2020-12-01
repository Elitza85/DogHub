namespace DogHub.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models;
    using DogHub.Data.Models.Competitions;
    using DogHub.Data.Models.EvaluationForms;
    using DogHub.Web.ViewModels.Competitions;
    using DogHub.Web.ViewModels.Dogs;

    public class CompetitionsHelpService : ICompetitionsHelpService
    {
        private readonly IDeletableEntityRepository<Dog> dogsRepository;
        private readonly IDeletableEntityRepository<Competition> competitionsRepository;
        private readonly IDeletableEntityRepository<EvaluationForm> evalutionFormsRepository;
        private readonly IRepository<DogCompetition> dogCompetitionRepository;

        public CompetitionsHelpService(
            IDeletableEntityRepository<Dog> dogsRepository,
            IDeletableEntityRepository<Competition> competitionsRepository,
            IDeletableEntityRepository<EvaluationForm> evalutionFormsRepository,
            IRepository<DogCompetition> dogCompetitionRepository)
        {
            this.dogsRepository = dogsRepository;
            this.competitionsRepository = competitionsRepository;
            this.evalutionFormsRepository = evalutionFormsRepository;
            this.dogCompetitionRepository = dogCompetitionRepository;
        }

        public string GetCompetitionRequiredBreed(int competitionId)
        {
            return this.competitionsRepository.All()
                .Where(x => x.Id == competitionId)
                .Select(b => b.Breed.Name)
                .FirstOrDefault();
        }

        public string GetDogBreed(int dogId)
        {
            return this.dogsRepository.All()
                .Where(x => x.Id == dogId)
                .Select(b => b.Breed.Name)
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
                        DogBreed = p.Breed.Name,
                        IsSpayedOrNeutered = p.IsSpayedOrNeutered,
                        Gender = p.Gender.ToString(),
                        DogImage = "/images/dogs/" + p.DogImages.FirstOrDefault().Id + "." + p.DogImages.FirstOrDefault().Extension,
                        CompetitionsParticipatedIn = p.DogsCompetiotions
                        .Where(x => x.Competition.CompetitionEnd < DateTime.Now).Count(),
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

        public IEnumerable<WinnersViewModel> FemaleWinners(int id)
        {
            var winners = this.AllWinners(id);
            var femaleWinners = new List<WinnersViewModel>();

            foreach (var winner in winners)
            {
                if(winner.Gender == "Female")
                {
                    femaleWinners.Add(winner);
                }
            }

            var females = femaleWinners.OrderByDescending(x => x.TotalPoints).Take(3);
            return females;
        }

        public IEnumerable<WinnersViewModel> MaleWinners(int id)
        {
            var winners = this.AllWinners(id);
            var maleWinners = new List<WinnersViewModel>();

            foreach (var winner in winners)
            {
                if (winner.Gender == "Male")
                {
                    maleWinners.Add(winner);
                }
            }

            var males = maleWinners.OrderByDescending(x => x.TotalPoints).Take(3);

            return males;
        }

        private IEnumerable<WinnersViewModel> AllWinners(int id)
        {
            var winners = this.dogCompetitionRepository.All()
                .Where(x => x.CompetitionId == id).ToList()
            .Select(x => new WinnersViewModel
            {
                Id = x.DogId,
                Name = this.dogsRepository.All().Where(d => d.Id == x.DogId).Select(n => n.Name).FirstOrDefault(),
                Gender = this.dogsRepository.All().Where(d => d.Id == x.DogId).Select(g => g.Gender.ToString()).FirstOrDefault(),
                TotalPoints = this.evalutionFormsRepository.All().Where(d => d.DogId == x.DogId && d.CompetitionId == id).Sum(x => x.TotalPoints), //Select(e => e.EvaluationForms.Sum(y => y.TotalPoints)).FirstOrDefault(),
            }).ToList();

            return winners;
        }
    }
}
