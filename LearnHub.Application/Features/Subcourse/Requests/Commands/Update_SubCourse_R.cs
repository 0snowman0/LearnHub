using LearnHub.Application.Dto.Course.subcourse.command;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Subcourse.Requests.Commands
{
    public class Update_SubCourse_R : IRequest<BaseCommandResponse>
    {
        public Update_SubCourse_Dto update_SubCourse { get; set; } = null!;
    }
}
