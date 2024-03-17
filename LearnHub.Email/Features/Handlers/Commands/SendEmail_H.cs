using LearnHub.Email.Features.Requests.Commands;
using MediatR;
using System.Net.NetworkInformation;

namespace LearnHub.Email.Features.Handlers.Commands
{
    public class SendEmail_H : IRequestHandler<SendEmail_R, bool>
    {
        private readonly IEmailService _emailService;

        public SendEmail_H(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task<bool> Handle(SendEmail_R request, CancellationToken cancellationToken)
        {
            _emailService.SendEmail(request.email);
            return true;
        }
    }
}
