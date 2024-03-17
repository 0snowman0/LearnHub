using LearnHub.SMS.Model;
using LearnHub.SMS.responce;
using MediatR;

namespace LearnHub.SMS.Features.Requests.Commands
{
    public class SendPublicSMS_R : IRequest<StatusCode>
    {
        public SendPublicSMS_Dto sendPublic { get; set; } = null!;

    }
}
