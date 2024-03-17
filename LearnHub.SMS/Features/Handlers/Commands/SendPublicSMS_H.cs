using LearnHub.SMS.Features.Requests.Commands;
using LearnHub.SMS.responce;
using LearnHub.SMS.services;
using MediatR;

namespace LearnHub.SMS.Features.Handlers.Commands
{
    public class SendPublicSMS_H : IRequestHandler<SendPublicSMS_R, StatusCode>
    {
        private readonly ISMSService _sMSService;

        public SendPublicSMS_H(ISMSService sMSService)
        {
            _sMSService = sMSService;
        }

        public async Task<StatusCode> Handle(SendPublicSMS_R request, CancellationToken cancellationToken)
        {
            var StatusCode = new StatusCode();
            try
            {
                await _sMSService.SendPublicSMS
                    (request.sendPublic.phoneNumber, request.sendPublic.message);

                StatusCode.statusCode = 200;
                return StatusCode;
            }
            catch (Exception ex)
            {
                StatusCode.statusCode = 500;

                Console.WriteLine(ex.ToString());   

                return StatusCode;
            }
        }
    }
}
