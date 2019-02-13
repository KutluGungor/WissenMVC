using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WissenMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string firstName, string lastName,string email, string phone, string department,string message)
        {
            //TODO: Mail Gönderme işlemi yapılacak.

            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.From = new System.Net.Mail.MailAddress("kutlugungor58@gmail.com", "Wissen");
            mailMessage.Subject = "İletişim Formu : " + firstName + " " + lastName;
            mailMessage.To.Add("kutlugungor58@hotmail.com");
            string body;
            body = "Ad Soyad: " + firstName + "<br />";
            body += "Telefon: " + lastName + "<br />";
            body += "E-posta: " + email + "<br />";
            body += "Konu: " + phone + "<br />";
            body += "Departman: " + department + "<br />";
            body += "Mesaj: " + message + "<br />";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = body;

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential("kutlugungor58@gmail.com", "************");
            smtp.EnableSsl = true;
            smtp.Send(mailMessage);

            ViewBag.Message = "Form başarıyla kaydedildi, en kısa zamanda dönüş yapacağız.";
            return View();
        }
    }
}