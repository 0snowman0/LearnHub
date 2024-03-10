using LearnHub.Application.Dto.profile.Student.command;
using LearnHub.Application.Dto.profile.Teacher.command;
using LearnHub.Application.Features.Profile.Student.Requests.Queries;
using LearnHub.Application.Features.Profile.Teacher.Handlers.Commands;
using LearnHub.Application.Features.Profile.Teacher.Requests.Commands;
using LearnHub.Application.Features.Profile.Teacher.Requests.Queries;
using LearnHub.Application.Responses;
using LearnHub.Identity.IdentityService.Abstract;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnHub.Api.Controllers.Profile.Teacher
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TeacherProfileController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        private readonly Iuser _user;

        public TeacherProfileController(IMediator mediator, IUserService userService, Iuser user)
        {
            _mediator = mediator;
            _userService = userService;
            _user = user;
        }


        #region Get

        [HttpGet("GetProfileTeacher/")]
        public async Task<ActionResult<BaseCommandResponse>> GetProfileTeacher()
        {

            string Email = _userService.GetEmail();
            var user = await _user.GetUserByEmail(Email);


            var command = new Get_ProfileTeacher_R { UserId = user.Id , UserName = user.Username};
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        #endregion


        #region Post

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> CreateProfileTeacher
            ([FromForm]Create_ProfileTeacher_Dto create_ProfileTeacher)
        {
            string Email = _userService.GetEmail();
            var user = await _user.GetUserByEmail(Email);


            var command = new Create_ProfileTeacher_R {create_ProfileTeacher_Dto = create_ProfileTeacher, UserId = user.Id };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        #endregion


        #region Update

        [HttpPut("Update/ProfileTeacher/")]
        public async Task<ActionResult<BaseCommandResponse>> UpdateProfileTeacher
            (Update_ProfileTeacher_Dto update_ProfileTeacher)
        {

            string Email = _userService.GetEmail();
            var user = await _user.GetUserByEmail(Email);


            var command = new Update_ProfileTeacher_R { update_ProfileTeacher = update_ProfileTeacher, UserId = user.Id };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        #endregion

    }
}
