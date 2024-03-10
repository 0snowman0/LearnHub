using AutoMapper.Configuration.Conventions;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Profile.Teacher.Requests.Queries
{
    public class Get_ProfileTeacher_R : IRequest<BaseCommandResponse>
    {
        public  int UserId { get; set; }
        public string UserName { get; set; } = null!;
    }
}
