using DogHub.Web.ViewModels.CommonForms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DogHub.Services.Data
{
    public interface ICommonFormsService
    {
        Task ApplyForJudge(JudgeApplicationInputModel input);
    }
}
