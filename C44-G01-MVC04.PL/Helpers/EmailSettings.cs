using C44_G01_MVC04.DAL.Models.Emails;
using System.Net;
using System.Net.Http;
using System.Net.Mail;

namespace C44_G01_MVC04.PL.Helpers
{
    public static class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential("", ""),
               
            };
            client.Send("from@example.com", email.To, email.Subject, email.Body);

        }
    }
}
