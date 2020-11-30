using AutoMapper;
using DogHub.Data.Models.CommonForms;
using DogHub.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace DogHub.Web.ViewModels.Judges
{
    public class JudgesListViewModel
    {
        public IEnumerable<SingleJudgeViewModel> JudgesList { get; set; }
    }
}
