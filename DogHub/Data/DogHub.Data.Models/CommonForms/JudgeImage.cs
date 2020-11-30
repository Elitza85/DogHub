using DogHub.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DogHub.Data.Models.CommonForms
{
    public class JudgeImage : BaseModel<string>
    {
        public JudgeImage()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string Extension { get; set; }
    }
}
