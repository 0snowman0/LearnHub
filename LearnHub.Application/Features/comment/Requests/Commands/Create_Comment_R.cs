using LearnHub.Application.Dto.comment.command;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.comment.Requests.Commands
{
    public class Create_Comment_R : IRequest<BaseCommandResponse>
    {
        public Create_Comment_Dto create_Comment_Dto { get; set; } = null!;
        public  int UserId { get; set; }
    }
}
