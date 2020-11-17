using DogHub.Data.Common.Repositories;
using DogHub.Data.Models.CommonForms;
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

        public CommonFormsService(IDeletableEntityRepository<JudgeApplicationForm> judgeFormsRepository)
        {
            this.judgeFormsRepository = judgeFormsRepository;
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
    }
}
