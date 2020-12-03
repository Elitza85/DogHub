namespace DogHub.Web.ViewModels.Administration.Dashboard
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class JudgeAppFormsViewModel
    {
        public IEnumerable<SingleJudgeAppFormViewModel> FormsList { get; set; }

        [Required]
        [Display(Name = "Add Reason for Rejecting the Application")]
        public string EvaluatorNotes { get; set; }

        public string UserId { get; set; }
    }
}
