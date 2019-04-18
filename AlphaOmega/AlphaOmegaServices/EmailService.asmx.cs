using AlphaOmegaServices.DataModels.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;

namespace AlphaOmegaServices
{
    /// <summary>
    /// Summary description for EmailService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EmailService : System.Web.Services.WebService
    {

        [WebMethod]
        public EmailResult SendTestEmail(EmailModel email)
        {
            try
            {
                var body = "<p>Email From {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("hansonchun@gmail.com"));
                message.From = new MailAddress("hanson_chun@hotmail.com");
                message.Subject = "Hello from AlphaOmega";
                message.Body = string.Format(body, email.FromName, email.FromEmail, email.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    smtp.Credentials = new NetworkCredential { UserName = "hanson_chun@hotmail.com", Password = "Aa0415aa!" };
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Send(message);
                    return new EmailResult { Success = true, Exception = string.Empty };
                }
            }
            catch(Exception ex)
            {
                return new EmailResult { Success = false, Exception = ex.Message };
            }
        }
    }
}
