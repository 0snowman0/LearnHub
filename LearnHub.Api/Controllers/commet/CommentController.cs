using LearnHub.Application.Dto.comment.command;
using LearnHub.Application.Dto.Support.SupportStudent.command;
using LearnHub.Application.Features.comment.Requests.Commands;
using LearnHub.Application.Features.comment.Requests.Queries;
using LearnHub.Application.Features.SupportStudent.Requests.Commands;
using LearnHub.Application.Features.SupportStudent.Requests.Queries;
using LearnHub.Application.Responses;
using LearnHub.Identity.IdentityService.Abstract;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnHub.Api.Controllers.commet
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        private readonly Iuser _user;
        public CommentController(IMediator mediator, IUserService userService, Iuser user)
        {
            _mediator = mediator;
            _userService = userService;
            _user = user;
        }




        #region Get

        [HttpGet("GetAll/ReportComment")]
        public async Task<ActionResult<BaseCommandResponse>> GetReport()
        {
            var command = new GetReport_Comment_R { };
            var response = await _mediator.Send(command);

            return Ok(response);
        }


        [HttpGet("Get/CourseComment/{Courseid}")]
        public async Task<ActionResult<BaseCommandResponse>> Get(int Courseid)
        {
            var command = new GetWithCourseId_Comment_R { CourseId = Courseid };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        #endregion


        #region post

        [HttpPost("Create/NewComment")]
        public async Task<ActionResult<BaseCommandResponse>> Create
            (Create_Comment_Dto create_Comment_Dto)
        {
            string Email = _userService.GetEmail();
            var user = await _user.GetUserByEmail(Email);

            var command = new Create_Comment_R
            { create_Comment_Dto = create_Comment_Dto, UserId = user.Id };

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        #endregion


        #region Delete

        [HttpDelete("Delete/SupportStudent")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(List<int> Ids)
        {
            var command = new Delete_Comment_R { Ids = Ids };

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        #endregion

        #region Update

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Update
            (Update_Comment_Dto update_Comment_Dto)
        {
            var command = new Update_Comment_R { update_Comment_Dto = update_Comment_Dto };

            var response = await _mediator.Send(command);

            return Ok(response);

        }
        #endregion

    }
}
