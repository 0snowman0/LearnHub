using LearnHub.Application.Dto.Support.SupportAdmin.command;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.SupportAdmin.Requests.Commands
{
    public class Update_SupportAdmin_R : IRequest<BaseCommandResponse>
    {
        public Update_SupportAdmin_Dto update_SupportAdmin_Dto { get; set; } = null!;
    }
}
