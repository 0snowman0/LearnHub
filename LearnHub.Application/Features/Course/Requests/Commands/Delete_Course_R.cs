using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.Course.Requests.Commands
{
    public class Delete_Course_R : IRequest<BaseCommandResponse>
    {
        public List<int> Ids { get; set; } = null!;
    }
}
