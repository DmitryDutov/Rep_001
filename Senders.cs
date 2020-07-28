using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    public static class Senders
    {
        public static Dictionary<string, string> SendersDictionary { get; } = new Dictionary<string, string>
        {
              {"korkiy@mail.ru", "pokemon153"}
            , {"dmitry_dutov@inbox.ru", "pokemon153"}
            , {"test@mail.ru", "12345"}
            , {"test@gmail.com", "12345"}
        };

        public static Dictionary<string, string> ServersDictionary { get; } = new Dictionary<string, string>
        {
              {"Server_001@Mail.ru", "Server 001"}
            , {"Server_002@Mail.ru", "Server 002"}
            , {"Server_003@Mail.ru", "Server 003"}
            , {"Server_004@Mail.ru", "Server 004"}
        };
    }
}
