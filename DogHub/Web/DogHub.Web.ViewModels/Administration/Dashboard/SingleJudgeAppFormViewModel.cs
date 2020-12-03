namespace DogHub.Web.ViewModels.Administration.Dashboard
{
    public class SingleJudgeAppFormViewModel
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int YearsOfExperience { get; set; }

        public int RaisedLitters { get; set; }

        public int NumberOfChampionsOwned { get; set; }

        public bool HasBeenJudgeAssistant { get; set; }

        public string JudgeInstituteCertificateUrl { get; set; }

        public string EvaluatorNotes { get; set; }
    }
}
