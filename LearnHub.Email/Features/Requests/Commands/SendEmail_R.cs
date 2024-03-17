using LearnHub.Email.Model;
using MediatR;

namespace LearnHub.Email.Features.Requests.Commands
{
    public class SendEmail_R : IRequest<bool>
    {
        public EmailDto email { get; set; } = null!;
    }
}
