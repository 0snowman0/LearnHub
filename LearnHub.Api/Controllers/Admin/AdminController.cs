using LearnHub.Application.Features.Admin.Comment.Requests.Queries;
using LearnHub.Application.Features.Admin.course.Requests.Commands;
using LearnHub.Application.Features.Admin.Financial.Handlers.Queries;
using LearnHub.Application.Features.Admin.Financial.Requests.Queries;
using LearnHub.Application.Features.Permistion.Requests.Queries;
using LearnHub.Application.Features.SupportAdmin.Requests.Queries;
using LearnHub.Application.Responses;
using LearnHub.Domain.Model.Comment;
using LearnHub.Domain.Model.course;
using LearnHub.Identity.Features.profile.Admin.Requests.Commands;
using LearnHub.Identity.IdentityService.Abstract;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            string Email = _userService.GetEmail();
            var user = await _user.GetUserByEmail(Email);

            #region Check Permistion
            var PermistionCommand = new CheckPermistion_R { UesrId = user.Id, PermistionType = new Comment_En() };
            var Permistion = await _mediator.Send(PermistionCommand);

            if (!Permistion)
                return StatusCode(401);
            #endregion


            var command = new GetReportComment_R { };
            var response = await _mediator.Send(command);

            return Ok(response);
        }


        [HttpPost("Confirm/Report/User")]
        public async Task<ActionResult<BaseCommandResponse>> ConfirmReportUser(List<int> CommentIds)
        {
            string Email = _userService.GetEmail();
            var user = await _user.GetUserByEmail(Email);

            #region Check Permistion
            var PermistionCommand = new CheckPermistion_R { UesrId = user.Id, PermistionType = new Comment_En() };
            var Permistion = await _mediator.Send(PermistionCommand);

            if (!Permistion)
                return StatusCode(401);
            #endregion


            var command = new ConfirmReportUser_R { CommentId = CommentIds };
            var response = await _mediator.Send(command);

            return Ok(response);
        }


        [HttpPost("Releas/Report/User")]
        public async Task<ActionResult<BaseCommandResponse>> ReleasReportUser(string Email)
        {
            string Email1 = _userService.GetEmail();
            var user = await _user.GetUserByEmail(Email1);

            #region Check Permistion
            var PermistionCommand = new CheckPermistion_R { UesrId = user.Id, PermistionType = new Comment_En() };
            var Permistion = await _mediator.Send(PermistionCommand);

            if (!Permistion)
                return StatusCode(401);
            #endregion

            var userEmail = await _user.GetUserByEmail(Email);

            var command = new ReleasReport_R { user = userEmail };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        #endregion



        #region course

        [HttpPost("Approval/Courses")]
        public async Task<ActionResult<BaseCommandResponse>> ApprovalCourse(List<int> CourseIds)
        {
            string Email1 = _userService.GetEmail();
            var user = await _user.GetUserByEmail(Email1);

            #region Check Permistion
            var PermistionCommand = new CheckPermistion_R { UesrId = user.Id, PermistionType = new Course_En() };
            var Permistion = await _mediator.Send(PermistionCommand);

            if (!Permistion)
                return StatusCode(401);
            #endregion


            var command = new CourseApproval_R { CourseIds = CourseIds };
            var response = await _mediator.Send(command);

            return Ok(response);
        }


        [HttpPost("NotApproval/Courses")]
        public async Task<ActionResult<BaseCommandResponse>> NotApprovalCourse(List<int> CourseIds)
        {
            string Email1 = _userService.GetEmail();
            var user = await _user.GetUserByEmail(Email1);

            #region Check Permistion
            var PermistionCommand = new CheckPermistion_R { UesrId = user.Id, PermistionType = new Course_En() };
            var Permistion = await _mediator.Send(PermistionCommand);

            if (!Permistion)
                return StatusCode(401);
            #endregion


            var command = new NotApprovalCourse_R { CourseIds = CourseIds };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        #endregion



        #region FinanCial

        [HttpGet("GetAll_PurchasedCourses")]
        public async Task<ActionResult<BaseCommandResponse>> PurchasedCourses()
        {
            string Email1 = _userService.GetEmail();
            var user = await _user.GetUserByEmail(Email1);

            #region Check Permistion
            var PermistionCommand = new CheckPermistion_R { UesrId = user.Id, PermistionType = "other type" };
            var Permistion = await _mediator.Send(PermistionCommand);

            if (!Permistion)
                return StatusCode(401);
            #endregion



            var command = new GetAll_PurchasedCourses_R { };
            var response = await _mediator.Send(command);

            return Ok(response);
        }


        [HttpGet("Get_PurchasedCourses/{CourseId}")]
        public async Task<ActionResult<BaseCommandResponse>> PurchasedCourses(int CourseId)
        {

            string Email1 = _userService.GetEmail();
            var user1 = await _user.GetUserByEmail(Email1);

            #region Check Permistion
            var PermistionCommand = new CheckPermistion_R { UesrId = user1.Id, PermistionType = "other type" };
            var Permistion = await _mediator.Send(PermistionCommand);

            if (!Permistion)
                return StatusCode(401);
            #endregion



            string Email = _userService.GetEmail();
            var user = await _user.GetUserByEmail(Email);

            var command = new Get_PurchasedCourses_R { CourseId = CourseId, TeacherName = user.Username };
            var response = await _mediator.Send(command);

            return Ok(response);
        }


        #endregion




    }
}