using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MailSender.Services;
using System.Collections.ObjectModel;

namespace MailSender.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        //ObservableCollection<Email> _Emails; // ����� ����� ���������
        private IDataAccessService _serviceProxy; // ���������� ������ ��� View
        private ObservableCollection<Email> _emails= new ObservableCollection<Email>(); // ���������� ��������� ��� View

        public ObservableCollection<Email> Emails // ���������� ��������� ��� View
        {
            get => _emails;
            set => Set(ref _emails, value);//    _emails = value;//    RaisePropertyChanged(nameof(Emails));
        }

        // ����� ��� ������� ReadAllCommand
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
        /// ����������� ������ MainWindowViewModel. � ���� �������:
        /// 1. ����� ��
        /// 2. ����� ��������� ��
        /// 3. ��������� Emails
        /// </summary>
        /// <param name="servProxy"></param>
        public MainViewModel(IDataAccessService servProxy)
        {
            _serviceProxy = servProxy;
            Emails = new ObservableCollection<Email>(); // ����� ����������� ������� ������ ��������
            ReadAllCommand = new RelayCommand(GetEmails); // ����� ����������� ������� ������ ��������
        }


    }
}