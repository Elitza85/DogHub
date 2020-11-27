﻿namespace DogHub.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models;
    using DogHub.Data.Models.CommonForms;
    using DogHub.Data.Models.Competitions;
    using DogHub.Data.Models.EvaluationForms;
    using DogHub.Web.ViewModels.CommonForms;

    public class CommonFormsService : ICommonFormsService
    {
        private readonly IDeletableEntityRepository<JudgeApplicationForm> judgeFormsRepository;
        private readonly IDeletableEntityRepository<EvaluationForm> evaluationFormsRepository;
        private readonly IDeletableEntityRepository<Dog> dogsRepository;
        private readonly IDeletableEntityRepository<Competition> competitionsRepository;
        private readonly IDeletableEntityRepository<EvaluationForm> evaluationForms;

        public CommonFormsService(
            IDeletableEntityRepository<JudgeApplicationForm> judgeFormsRepository,
            IDeletableEntityRepository<EvaluationForm> evaluationFormsRepository,
            IDeletableEntityRepository<Dog> dogsRepository,
            IDeletableEntityRepository<Competition> competitionsRepository,
            IDeletableEntityRepository<EvaluationForm> evaluationForms)
        {
            this.judgeFormsRepository = judgeFormsRepository;
            this.evaluationFormsRepository = evaluationFormsRepository;
            this.dogsRepository = dogsRepository;
            this.competitionsRepository = competitionsRepository;
            this.evaluationForms = evaluationForms;
        }

        public async Task ApplyForJudge(JudgeApplicationInputModel input)
        {
            var appForm = new JudgeApplicationForm
            {
                UserId = input.UserId,
                YearsOfExperience = input.YearsOfExperience,
                RaisedLitters = input.RaisedLitters,
                NumberOfChampionsOwned = input.NumberOfChampionsOwned,
                JudgeInstituteCertificateUrl = input.JudgeInstituteCertificateUrl,
            };

            if (input.HasBeenJudgeAssistant)
            {
                appForm.HasBeenJudgeAssistant = true;
            }
            else
            {
                appForm.HasBeenJudgeAssistant = false;
            }

            if (input.AttendedJudgeInstituteCourse)
            {
                appForm.AttendedJudgeInstituteCourse = true;
            }
            else
            {
                appForm.AttendedJudgeInstituteCourse = false;
            }

            await this.judgeFormsRepository.AddAsync(appForm);
            await this.judgeFormsRepository.SaveChangesAsync();
        }

        public bool HasAlreadyAppliedForJudge(string userId)
        {
            return this.judgeFormsRepository.All()
                .Where(x => x.UserId == userId)
                .Any();
        }

        public bool CheckIfUserHasVoted(string userId, int dogId, int competitionId)
        {
            var userHasVoted = this.evaluationForms.All()
                .Where(x => x.DogId == dogId && x.CompetitionId == competitionId)
                .ToList()
                .Any(y => y.UserId == userId);

            if (!userHasVoted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckIfUserIsOwner(string userId, int dogId, int competitionId)
        {
            var dogOwner = this.dogsRepository.All()
                .Where(x => x.Id == dogId)
                .Select(y => y.UserId)
                .FirstOrDefault();

            if (dogOwner != userId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsCompetitionCurrentlyInProgress(int competitionId)
        {
            var competition = this.competitionsRepository.All()
                .Where(x => x.Id == competitionId)
                .FirstOrDefault();

            if (competition.CompetitionStart < DateTime.Now && DateTime.Now < competition.CompetitionEnd)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task VoteForDog(VoteFormInputModel input, string userId)
        {
            var evaluationForm = new EvaluationForm
            {
                CompetitionId = input.CompetitionId,
                DogId = input.DogId,
                UserId = userId,
                TotalPoints = input.TotalPoints,
            };

            await this.evaluationFormsRepository.AddAsync(evaluationForm);
            await this.evaluationFormsRepository.SaveChangesAsync();
        }

        public string GetDogVideoByDogId(int dogId)
        {
            var videoString = this.dogsRepository.All()
                .Where(x => x.Id == dogId)
                .Select(v => v.DogVideoUrl)
                .FirstOrDefault();

            var firstIndex = videoString.IndexOf('/', 8);

            var substring = videoString.Substring(firstIndex, 9);

            videoString = videoString.Replace(substring, "/embed/");

            return videoString;
        }
    }
}
