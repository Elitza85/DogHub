using DogHub.Web.ViewModels.Judges;
using System.Collections.Generic;

namespace DogHub.Services.Data
{
    public interface IJudgesService
    {
        IEnumerable<SingleJudgeViewModel> JudgeDetails<T>();

        public JudgesListViewModel JudgesList();
    }
}
