namespace DogHub.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models.CommonForms;
    using DogHub.Data.Models.Competitions;
    using DogHub.Services.Mapping;
    using DogHub.Web.ViewModels.Judges;

    public class JudgesService : IJudgesService
    {
        private readonly IDeletableEntityRepository<JudgeApplicationForm> judgeAppFormsRepository;
        private readonly IDeletableEntityRepository<Competition> competitionsRepository;

        public JudgesService(
            IDeletableEntityRepository<JudgeApplicationForm> judgeAppFormsRepository,
            IDeletableEntityRepository<Competition> competitionsRepository)
        {
            this.judgeAppFormsRepository = judgeAppFormsRepository;
            this.competitionsRepository = competitionsRepository;
        }

        public IEnumerable<T> JudgeDetails<T>()
        {
            var result = this.judgeAppFormsRepository.All()
                .To<T>()
                .ToList();
            return result;
        }

        public JudgesListViewModel JudgesList()
        {
            var list = new JudgesListViewModel();
            list.JudgesList = this.JudgeDetails<SingleJudgeViewModel>()
                .Where(x => x.IsApproved);
            return list;
        }

        public DateTime JudgeApplicationFormApprovalDate(string userId)
        {
            var judgeAppFormApprovalDate = this.judgeAppFormsRepository.All()
                .Where(x => x.UserId == userId).Select(y => y.ApprovalDate).FirstOrDefault();

            return judgeAppFormApprovalDate;
        }
    }
}
