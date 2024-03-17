using LearnHub.SMS.Model;
using LearnHub.SMS.responce;
using MediatR;

namespace LearnHub.SMS.Features.Requests.Commands
{
    public class SendLookupSMS_R : IRequest<StatusCode>
    {
        public SendLookupSMS_Dto sendLookup { get; set; } = null!;
    }
}
