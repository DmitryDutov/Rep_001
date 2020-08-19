using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MailSender.Services
{
    public class EmailSendServiceClass : ViewModelBase
    {
        #region vars
        private readonly string _strLogin; // email, c которого будет рассылаться почта
        private readonly string _strPassword; // пароль к email, с которого будет рассылаться почта
        private readonly string _strSmtp = "smtp.yandex.ru"; // smtp - server
        private readonly int _iSmtpPort = 25; // порт для smtp-server
        private string _strBody; // текст письма для отправки
        private string _strSubject; // тема письма для отправки
        #endregion

        public EmailSendServiceClass(string sLogin, string sPassword)
        {
            _strLogin = sLogin;
            _strPassword = sPassword;
        }

        private void SendMail(string mail) // Отправка email конкретному адресату
        {
            using (MailMessage mm = new MailMessage(_strLogin, mail))
            {
                mm.Subject = _strSubject;
                mm.Body = "Hello world!";
                mm.IsBodyHtml = false;
                SmtpClient sc = new SmtpClient(_strSmtp, _iSmtpPort)
                {
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_strLogin, _strPassword)
                };
                try
                {
                    sc.Send(mm);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
                }
            }
        }

        private readonly IDataAccessService _dataService; // Объявление класса
        private ObservableCollection<Email> _emails = new ObservableCollection<Email>(); // объявление коллекции
        public ObservableCollection<Email> Emails // наполнение коллекции
        {
            get => _emails;
            set
            {
                Set(ref _emails, value);
            }
        }

        private Email _currentEmail = new Email(); // объявление текущего Email
        public Email CurrentEmail // наполнение текущего Email
        {
            get => _currentEmail;
            set => Set(ref _currentEmail, value);
        }

        private void SendMail(Email CurrentEmail, int name)
        {
            throw new NotImplementedException();
        }

		public void SendMails(ObservableCollection<Email> emails)
        {
            foreach (Email email in emails)
            {
                SendMail(email, email.Name); // SendMail(email.Value, email.Name); НЕ ПОЛУЧАЕТСЯ
            }
        }
    }
}
