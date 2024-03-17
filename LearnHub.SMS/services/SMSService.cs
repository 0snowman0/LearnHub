using LearnHub.SMS.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;


namespace LearnHub.SMS.services
{
    public class SMSService : ISMSService
    {
        private readonly IConfiguration _config;

        public SMSService(IConfiguration config)
        {
            _config = config;
        }


        public async Task SendPublicSMS(string phoneNumber, string message)
        {
            try
            {
                var api = new Kavenegar.KavenegarApi(_config.GetSection("ApiKey").Value);

                var result = await api.Send(_config.GetSection("Sender").Value, phoneNumber, message);
            }
            catch (Kavenegar.Core.Exceptions.ApiException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Kavenegar.Core.Exceptions.HttpException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task SendLookupSMS(string phoneNumber, string templateName, string token1, string? token2 = "",
            string? token3 = "")
        {
            try
            {
                var api = new Kavenegar.KavenegarApi(_config.GetSection("ApiKey").Value);

                var result = await api.VerifyLookup(phoneNumber, token1, token2, token3, templateName);
            }
            catch (Kavenegar.Core.Exceptions.ApiException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Kavenegar.Core.Exceptions.HttpException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
