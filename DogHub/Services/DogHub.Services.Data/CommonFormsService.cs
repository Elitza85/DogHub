using DogHub.Data.Common.Repositories;
using DogHub.Data.Models.CommonForms;
using DogHub.Data.Models.EvaluationForms;
using DogHub.Web.ViewModels.CommonForms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DogHub.Services.Data
{
    public class CommonFormsService : ICommonFormsService
    {
        private readonly IDeletableEntityRepository<JudgeApplicationForm> judgeFormsRepository;
        private readonly IDeletableEntityRepository<EvaluationForm> evaluationFormsRepository;

        public CommonFormsService(
            IDeletableEntityRepository<JudgeApplicationForm> judgeFormsRepository,
            IDeletableEntityRepository<EvaluationForm> evaluationFormsRepository)
        {
            this.judgeFormsRepository = judgeFormsRepository;
            this.evaluationFormsRepository = evaluationFormsRepository;
        }

        public async Task ApplyForJudge(JudgeApplicationInputModel input)
        {
            var appForm = new JudgeApplicationForm
            {
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

        public async Task VoteForDog(VoteFormInputModel input)
        {
            
            var evaluationForm = new EvaluationForm
            {
                //BalanceRate = input.BalanceRate,
                //ColorRate = input.ColorRate,
                //EarsRate = input.EarsRate,
                //EyesRate = input.EyesRate,
                //HeadShapeRate = input.HeadShapeRate,
                //MuzzleRate = input.MuzzleRate,
                //WeightRate = input.WeightRate,
                CompetitionId = input.CompetitionId,
                DogId = input.DogId,
                UserId = input.UserId,
                TotalPoints = input.TotalPoints,
            };
            //foreach (var item in input.BalanceRate)
            //{

            //    var result = item.Rate1;
            //}

            await this.evaluationFormsRepository.AddAsync(evaluationForm);
            await this.evaluationFormsRepository.SaveChangesAsync();
        }
    }
}
