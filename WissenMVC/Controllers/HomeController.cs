using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

        public ActionResult DenemeForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DenemeForm(WissenMVC.Models.DenemeForm model)
        {
            if (ModelState.IsValid)
            {
                bool hasError = false;
                try
                {
                    System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                    mailMessage.From = new System.Net.Mail.MailAddress("kutlugungor58@gmail.com", "Wissen");
                    mailMessage.Subject = "İletişim Formu : " + model.FirstName + " " + model.LastName;
                    mailMessage.To.Add("kutlugungor58@hotmail.com");
                    string body;
                    body = "Ad:" + model.FirstName + "<br />";
                    body = "Soyad:" + model.LastName + "<br />";
                    body += "Telefon: " + model.Phone + "<br />";
                    body += "E-posta: " + model.Email + "<br />";
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Body = body;
                    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                    smtp.Credentials = new System.Net.NetworkCredential("kutlugungor58@gmail.com", "***************");
                    smtp.EnableSsl = true;
                    smtp.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error",ex.Message);
                    hasError = true;
                }
                if (hasError == false)
                {
                    ViewBag.Message = "Mail başarıyla gönderildi.";
                }
                return View();
            }
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
            firstName = firstName.Trim();
            lastName = lastName.Trim();
            email = email.Trim();
            phone = phone.Trim();
            message = message.Trim();

            if (firstName == "")
            {
                ViewBag.Message = "Ad alanı boş geçileme.";
                ViewBag.IsError = true;
                return View();
            }
            if (firstName.Length>50)
            {
                ViewBag.Message = "Ad alanı 50 karakterden uzun olamaz.";
                ViewBag.IsError = true;
                return View();
            }
            if (lastName=="")
            {
                ViewBag.Message = "Soyad boş geçilemez.";
                ViewBag.IsError = true;
                return View();
            }
            if (email=="")
            {
                ViewBag.Message = "Email alanı boş geçilemez.";
                ViewBag.IsError = true;
                return View();
            }
            if (phone=="")
            {
                ViewBag.Message = "Telefon alanı boş geçilemez.";
                ViewBag.IsError = true;
                return View();
            }

            Regex regex = new Regex(@"^5(0[5-7]|[3-5]\d) ?\d{3} ?\d{4}$");
            Match match = regex.Match(phone);

            if (match.Success==false)
            {
                ViewBag.Message = "Telefon 5XX XXX XXXX biçiminde olmalıdır.";
                ViewBag.IsError = true;
                return View();

            }


            if (message=="")
            {
                ViewBag.Message = "Mesaj alanı boş geçilemez.";
                ViewBag.IsError = true;
                return View();

            }
            
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