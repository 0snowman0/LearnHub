﻿using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Profile.Student.Requests.Queries
{
    public class Create_ProfileStudent_R : IRequest<BaseCommandResponse>
    {
        public  int UserId { get; set; }
    }
}
