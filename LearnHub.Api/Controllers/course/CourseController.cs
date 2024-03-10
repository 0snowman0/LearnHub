using LearnHub.Application.Dto.Course.course.command;
using LearnHub.Application.Features.Course.Requests.Commands;
using LearnHub.Application.Features.Course.Requests.Queries;
using LearnHub.Application.Responses;
using LearnHub.Identity.IdentityService.Abstract;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnHub.Api.Controllers.course
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        private readonly Iuser _user;

        public CourseController(IMediator mediator, IUserService userService, Iuser user)
        {
            _mediator = mediator;
            _userService = userService;
            _user = user;
        }



        #region Get

        [HttpGet("GetAll/Cousre")]
        public async Task<ActionResult<BaseCommandResponse>> GetAll()
        {
            var command = new GetAll_Course_R { };
            var response = await _mediator.Send(command);

            return Ok(response);
        }


        [HttpGet("Get/SupportAdmin/{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Get(int id)
        {
            var command = new Get_Course_R { Id = id };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [Authorize]
        [HttpGet("GetAll/Cousre/Teacher")]
        public async Task<ActionResult<BaseCommandResponse>> GetWithUserId()
        {
            string Email = _userService.GetEmail();
            var user = await _user.GetUserByEmail(Email);

            var command = new GetWithTeacherId_Course_R { TeacherId = user.Id };
            var response = await _mediator.Send(command);

            return Ok(response);
        }
        #endregion


        #region post

        [HttpPost("Create/Course")]
        public async Task<ActionResult<BaseCommandResponse>> Create
            ([FromForm] Create_Course_Dto create_Course_Dto)
        {
            string Email = _userService.GetEmail();
            var user = await _user.GetUserByEmail(Email);

            var command = new Create_Course_R
            { create_Course_Dto = create_Course_Dto, TeacherId = user.Id };

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        #endregion


        #region Delete

        [HttpDelete("Delete/Course")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(List<int> Ids)
        {
            var command = new Delete_Course_R { Ids = Ids };

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        #endregion

        #region Update


        #endregion


    }
}
