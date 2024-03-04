using LearnHub.Application.Dto.Course.course.command;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Course.Requests.Commands
{
    public class Update_Course_R : IRequest<BaseCommandResponse>
    {
        public Update_Course_Dto update_Course { get; set; } = null!;
    }
}
