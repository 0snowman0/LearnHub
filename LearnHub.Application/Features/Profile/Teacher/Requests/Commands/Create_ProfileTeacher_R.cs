using LearnHub.Application.Dto.profile.Teacher.command;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Profile.Teacher.Requests.Commands
{
    public class Create_ProfileTeacher_R : IRequest<BaseCommandResponse>
    {
        public Create_ProfileTeacher_Dto create_ProfileTeacher_Dto { get; set; } = null!;
        public  int UserId { get; set; }
    }
}
