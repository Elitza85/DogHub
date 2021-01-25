namespace DogHub.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using DogHub.Common;
    using DogHub.Data.Common.Repositories;
    using DogHub.Data.Models;
    using DogHub.Services.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.DogOwnerUserRoleName)]
    public class MatchesController : Controller
    {
        private readonly IMatchesService matchesService;
        private readonly IDeletableEntityRepository<Dog> dogsRepository;

        public MatchesController(
            IMatchesService matchesService,
            IDeletableEntityRepository<Dog> dogsRepository)
        {
            this.matchesService = matchesService;
            this.dogsRepository = dogsRepository;
        }

        public IActionResult FoundMatch(int id)
        {
            var dogIsSpayed = this.matchesService.IsDogSpayedOrNeutered(id);
            if (dogIsSpayed)
            {
                return this.Redirect("/Errors/NotNecessaryToSearchPartner");
            }

            var viewModel = this.matchesService.GetBothDogs(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AcceptRandomMatch(int senderDogId, int receiverDogId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.matchesService.SendMatchRequest(senderDogId, receiverDogId, userId);
            await this.matchesService.ReceiveMatchRequest(senderDogId, receiverDogId);

            this.TempData["Message"] = SuccessMessages.DogPartnershipRequestSentMsg;

            return this.Redirect("/Dashboards/Index");
        }

        public IActionResult RejectRandomMatch()
        {
            this.TempData["Message"] = SuccessMessages.RejectRandomMatchProposalMsg;

            return this.Redirect("/Dashboards/Index");
        }

        [HttpPost]
        public async Task<IActionResult> ApproveRequest(int receiverDogId, int senderDogId)
        {
            await this.matchesService.ApproveRequest(receiverDogId, senderDogId);

            return this.Redirect("/Dashboards/Index");
        }

        [HttpPost]
        public async Task<IActionResult> RejectRequest(int receiverDogId, int senderDogId)
        {
            await this.matchesService.RejectRequest(receiverDogId, senderDogId);

            return this.Redirect("/Dashboards/Index");
        }
    }
}
