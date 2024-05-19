using System.Net;
using System.Net.Mail;

namespace DoAnCDIO2_Genuine_Cosmetic.Helpers
{
    public class SendMail
    {
        public bool SendEmail(string to, string subject, string body, string attachFile)
        {
            try
            {
                MailMessage msg = new MailMessage("", to, subject, body);
                using (var client = new SmtpClient("", 0))
                {
                    client.EnableSsl = true;
                    NetworkCredential credential = new NetworkCredential("", "");
                    client.Credentials = credential;
                    client.Send(msg);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}