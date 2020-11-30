namespace DogHub.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models.CommonForms;
    using DogHub.Services.Mapping;
    using DogHub.Web.ViewModels.Judges;

    public class JudgesService : IJudgesService
    {
        private readonly IDeletableEntityRepository<JudgeApplicationForm> judgeAppFormsRepository;

        public JudgesService(IDeletableEntityRepository<JudgeApplicationForm> judgeAppFormsRepository)
        {
            this.judgeAppFormsRepository = judgeAppFormsRepository;
        }

        public IEnumerable<SingleJudgeViewModel> JudgeDetails<T>()
        {
            var result = this.judgeAppFormsRepository.All()
                .To<SingleJudgeViewModel>()
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
    }
}
