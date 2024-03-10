using LearnHub.Application.Responses;
using LearnHub.Identity.Model.Dto;
using LearnHub.Identity.Model.En;
using MediatR;

namespace LearnHub.Identity.Features.Register.Requests
{
    public class RegisterAdmin_R : IRequest<BaseCommandResponse>
    {
        public RegisterAdmin_Dto registerAdmin { get; set; } = null!;
    }
}
