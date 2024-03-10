using LearnHub.Application.Features.Admin.Comment.Requests.Queries;
using LearnHub.Application.Features.Admin.course.Requests.Commands;
using LearnHub.Application.Features.Admin.Financial.Handlers.Queries;
using LearnHub.Application.Features.Admin.Financial.Requests.Queries;
using LearnHub.Application.Features.SupportAdmin.Requests.Queries;
using LearnHub.Application.Responses;
using LearnHub.Identity.Features.profile.Admin.Requests.Commands;
using LearnHub.Identity.IdentityService.Abstract;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnHub.Api.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        private readonly Iuser _user;

        public AdminController(IMediator mediator, IUserService userService, Iuser user)
        {
            _mediator = mediator;
            _userService = userService;
            _user = user;
        }

        #region Comment

        [HttpGet("ReportComment")]
        public async Task<ActionResult<BaseCommandResponse>> GetReportComment()
        {
            var command = new GetReportComment_R { };
            var response = await _mediator.Send(command);

            return Ok(response);
        }


        [HttpPost("Confirm/Report/User")]
        public async Task<ActionResult<BaseCommandResponse>> ConfirmReportUser(List<int> CommentIds)
        {
            var command = new ConfirmReportUser_R { CommentId = CommentIds };
            var response = await _mediator.Send(command);

            return Ok(response);
        }


        [HttpPost("Releas/Report/User")]
        public async Task<ActionResult<BaseCommandResponse>> ReleasReportUser(string Email)
        {
            var user = await _user.GetUserByEmail(Email);

            var command = new ReleasReport_R { user = user };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        #endregion



        #region course

        [HttpPost("Approval/Courses")]
        public async Task<ActionResult<BaseCommandResponse>> ApprovalCourse(List<int> CourseIds)
        {

            var command = new CourseApproval_R { CourseIds = CourseIds };
            var response = await _mediator.Send(command);

            return Ok(response);
        }


        [HttpPost("NotApproval/Courses")]
        public async Task<ActionResult<BaseCommandResponse>> NotApprovalCourse(List<int> CourseIds)
        {

            var command = new NotApprovalCourse_R { CourseIds = CourseIds };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        #endregion



        #region FinanCial

        [HttpGet("GetAll_PurchasedCourses")]
        public async Task<ActionResult<BaseCommandResponse>> PurchasedCourses()
        {

            var command = new GetAll_PurchasedCourses_R { };
            var response = await _mediator.Send(command);

            return Ok(response);
        }


        [HttpGet("Get_PurchasedCourses/{CourseId}")]
        public async Task<ActionResult<BaseCommandResponse>> PurchasedCourses(int CourseId)
        {

            string Email = _userService.GetEmail();
            var user = await _user.GetUserByEmail(Email);

            var command = new Get_PurchasedCourses_R { CourseId = CourseId, TeacherName = user.Username };
            var response = await _mediator.Send(command);

            return Ok(response);
        }


        #endregion




    }
}