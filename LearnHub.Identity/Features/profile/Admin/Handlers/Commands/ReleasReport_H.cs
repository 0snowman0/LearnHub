using LearnHub.Application.Contracts.comment;
using LearnHub.Application.Responses;
using LearnHub.Domain.Model.Comment;
using LearnHub.Identity.Features.profile.Admin.Requests.Commands;
using LearnHub.Identity.IdentityService.Abstract;
using LearnHub.Identity.Model.En;
using MediatR;

namespace LearnHub.Identity.Features.profile.Admin.Handlers.Commands
{
    public class ReleasReport_H : IRequestHandler<ReleasReport_R, BaseCommandResponse>
    {
        private readonly IComment _comment;
        private readonly Iuser _user;

        public ReleasReport_H(IComment comment, Iuser user)
        {
            _comment = comment;
            _user = user;
        }

        public async Task<BaseCommandResponse> Handle(ReleasReport_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            var user = request.user;

            if (user == null)
            {
                responce.NotFound();
                return responce;
            }

            user.IsReport = false;
            await _user.SaveAsync();

            responce.Success();
            return responce;
        }
    }
}
