using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.comment.Requests.Commands
{
    public class Delete_Comment_R : IRequest<BaseCommandResponse>
    {
        public  List<int> Ids { get; set; }
    }
}
