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
        //Move this to models later
        //If error is occured, SIT wifi might be the one to blame
        public void SendEmail(string email)
        {
            MailMessage message = new MailMessage("homesquare322@gmail.com", email);
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
        }
    }
}
