namespace DogHub.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models;
    using DogHub.Data.Models.CommonForms;
    using DogHub.Data.Models.Competitions;
    using DogHub.Data.Models.Dogs;
    using DogHub.Services.Mapping;
    using DogHub.Web.ViewModels.Competitions;
    using DogHub.Web.ViewModels.Dashboards;
    using DogHub.Web.ViewModels.DogMatches;
    using DogHub.Web.ViewModels.Dogs;

    public class OwnerDashboardsService : IOwnerDashboardsService
    {
        private readonly IDeletableEntityRepository<Dog> dogsRepository;
        private readonly IDeletableEntityRepository<DogColor> dogColorsRepository;
        private readonly IDeletableEntityRepository<EyesColor> eyesColorRepository;
        private readonly IDeletableEntityRepository<Competition> competitionsRepository;
        private readonly IDeletableEntityRepository<JudgeApplicationForm> judgeAppFormsRepository;
        private readonly IJudgesService judgesService;

        public OwnerDashboardsService(
            IDeletableEntityRepository<Dog> dogsRepository,
            IDeletableEntityRepository<DogColor> dogColorsRepository,
            IDeletableEntityRepository<EyesColor> eyesColorRepository,
            IDeletableEntityRepository<Competition> competitionsRepository,
            IDeletableEntityRepository<JudgeApplicationForm> judgeAppFormsRepository,
            IJudgesService judgesService)
        {
            this.dogsRepository = dogsRepository;
            this.dogColorsRepository = dogColorsRepository;
            this.eyesColorRepository = eyesColorRepository;
            this.competitionsRepository = competitionsRepository;
            this.judgeAppFormsRepository = judgeAppFormsRepository;
            this.judgesService = judgesService;
        }

        public IEnumerable<T> GetAllDogsOwned<T>(string userId)
        {
            return this.dogsRepository.All()
                .Where(x => x.UserId == userId)
                .OrderBy(x => x.Name)
                .To<T>()
                .ToList();
        }

        public DashboardIndexViewModel DogsData(string userId)
        {
            var viewModel = new DashboardIndexViewModel
            {
                DogsCount = this.RegisteredDogsCount(userId),
                DogsData = this.GetAllDogsOwned<DogDataInCatalogueViewModel>(userId),
                DogsCompetitionsData = this.DogsInCompetitions(userId),
                RegularVotingData = this.VoteInCompetitionDetails(userId),
                JudgeVotingData = this.judgesService.VoteInCompetitionsAsJudge(userId),
            };
            return viewModel;
        }

        public T GetById<T>(int id)
        {
            var dog = this.dogsRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return dog;
        }

        public async Task UpdateAsync(int id, EditDogDataInputModel input)
        {
            var dog = this.dogsRepository.All()
                .Where(x => x.Id == id).FirstOrDefault();
            dog.Name = input.DogName;
            dog.BreedId = input.BreedId;
            dog.Age = input.Age;
            dog.Gender = input.Gender;
            dog.Description = input.Description;
            dog.IsSpayedOrNeutered = input.IsSpayedOrNeutered;
            dog.Sellable = input.Sellable;
            dog.Weight = input.Weight;

            int newDogColorId = await this.ValidateDogColor(input);
            dog.DogColorId = newDogColorId;

            int newEyesColorId = await this.ValidateDogEyesColor(input);
            dog.EyesColorId = newEyesColorId;

            if (!input.DogVideoUrl.ToLower().Contains("youtube"))
            {
                throw new Exception("Video should be from YouTube");
            }
            else
            {
                dog.DogVideoUrl = input.DogVideoUrl;
            }

            await this.dogsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dog = this.dogsRepository.All().FirstOrDefault(x => x.Id == id);
            this.dogsRepository.Delete(dog);
            await this.dogsRepository.SaveChangesAsync();
        }

        public IEnumerable<DogsInCompetitionsViewModel> DogsInCompetitions(string userId)
        {
            var dogsInCompetitions = this.competitionsRepository.All()
                .Where(x => x.CompetitionEnd < DateTime.Now && x.DogsCompetitions.Any(y => y.Dog.UserId == userId))
                .Select(d => new DogsInCompetitionsViewModel
                {
                    CompetitionId = d.Id,
                    CompetitionImage = "/images/competitions/" + d.CompetitionImage.Id + "." + d.CompetitionImage.Extension,
                    CompetitionName = d.Name,
                    AllDogsParticipants = d.DogsCompetitions
                    .Select(x => x.Dog).Where(x => x.UserId == userId)
                    .Select(c => new DogDataInCatalogueViewModel
                    {
                        Name = c.Name,
                        TotalPoints = c.EvaluationForms.Where(x => x.CompetitionId == d.Id).Sum(x => x.TotalPoints),
                    }),
                }).ToList();

            return dogsInCompetitions;
        }

        public IEnumerable<CompetitionDetailsViewModel> VoteInCompetitionDetails(string userId)
        {
            var result = this.competitionsRepository.All()
                .Where(x => x.EvaluationForms.Any(y => y.UserId == userId))
                .Select(y => new CompetitionDetailsViewModel
                {
                    Name = y.Name,
                    StartDate = y.CompetitionStart,
                    EndDate = y.CompetitionEnd,
                    ParticipantsCount = y.DogsCompetitions.Count(),
                })
                .ToList();

            return result;
        }

        public IEnumerable<DogPartnershipReguestsViewModel> PartnershipRequestsSent(string userId)
        {
            

            return null;
        }

        private async Task<int> ValidateDogEyesColor(EditDogDataInputModel input)
        {
            if (!this.eyesColorRepository.All().Any(x => x.EyesColorName == input.EyesColor))
            {
                await this.eyesColorRepository
                    .AddAsync(new EyesColor { EyesColorName = input.EyesColor });
                await this.eyesColorRepository.SaveChangesAsync();
            }

            int newEyesColorId = this.eyesColorRepository.All().First(x => x.EyesColorName == input.EyesColor).Id;
            return newEyesColorId;
        }

        private async Task<int> ValidateDogColor(EditDogDataInputModel input)
        {
            if (!this.dogColorsRepository.All().Any(x => x.ColorName == input.DogColor))
            {
                await this.dogColorsRepository
                    .AddAsync(new DogColor { ColorName = input.DogColor });
                await this.dogColorsRepository.SaveChangesAsync();
            }

            int newColorId = this.dogColorsRepository.All().First(x => x.ColorName == input.DogColor).Id;
            return newColorId;
        }

        private int RegisteredDogsCount(string userId)
        {
            return this.dogsRepository.All()
                .Where(x => x.UserId == userId).Count();
        }
    }
}
