using HomeSquareApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HomeSquareApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ContactMessageViewModel model = new ContactMessageViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendMessage([Bind("Email", "Name", "PhoneNumber", "Message")]ContactMessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                MailMessage message = new MailMessage("homesquare322@gmail.com", model.Email);
                message.Subject = string.Format("Message From {0}",model.Name);
                message.Body = string.Format("Email: {0}\n", model.Email);
                message.Body += string.Format("Phone: {0}\n\n", model.PhoneNumber);
                message.Body += string.Format("Message: {0}\n", model.Message);
                EmailController.SendEmail(message);

                TempData["SuccessMessage"] = "We have received your message!";
                return RedirectToAction("Index", "Home");
            }

            return View("Index",model);
        }
    }
}
