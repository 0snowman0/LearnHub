using LearnHub.Application.Dto.Course.course.command;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Course.Requests.Commands
{
    public class Create_Course_R : IRequest<BaseCommandResponse>
    {
        public Create_Course_Dto create_Course_Dto { get; set; } = null!;
        public  int TeacherId { get; set; }
    }
}
