using System.Net;
using System.Net.Mail;

namespace LearnHub.Email
{
    public class LocalMailService
    {
        string _mailTo = "kasrasajjadi82@gmail.com";
        string _mailFrom = "kasramasra911@gmail.com";

        public void Send(string subject, string message , string to)
        {
            Console.WriteLine($"Mail  From {_mailFrom}  To {to}  , "
                + $"with {nameof(LocalMailService)}  ,  ");
            Console.WriteLine($"Subject {subject}");
            Console.WriteLine($"Message {message}");
        }



        public static void Email(string subject, string htmlString
            , string to)
        {
            try
            {
                string _mailFrom = "kasramasra911@gmail.com";
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(_mailFrom);
                message.To.Add(new MailAddress(to));
                message.Subject = subject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("FromMailAddress", "password");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) { }
        }
    }
}
