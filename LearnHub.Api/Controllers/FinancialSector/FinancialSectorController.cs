using LearnHub.Application.Dto.store.command;
using LearnHub.Application.Features.Store.Requests.Commands;
using LearnHub.Application.Features.Store.Requests.Queries;
using LearnHub.Application.Features.SupportAdmin.Requests.Queries;
using LearnHub.Application.Responses;
using LearnHub.Identity.IdentityService.Abstract;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnHub.Api.Controllers.FinancialSector
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FinancialSectorController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        private readonly Iuser _user;

        public FinancialSectorController(IMediator mediator, IUserService userService, Iuser user)
        {
            _mediator = mediator;
            _userService = userService;
            _user = user;
        }


        #region Get

        [HttpGet("BuyCourse/{CourseId}")]
        public async Task<ActionResult<BaseCommandResponse>> BuyCourse(int CourseId)
        {

            string Email = _userService.GetEmail();
            var user = await _user.GetUserByEmail(Email);


            var command = new BuyCourse_R { CourseId = CourseId, UserId = user.Id };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        #endregion


        #region Post

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> FinallyBuy(RequesFromZarinpal_Dto requesFromZarinpal_Dto)
        {
            string Email = _userService.GetEmail();
            var user = await _user.GetUserByEmail(Email);


            var command = new FinallyBuyCourse_R { requesFromZarinpal = requesFromZarinpal_Dto };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        #endregion
    }
}
