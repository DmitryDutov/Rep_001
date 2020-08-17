using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MailSender.Services;
using System.Collections.ObjectModel;

namespace MailSender.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        //ObservableCollection<Email> _Emails; // Тащим через интерфейс
        private IDataAccessService _serviceProxy; // объявление класса для View
        private ObservableCollection<Email> _emails= new ObservableCollection<Email>(); // объявление коллекции для View

        public ObservableCollection<Email> Emails // Заполнение коллекции для View
        {
            get => _emails;
            set => Set(ref _emails, value);//    _emails = value;//    RaisePropertyChanged(nameof(Emails));
        }

        // Метод для команды ReadAllCommand
        void GetEmails()
        {
            Emails.Clear();
            foreach (var item in _serviceProxy.GetEmails())
            {
                Emails.Add(item);
            }
        }
        
        public RelayCommand ReadAllCommand { get; set; }

        /// <summary>
        /// Конструктор класса MainWindowViewModel. В него передаём:
        /// 1. Класс БД
        /// 2. Класс контекста БД
        /// 3. Коллекцию Emails
        /// </summary>
        /// <param name="servProxy"></param>
        public MainViewModel(IDataAccessService servProxy)
        {
            _serviceProxy = servProxy;
            Emails = new ObservableCollection<Email>(); // Можно реализовать команду старым способом
            ReadAllCommand = new RelayCommand(GetEmails); // Можно реализовать команду старым способом
        }


    }
}