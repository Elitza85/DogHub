namespace DogHub.Web.ViewModels.Dogs
{
    using System.IO;

    public class DogImageInputModel
    {
        public string Id { get; set; }

        public Stream Content { get; set; }
    }
}
