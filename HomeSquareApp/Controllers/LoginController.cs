using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;

namespace HomeSquareApp.Controllers
{
    public class LoginController : Controller
    {
        public JsonResult SendEmail(string email)
        {
            MailMessage message = new MailMessage("homesquare322@gmail.com", "ultimateformj@gmail.com");
            message.Subject = "This is email confirmation from localhost grocery store HomeSquare";
            message.Body = "Hi friend, you have registered into our store for good";

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "homesquare322@gmail.com",
                Password = "treehard123!",
            };
            client.EnableSsl = true;
            client.Send(message);

            return JsonResult(true);
        }
    }
}
