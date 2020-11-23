namespace DogHub.Data.Models.Dogs
{
    using System;

    using DogHub.Data.Common.Models;

    public class DogImage : BaseModel<string>
    {
        public DogImage()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int DogId { get; set; }

        public virtual Dog Dog { get; set; }

        public string RemoteImageUrl { get; set; }

        public string Extension { get; set; }
    }
}
