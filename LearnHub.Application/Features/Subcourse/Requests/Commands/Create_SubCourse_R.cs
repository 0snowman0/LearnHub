using LearnHub.Application.Dto.Course.subcourse.command;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Subcourse.Requests.Commands
{
    public class Create_SubCourse_R : IRequest<BaseCommandResponse>
    {
        public Create_SubCourse_Dto create_SubCourse { get; set; } = null!;
    }
}
