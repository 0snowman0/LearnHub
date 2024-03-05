using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Subcourse.Requests.Commands
{
    public class Delete_SubCourse_R : IRequest<BaseCommandResponse>
    {
        public List<int> Ids { get; set; } = null!;
    }
}
