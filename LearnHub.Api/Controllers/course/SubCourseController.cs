using LearnHub.Application.Dto.Course.course.command;
using LearnHub.Application.Dto.Course.subcourse.command;
using LearnHub.Application.Features.Course.Requests.Commands;
using LearnHub.Application.Features.Course.Requests.Queries;
using LearnHub.Application.Features.Subcourse.Handlers.Commands;
using LearnHub.Application.Features.Subcourse.Requests.Commands;
using LearnHub.Application.Features.Subcourse.Requests.Queries;
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
    public class SubCourseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        private readonly Iuser _user;

        public SubCourseController(IMediator mediator, IUserService userService, Iuser user)
        {
            _mediator = mediator;
            _userService = userService;
            _user = user;
        }


        #region Get

        [HttpGet("GetAll/SubCousre")]
        public async Task<ActionResult<BaseCommandResponse>> GetAll()
        {
            var command = new Get_SubCourse_R { };
            var response = await _mediator.Send(command);

            return Ok(response);
        }


        [HttpGet("Get/SubCourse/{Courseid}")]
        public async Task<ActionResult<BaseCommandResponse>> Get(int Courseid)
        {
            var command = new GetWithCourseId_SubCourse_R { CourseId = Courseid };
            var response = await _mediator.Send(command);

            return Ok(response);
        }


        #endregion


        #region post

        [HttpPost("Create/SubCourse")]
        public async Task<ActionResult<BaseCommandResponse>> Create
            ([FromForm] Create_SubCourse_Dto create_SubCourse_Dto)
        {
            string Email = _userService.GetEmail();
            var user = await _user.GetUserByEmail(Email);

            var command = new Create_SubCourse_R
            { create_SubCourse = create_SubCourse_Dto };

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        #endregion


        #region Delete

        [HttpDelete("Delete/Course")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(List<int> Ids)
        {
            var command = new Delete_SubCourse_R { Ids = Ids };

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        #endregion


        #region Update

        [HttpPut("Update/SubCourse")]
        public async Task<ActionResult<BaseCommandResponse>> Update(Update_SubCourse_Dto update_SubCourse)
        {

            var command = new Update_SubCourse_R { update_SubCourse = update_SubCourse };

            var response = await _mediator.Send(command);

            return Ok(response);
        }


        [HttpPut("Update/SubCourse/Vedio")]
        public async Task<ActionResult<BaseCommandResponse>> UpdateVideo
            ([FromForm] UpdateVedio_SubCourse_Dto update_SubCourse)
        {

            var command = new UpdateVideo_SubCourse_R { updateVideo_SubCourse = update_SubCourse };

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        #endregion
    }
}
