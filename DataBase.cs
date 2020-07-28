using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    internal static class DataBase
    {
        private static readonly DataClasses1DataContext 
            emailsDataConxt = new DataClasses1DataContext();

        public static IQueryable<Email> Emails => from email in 
            emailsDataConxt.Email 
            select email;
    }
}
