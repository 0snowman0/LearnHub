﻿using LearnHub.Identity.Model.Dto;
using MediatR;

namespace LearnHub.Identity.Features.Login.Requests
{
    public class Login_R : IRequest<string>
    {
        public Login_Dto login_Dto { get; set; } = null!;
    }
}
