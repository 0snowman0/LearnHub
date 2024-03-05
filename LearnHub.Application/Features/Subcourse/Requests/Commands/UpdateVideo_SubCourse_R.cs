using LearnHub.Application.Dto.Course.subcourse.command;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Subcourse.Requests.Commands
{
    public class UpdateVideo_SubCourse_R : IRequest<BaseCommandResponse>
    {
        public UpdateVedio_SubCourse_Dto updateVideo_SubCourse { get; set; } = null!;
    }
}
