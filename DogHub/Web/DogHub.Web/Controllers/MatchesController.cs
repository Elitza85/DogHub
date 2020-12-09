using DogHub.Common;
using DogHub.Services.Data;
using DogHub.Web.ViewModels.DogMatches;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DogHub.Web.Controllers
{
    [Authorize(Roles = GlobalConstants.DogOwnerUserRoleName)]
    public class MatchesController : Controller
    {
        private readonly IMatchesService matchesService;

        public MatchesController(IMatchesService matchesService)
        {
            this.matchesService = matchesService;
        }

        public IActionResult FoundMatch(int id)
        {
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

        [HttpPost]
        public async Task<IActionResult> RejectRandomMatch()
        {
            this.TempData["Message"] = SuccessMessages.RejectRandomMatchProposalMsg;

            return this.Redirect("/Dashboards/Index");
        }

        [HttpPost]
        public async Task<IActionResult> ApproveRequest(int receiverDogId)
        {
            await this.matchesService.ApproveRequest(receiverDogId);

            return this.Redirect("/Dashboards/Index");
        }

        [HttpPost]
        public async Task<IActionResult> RejectRequest(int receiverDogId)
        {
            await this.matchesService.RejectRequest(receiverDogId);

            return this.Redirect("/Dashboards/Index");
        }
    }
}
