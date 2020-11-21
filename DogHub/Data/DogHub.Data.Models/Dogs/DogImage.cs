namespace DogHub.Data.Models.Dogs
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using DogHub.Data.Common.Models;
    using Microsoft.AspNetCore.Http;

    public class DogImage : BaseDeletableModel<int>
    {
        public int DogId { get; set; }

        public virtual Dog Dog { get; set; }

        //public IFormFile Image { get; set; }

        public string RemoteImageUrl { get; set; }
        public string Extension { get; set; }
    }
}
