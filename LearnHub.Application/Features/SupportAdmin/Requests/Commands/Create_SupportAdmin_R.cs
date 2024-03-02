using LearnHub.Application.Dto.Support.SupportAdmin.command;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.SupportAdmin.Requests.Commands
{
    public class Create_SupportAdmin_R : IRequest<BaseCommandResponse>
    {
        public Create_SupportAdmin_Dto create_SupportAdmin_Dto { get; set; } = null!;
        public  int AdminId { get; set; }

    }
}
