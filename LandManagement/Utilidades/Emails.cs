using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace LandManagement.Utilidades
{
    public class Emails
    {
        public void SendMail()
        {
            try
            {

                string your_id = "";
                string your_password = "";

                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(your_id, your_password),
                    EnableSsl = true
                };

                client.Send("leo.ciudadela@gmail.com", "leonardorodriguez@outlook.com", "Test", "test message");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //string your_id = "leo.ciudadela@gmail.com";
            //string your_password = ".ENZOelmasmejor.";
            //try
            //{
            //    SmtpClient client = new SmtpClient
            //    {
            //        Host = "smtp.gmail.com",
            //        Port = 465,
            //        EnableSsl = true,
            //        DeliveryMethod = SmtpDeliveryMethod.Network,
            //        Credentials = new System.Net.NetworkCredential(your_id, your_password),
            //        Timeout = 10000,
            //    };
            //    MailMessage mm = new MailMessage(your_id, "leonardorodriguez@outlook.com", "subject", "body");
            //    client.Send(mm);
            //    Console.WriteLine("Email Sent");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Could not end email\n\n" + e.ToString());
            //}

            
            //try
            //{
            //    MailMessage mail = new MailMessage("tec.lrodriguez@gmail.com", "leonardorodriguez@outlook.com");
            //    SmtpClient client = new SmtpClient();
            //    client.Port = 25;
            //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //    client.UseDefaultCredentials = false;
            //    client.Host = "smtp.google.com";
            //    mail.Subject = "this is a test email.";
            //    mail.Body = "this is my test email body";
            //    client.Send(mail);
            //}
            //catch (Exception ex)
            //{
                
            //    throw ex;
            //}
        }
    }
}
