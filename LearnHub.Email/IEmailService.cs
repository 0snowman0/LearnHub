using LearnHub.Email.Model;

namespace LearnHub.Email
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
