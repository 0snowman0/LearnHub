
using LearnHub.Application.Dto.profile.Student.command;
using LearnHub.Application.Features.Profile.Student.Requests.Queries;
using LearnHub.Application.Responses;
using LearnHub.Identity.Features.profile.Student.Requests.Commands;
using LearnHub.Identity.IdentityService.Abstract;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnHub.Api.Controllers.Profile.Student
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentProfileController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        private readonly Iuser _user;

        public StudentProfileController(IMediator mediator, IUserService userService, Iuser user)
        {
            _mediator = mediator;
            _userService = userService;
            _user = user;
        }



        [HttpGet("ProfileStudent")]
        public async Task<ActionResult<BaseCommandResponse>> Get_ProfileStudent()
        {
            string Email = _userService.GetEmail();
            var user = await _user.GetUserByEmail(Email);


            var command = new Create_ProfileStudent_R { UserId = user.Id };
            var response = await _mediator.Send(command);

            return Ok(response);

        }


        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Update_ProfileStudent
            (Update_ProfileStudent_Dto update_ProfileStudent_Dto)
        {
            string Email = _userService.GetEmail();
            var user = await _user.GetUserByEmail(Email);


            var command = new Update_ProfileStudent_R { update_ProfileStudent = update_ProfileStudent_Dto, UserId = user.Id };
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
