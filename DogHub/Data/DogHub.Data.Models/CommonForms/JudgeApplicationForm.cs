﻿namespace DogHub.Data.Models.CommonForms
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using DogHub.Data.Common.Models;

    public class JudgeApplicationForm : BaseDeletableModel<int>
    {
        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual JudgeImage JudgeImage { get; set; }

        public int YearsOfExperience { get; set; }

        public int RaisedLitters { get; set; }

        public int NumberOfChampionsOwned { get; set; }

        // it should be true to be able to become a judge
        public bool HasBeenJudgeAssistant { get; set; }

        // should be true
        public bool AttendedJudgeInstituteCourse { get; set; }

        [Required]
        public string JudgeInstituteCertificateUrl { get; set; }

        public string EvaluatorNotes { get; set; }

        public string SelfDescription { get; set; }

        public bool IsApproved { get; set; }

        public DateTime ApprovalDate { get; set; }

        public bool IsUnderReview { get; set; }

        public bool IsRejected { get; set; }
    }
}
