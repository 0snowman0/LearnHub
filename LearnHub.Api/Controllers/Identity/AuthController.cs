using LearnHub.Application.Responses;
using LearnHub.Email;
using LearnHub.Email.Features.Requests.Commands;
using LearnHub.Email.Model;
using LearnHub.Identity.Features.Login.Requests;
using LearnHub.Identity.Features.Register.Requests;
using LearnHub.Identity.IdentityService.Abstract;
using LearnHub.Identity.Model.Dto;
using LearnHub.Identity.Model.En;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnHub.Api.Controllers.Identity
{
    public class AuthController
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        public AuthController(IMediator mediator, IUserService userService)
        {
            _mediator = mediator;
            _userService = userService;
        }

        [Authorize]
        [HttpGet("getMe")]
        public async Task<ActionResult<string>> GetMe()
        {
            var responce = _userService.GetMyName();
            return responce;
        }

        [HttpPost("Regitster")]
        public async Task<ActionResult<BaseCommandResponse>> Register([FromForm] Register_Dto register_Dto)
        {
            var responce = await _mediator.Send(new Register_R { register_Dto = register_Dto });


            #region Send Email

            if(responce.StatusCode == 200)
            {
                var email = new EmailDto()
                {
                    To = register_Dto.Email.ToString(),
                    Subject = "Register",
                    Body = $"<h1>hello {register_Dto.UserName} welcome to LearnHub 👍</h1>"
                };

                var statusSendEmail = await _mediator.Send(new SendEmail_R { email = email });

                if(statusSendEmail == false)
                    responce.Errors = new List<string> {" Email not send for user"};

            }
            #endregion

            return responce;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(Login_Dto request)
        {
            var responce = await _mediator.Send(new Login_R { login_Dto = request });
            return responce;
        }


        [HttpPost("registerAdmin")]
        public async Task<ActionResult<BaseCommandResponse>> RegisterAdmin(RegisterAdmin_Dto request)
        {
            var responce = await _mediator.Send(new RegisterAdmin_R { registerAdmin = request });
            return responce;
        }
    }
}
