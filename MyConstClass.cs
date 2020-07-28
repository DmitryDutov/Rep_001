namespace WpfAppMailSender
{
    public static class MyConstClass
    {
        /// <summary>
        /// Адрес отправитель
        /// </summary>
        public const string From = "korkiy@mail.ru";

        /// <summary>
        /// Адрес получатель
        /// </summary>
        public const string To = "dmitry_dutov@inbox.ru";

        /// <summary>
        /// Имя севреа для отправки
        /// </summary>
        public const string ServerName = "smtp.mail.ru";

        /// <summary>
        /// Порт для отправки
        /// </summary>
        public const int ServerPort = 587;

        /// <summary>
        /// Шифрованная отправка
        /// </summary>
        public const bool Ssl = true;
    }
}