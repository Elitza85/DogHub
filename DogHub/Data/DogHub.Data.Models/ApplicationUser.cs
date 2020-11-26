// ReSharper disable VirtualMemberCallInConstructor
namespace DogHub.Data.Models
{
    using System;
    using System.Collections.Generic;

    using DogHub.Data.Common.Models;
    using DogHub.Data.Models.CommonForms;
    using DogHub.Data.Models.EvaluationForms;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.EvalutionForms = new HashSet<EvaluationForm>();
            this.Dogs = new HashSet<Dog>();
        }

        public int Age { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual JudgeApplicationForm JudgeApplicationForm { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<EvaluationForm> EvalutionForms { get; set; }

        public virtual ICollection<Dog> Dogs { get; set; }
    }
}
