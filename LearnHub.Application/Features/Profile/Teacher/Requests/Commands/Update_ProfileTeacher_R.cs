using LearnHub.Application.Dto.profile.Student.command;
using LearnHub.Application.Dto.profile.Teacher.command;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Profile.Teacher.Requests.Commands
{
    public class Update_ProfileTeacher_R : IRequest<BaseCommandResponse>
    {
        public Update_ProfileTeacher_Dto update_ProfileTeacher { get; set; } = null!;
        public  int UserId { get; set; }
    }
}
