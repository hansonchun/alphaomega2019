using AlphaOmegaClient.Models.Email;
using AlphaOmegaServices;
using AlphaOmegaServices.DataModels.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AlphaOmegaClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendEmail(EmailFormModel model)
        {
            using(var emailService = new EmailService()) {

                var email = new EmailModel()
                {
                    FromEmail = model.FromEmail,
                    FromName = model.FromName,
                    Message = model.Message
                };

                var emailResult = emailService.SendTestEmail(email);
                if (emailResult.Success)
                {
                    return RedirectToAction("Sent");
                }
                else
                {
                    return View("Error");
                }
            }
        }

        public ActionResult Sent()
        {
            return View();
        }
    }
}
