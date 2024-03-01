using LearnHub.Application.Dto.Support.SupportStudent.command;
using LearnHub.Application.Responses;
using MediatR;

namespace LearnHub.Application.Features.SupportStudent.Requests.Commands
{
    public class Create_SupportStudent_R : IRequest<BaseCommandResponse>
    {
        public Create_SupportStudent_Dto create_SupportStudent_Dto { get; set; } = null!;
    }
}
