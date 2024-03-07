using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Identity.Features.Admin.Requests.Commands
{
    public class ReleasReport_R : IRequest<BaseCommandResponse>
    {
        public List<int> CommentId { get; set; } = null!;
    }
}
