using LearnHub.Application.Contracts.comment;
using LearnHub.Application.Responses;
using LearnHub.Domain.Model.Comment;
using LearnHub.Identity.Features.Admin.Requests.Commands;
using LearnHub.Identity.IdentityService.Abstract;
using LearnHub.Identity.Model.En;
using MediatR;

namespace LearnHub.Identity.Features.Admin.Handlers.Commands
{
    public class ConfirmReportUser_H : IRequestHandler<ConfirmReportUser_R, BaseCommandResponse>
    {
        private readonly IComment _comment;
        private readonly Iuser _user;

        public ConfirmReportUser_H(IComment comment, Iuser user)
        {
            _comment = comment;
            _user = user;
        }

        public async Task<BaseCommandResponse> Handle(ConfirmReportUser_R request, CancellationToken cancellationToken)
        {
            var responce = new BaseCommandResponse();

            var comment = new Comment_En();
            var user = new User_En();

            foreach (var commentId in request.CommentId)
            {
                comment = await _comment.Get(commentId);
                if (comment == null)
                {
                    responce.NotFound();
                    responce.Errors = new List<string> { $"not found comment with id:{commentId}" };
                    return responce;
                }
                user = await _user.Get(comment.UserId);
                if (user == null)
                {
                    responce.NotFound();
                    responce.Errors = new List<string> { $"not found user with id:{comment.Id}" };
                    return responce;
                }
                user.IsReport = true;
            }
            await _user.SaveAsync();


            responce.Success();
            return responce;

        }
    }
}
