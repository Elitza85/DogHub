namespace DogHub.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models.Competitions;
    using DogHub.Web.ViewModels.Competitions;

    public class CompetitionsService : ICompetitionsService
    {
        private readonly DogHub.Data.Common.Repositories.IDeletableEntityRepository<Competition> competitionsRepository;
        private readonly IDeletableEntityRepository<Organiser> organisersRepository;

        public CompetitionsService(
            IDeletableEntityRepository<Competition> competitionsRepository,
            IDeletableEntityRepository<Organiser> organisersRepository)
        {
            this.competitionsRepository = competitionsRepository;
            this.organisersRepository = organisersRepository;
        }

        public async Task Create(CreateCompetitionInputModel input)
        {
            var competition = new Competition
            {
                BreedId = input.BreedId,
                CompetitionEnd = input.CompetitionEnd,
                CompetitionStart = input.CompetitionStart,
                Name = input.Name,
            };

            var organiser = this.organisersRepository.All()
                .FirstOrDefault(x => x.OrganiserName == input.OrganisedBy);
            if (organiser == null)
            {
                organiser = new Organiser
                {
                    OrganiserName = input.OrganisedBy,
                };
            }

            competition.Organiser = organiser;

            await this.competitionsRepository.AddAsync(competition);
            await this.competitionsRepository.SaveChangesAsync();
        }
    }
}
