﻿using LearnHub.Application.Responses;
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
