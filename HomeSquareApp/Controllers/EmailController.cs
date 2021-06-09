using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;


namespace HomeSquareApp.Controllers
{
    public class EmailController
    {
        //Move this to models later
        //If error is occured, SIT wifi might be the one to blame
        public static bool SendEmail(MailMessage message)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "homesquare322@gmail.com",
                Password = "treehard123!",
            };
            client.EnableSsl = true;
            client.Send(message);

            return true;
        }
    }
}
