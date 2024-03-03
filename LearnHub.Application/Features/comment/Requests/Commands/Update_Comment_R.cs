using LearnHub.Application.Dto.comment.command;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.comment.Requests.Commands
{
    public class Update_Comment_R : IRequest<BaseCommandResponse>
    {
        public Update_Comment_Dto update_Comment_Dto { get; set; } = null!;
        public int UserId { get; set; }
    }
}
