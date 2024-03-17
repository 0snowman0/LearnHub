namespace LearnHub.SMS.Model
{
    public class SendLookupSMS_Dto 
    {
        
        public string phoneNumber { get; set; } = string.Empty;
        public string templateName { get; set; } = string.Empty;
        public string token1 { get; set; } = string.Empty;
        public string token2 { get; set; } = string.Empty;
        public string token3 { get; set; } = string.Empty;
    }
}
