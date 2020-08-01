using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Mail;
using WpfAppMailSender;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
        }

        private void Button_Click(object sebder, RoutedEventArgs e)
        {
            try
            {
                string bodyMail = new TextRange(BodyMail.Document.ContentStart, BodyMail.Document.ContentEnd).Text;

                var send = new EmailSendServiceClass();
                send.Send(LoginBox.Text, PasswordBox.Password, SubjectMail.Text, bodyMail);
            }
            catch (Exception error)
            {
                WindowMessageSendError end = new WindowMessageSendError(error.Message)
                {
                    Owner = Application.Current.MainWindow
                };
                end.ShowDialog();
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Planer_SelectionChanged(object sender, RoutedEventArgs e)
        {
            //tcTabControl.SelectedItem = TabControl.Items[1]; // по индексу
            tcTabControl.SelectedItem = tiPlaner; // по имени
        }
    }
}
