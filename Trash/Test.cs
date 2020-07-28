using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MailSender
{
    class Test
    {
        // Сначала пробуем так
        private void Button_ClickNoWrk(object sender, RoutedEventArgs e)
        {
            MailAddress froMailAddress = new MailAddress("korkiy@mail.ru", "Korkiy");
            //MailAddress froMailAddress = new MailAddress("korkiy@gmail.com", "Korkiy");
            MailAddress toMailAddress = new MailAddress("dmitry_dutov@inbox.ru", "Dmitry");

            using (MailMessage mailMessage = new MailMessage(froMailAddress, toMailAddress))
            using (SmtpClient smtpClient = new SmtpClient())
            {
                mailMessage.Subject = "MessageSubject";
                mailMessage.Body = "Text in the Body";

                smtpClient.Host = "smtp.mail.ru";
                //smtpClient.Host = "smtp.gmail.ru";
                //smtpClient.Port = 465;
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(froMailAddress.Address, "Pokemon153");

                smtpClient.Send(mailMessage);
            }
        }

        // Это рабочий вариант. Написан самостоятельно
        private void Button_ClickNext01(object sender, RoutedEventArgs e)
        {
            Sender mailSender = new Sender();
            mailSender.SendMail(
                "smtp.mail.ru"
                , "korkiy@mail.ru"
                , "pokemon153"
                , "dmitry_dutov@inbox.ru"
                , "Teame"
                , "Text of message"
                , null
            );
        }


    }
}
