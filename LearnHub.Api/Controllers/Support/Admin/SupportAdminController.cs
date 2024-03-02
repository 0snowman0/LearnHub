using LearnHub.Application.Dto.Support.SupportAdmin.command;
using LearnHub.Application.Features.SupportAdmin.Requests.Commands;
using LearnHub.Application.Features.SupportAdmin.Requests.Queries;
using LearnHub.Application.Responses;
using LearnHub.Identity.IdentityService.Abstract;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnHub.Api.Controllers.Support.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SupportAdminController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        private readonly Iuser _user;

        public SupportAdminController(IMediator mediator, IUserService userService, Iuser user)
        {
            _mediator = mediator;
            _userService = userService;
            _user = user;
        }


        #region Get

        [HttpGet("GetAll/SupportAdmin")]
        public async Task<ActionResult<BaseCommandResponse>> GetAll()
        {
            var command = new GetAll_SupportAdmin_R { };
            var response = await _mediator.Send(command);

            return Ok(response);
        }


        [HttpGet("Get/SupportAdmin/{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Get(int id)
        {
            var command = new Get_SupportAdmin_R { Id = id };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [Authorize]
        [HttpGet("GetAll/SupportAdmin/Uesr")]
        public async Task<ActionResult<BaseCommandResponse>> GetWithUserId()
        {
            string Email = _userService.GetEmail();
            var user = await _user.GetUserByEmail(Email);

            var command = new GetWithUserId_SupportAdmin_R { AdminId = user.Id };
            var response = await _mediator.Send(command);

            return Ok(response);
        }
        #endregion


        #region post

        [HttpPost("Create/SupportStudent")]
        public async Task<ActionResult<BaseCommandResponse>> Create
            (Create_SupportAdmin_Dto create_SupportAdmin_Dto)
        {
            string Email = _userService.GetEmail();
            var user = await _user.GetUserByEmail(Email);

            var command = new Create_SupportAdmin_R
            { create_SupportAdmin_Dto = create_SupportAdmin_Dto, AdminId = user.Id };

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        #endregion


        #region Delete

        [HttpDelete("Delete/SupportStudent")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(List<int> Ids)
        {
            var command = new Delete_SupportAdmin_R { Ids = Ids };

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        #endregion

        #region Update

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Update
            (Update_SupportAdmin_Dto update_SupportAdmin_Dto)
        {
            var command = new Update_SupportAdmin_R { update_SupportAdmin_Dto = update_SupportAdmin_Dto };

            var response = await _mediator.Send(command);

            return Ok(response);

        }
        #endregion

    }
}
