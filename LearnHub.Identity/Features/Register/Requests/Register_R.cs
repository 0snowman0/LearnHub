﻿using LearnHub.Identity.Model.Dto;
using LearnHub.Identity.Model.En;
using MediatR;

namespace LearnHub.Identity.Features.Register.Requests
{
    public class Register_R : IRequest<User_En>
    {
        public Register_Dto register_Dto { get; set; } = null!;
    }
}
