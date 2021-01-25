namespace DogHub.Services.Data.ImagesServices
{
    using System.Threading.Tasks;

    using DogHub.Data.Models;
    using DogHub.Data.Models.CommonForms;
    using DogHub.Data.Models.Competitions;
    using DogHub.Web.ViewModels.CommonForms;
    using DogHub.Web.ViewModels.Competitions;
    using DogHub.Web.ViewModels.Dogs;

    public interface IImagesService
    {
        Task AddDogImages(Dog dog, RegisterDogInputModel input, string imagePath);

        Task AddCompetitionImage(Competition competition, CreateCompetitionInputModel input, string imagePath);

        Task AddJudgeImage(JudgeApplicationForm appForm, JudgeApplicationInputModel input, string imagePath);
    }
}
