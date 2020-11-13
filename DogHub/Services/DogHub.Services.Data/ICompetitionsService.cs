namespace DogHub.Services.Data
{
    using System.Threading.Tasks;

    using DogHub.Web.ViewModels.Competitions;

    public interface ICompetitionsService
    {
        Task Create(CreateCompetitionInputModel input);
    }
}
