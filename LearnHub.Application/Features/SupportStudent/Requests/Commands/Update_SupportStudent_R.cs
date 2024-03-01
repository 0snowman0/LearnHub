using LearnHub.Application.Dto.Support.SupportStudent.command;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.SupportStudent.Requests.Commands
{
    public class Update_SupportStudent_R : IRequest<BaseCommandResponse>
    {
        public Update_SupportStudent_Dto update_SupportStudent_Dto { get; set; } = null!;
    }
}
