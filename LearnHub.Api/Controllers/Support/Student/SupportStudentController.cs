using LearnHub.Application.Dto.Support.SupportStudent.command;
using LearnHub.Application.Features.SupportStudent.Requests.Commands;
using LearnHub.Application.Features.SupportStudent.Requests.Queries;
using LearnHub.Application.Responses;
using LearnHub.Identity.IdentityService.Abstract;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnHub.Api.Controllers.Support.Student
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SupportStudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        private readonly Iuser _user;
        public SupportStudentController(IMediator mediator, IUserService userService, Iuser user)
        {
            _mediator = mediator;
            _userService = userService;
            _user = user;
        }


        #region Get

        [HttpGet("GetAll/SupportStudent")]
        public async Task<ActionResult<BaseCommandResponse>> GetAll()
        {
            var command = new GetAll_SupportStudent_R { };
            var response = await _mediator.Send(command);

            return Ok(response);
        }


        [HttpGet("Get/SupportStudent/{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Get(int id)
        {
            var command = new Get_SupportStudent_R { Id = id };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [Authorize]
        [HttpGet("GetAll/SupportStudent/Uesr")]
        public async Task<ActionResult<BaseCommandResponse>> GetWithUserId()
        {
            string Email = _userService.GetEmail();
            var user = await _user.GetUserByEmail(Email);

            var command = new GetWithUserId_SupportStudent_R { UserId = user.Id };
            var response = await _mediator.Send(command);

            return Ok(response);
        }
        #endregion


        #region post

        [HttpPost("Create/SupportStudent")]
        public async Task<ActionResult<BaseCommandResponse>> Create
            (Create_SupportStudent_Dto create_SupportStudent_Dto)
        {
            string Email = _userService.GetEmail();
            var user = await _user.GetUserByEmail(Email);

            var command = new Create_SupportStudent_R
            { create_SupportStudent_Dto = create_SupportStudent_Dto, UserId = user.Id };

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        #endregion


        #region Delete

        [HttpDelete("Delete/SupportStudent")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(List<int> Ids)
        {
            var command = new Delete_SupportStudent_R { Ids = Ids };

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        #endregion

        #region Update
        
        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Update
            (Update_SupportStudent_Dto update_SupportStudent_Dto)
        {
            var command = new Update_SupportStudent_R { update_SupportStudent_Dto = update_SupportStudent_Dto};

            var response = await _mediator.Send(command);

            return Ok(response);

        }
        #endregion

    }
}

