using System.Reflection.Metadata.Ecma335;

namespace LearnHub.SMS.Model
{
    public class SendPublicSMS_Dto
    {
        public string phoneNumber { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
    }
}
