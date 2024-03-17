using LearnHub.SMS.Features.Requests.Commands;
using LearnHub.SMS.responce;
using LearnHub.SMS.services;
using LearnHub.SMS.Utilities;
using MediatR;
using System.Reflection.Emit;

namespace LearnHub.SMS.Features.Handlers.Commands
{
    public class SendLookupSMS_H : IRequestHandler<SendLookupSMS_R, StatusCode>
    {
        private readonly ISMSService _sMSService;

        public SendLookupSMS_H(ISMSService sMSService)
        {
            _sMSService = sMSService;
        }

        public async Task<StatusCode> Handle(SendLookupSMS_R request, CancellationToken cancellationToken)
        {
            var StatusCode = new StatusCode();
            try
            {
                await _sMSService.SendLookupSMS
                    (request.sendLookup.phoneNumber, 
                    request.sendLookup.templateName, 
                    request.sendLookup.token1,
                    Generator.RandomNumber());

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
