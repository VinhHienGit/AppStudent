using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Navigation;
using AppStudent.Models;
using System.ComponentModel;

namespace AppStudent.ViewModels
{
    public class LoginPageViewModel : ViewModelBase, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler Changed;

        private Account _accLogin;

        private string _error;
        
        
        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Đăng nhập";
            Error = "hi";
            AccLogin = new Account()
            {
                Username = "",
                Passwork = "",
                State = false
            };
            GotoMainPage = new DelegateCommand(main);
            //Login = new DelegateCommand(ExcuteLogin, CanLogin);
        }

        public DelegateCommand GotoMainPage { get; private set; }

        void main()
        {
            NavigationService.NavigateAsync("Main");
        }

        #region DelegateCommand Login
        public DelegateCommand Login { get; private set; }

        void ExcuteLogin()
        {
            // check account login
            if(checkLogin(AccLogin))
            {
                NavigationService.NavigateAsync("stuMain");
                AccLogin.State = true;
            }
            else
            {
                Error = "Sai tên tài khoản hoặc mật khẩu.";
            }
        }

        bool CanLogin()
        {
            // check empty
            bool checkEmpty = true;
            if (string.IsNullOrEmpty(AccLogin.Username) || string.IsNullOrEmpty(AccLogin.Passwork))
            {
                checkEmpty = false;
            }
            return checkEmpty;
        }
        private bool checkLogin(Account accLogin)
        {
            // check accLogin in DB            
            return (CheckUsername(accLogin.Username) && CheckPasswork(accLogin.Passwork));
        }

        private bool CheckUsername(string username)
        {
            // check username in DB

            return false;
        }

        private bool CheckPasswork(string passwork)
        {
            // check passwork in DB

            return false;
        }

        

        #endregion

        

        #region ApplicationCommand

        #endregion



        public string Error
        {
            get { return _error; }
            set
            {
               
                SetProperty(ref _error, value);
                Changed?.Invoke(this, new PropertyChangedEventArgs(Error));
            }
        }

        #region get accLogin

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                SetProperty(ref _username, value);
                Changed?.Invoke(this, new PropertyChangedEventArgs(Username));
                AccLogin.Username = value;
            }
        }
        private string _passwork;
        public string Passwork
        {
            get { return _passwork; }
            set
            {
                SetProperty(ref _passwork, value);
                Changed?.Invoke(this, new PropertyChangedEventArgs(Passwork));
                AccLogin.Passwork = value;
            }
        }
        #endregion
        public Account AccLogin { get => _accLogin; set => _accLogin = value; }
    }
}
