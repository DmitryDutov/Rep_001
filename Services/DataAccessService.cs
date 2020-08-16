using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MailSender.Services
{
    public interface IDataAccessService
    {
        ObservableCollection<Email> GetEmails();
    }

    public class DataAccessService : IDataAccessService
    {

        EmailsDataContext context;
        public DataAccessService()
        {
            context = new EmailsDataContext();
        }
        public ObservableCollection<Email> GetEmails()
        {
            ObservableCollection<Email> Emails = new ObservableCollection<Email>();
            foreach (var item in context.Emails)
            {
                Emails.Add(item);
            }
            return Emails;
        }

    }
}
