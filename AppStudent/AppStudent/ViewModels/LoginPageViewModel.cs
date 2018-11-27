using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Navigation;
using AppStudent.Models;
using System.ComponentModel;
using PrismQuanLySinhVien.Services;
using System.Text.RegularExpressions;

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
            Error = "Đăng nhập để tiếp tục";
            AccLogin = new Account();
            Passwork = "";
            LoginCommand = new DelegateCommand(ExcuteLogin);
            ForgetPasswork = new DelegateCommand(ExcuteShowPass);
        }
        
        #region DelegateCommand Login
        public DelegateCommand LoginCommand { get; private set; }

        void ExcuteLogin()
        {
            // check account login

            if (MyData.Instance.CheckLogin(AccLogin))
            {
                AccLogin.State = true;
                Error = "";
                NavigationParameters navigateParameter = new NavigationParameters
                {
                    { "AccLogin", AccLogin }
                };
                NavigationService.NavigateAsync("Main", navigateParameter);
                //UPdate Account DB 
            }
            else
            {
                Error = "Sai tên tài khoản hoặc mật khẩu.";
            }

        }
        
        #endregion

        public DelegateCommand ForgetPasswork { get; private set; }

        void ExcuteShowPass()
        {
            Error = "Mật khẩu: 123456";
        }

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
                Error = "";
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
                Error = "";
                SetProperty(ref _passwork, value);
                Changed?.Invoke(this, new PropertyChangedEventArgs(Passwork));
                AccLogin.Passwork = value;
            }
        }
        #endregion
        public Account AccLogin { get => _accLogin; set => _accLogin = value; }
    }
}
