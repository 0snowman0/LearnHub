﻿using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Course.Requests.Queries
{
    public class Get_Course_R : IRequest<BaseCommandResponse>
    {
        public  int Id { get; set; }

    }
}
