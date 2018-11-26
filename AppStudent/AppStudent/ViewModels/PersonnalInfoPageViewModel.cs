
using System.ComponentModel;
using AppStudent.Models;
using Prism.Navigation;

namespace AppStudent.ViewModels
{
    public class PersonnalInfoPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler Changed;
        private Account _accLogin;
        public PersonnalInfoPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Thông tin cá nhân";
        }


        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            AccLogin = parameters["AccLogin"] as Account;
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                SetProperty(ref _username, value);
                Changed?.Invoke(this, new PropertyChangedEventArgs(Username));
            }
        }

        public Account AccLogin
        {
            get { return _accLogin; }
            set
            {
                _accLogin = value;
                Username = _accLogin.Username;
            }
        }
    }
}
