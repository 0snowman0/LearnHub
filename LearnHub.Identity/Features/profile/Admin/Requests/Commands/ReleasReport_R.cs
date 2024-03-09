using LearnHub.Application.Responses;
using LearnHub.Identity.Model.En;
using MediatR;

namespace LearnHub.Identity.Features.profile.Admin.Requests.Commands
{
    public class ReleasReport_R : IRequest<BaseCommandResponse>
    {
        public User_En user { get; set; } = null!;
    }
}
