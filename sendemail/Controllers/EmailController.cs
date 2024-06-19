using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sendemail.Models;

namespace sendemail.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        private readonly MailService _mailService = new MailService();

        public ActionResult Send()
        {
            _mailService.SendEmail("pinkysmbit@gmail.com", "Subject", "Hello, this is a test email from Mailgun!");
            return View();
        }
    }
}