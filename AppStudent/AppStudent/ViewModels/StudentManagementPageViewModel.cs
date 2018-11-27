using System;
using System.Collections.ObjectModel;
using AppStudent.Models;
using Prism.Commands;
using Prism.Navigation;

namespace AppStudent.ViewModels
{
    public class StudentManagementPageMenuItem
    {
        public StudentManagementPageMenuItem()
        {
            
        }
        public int Id { get; set; }
        public string TitleDetail { get; set; }
        public string TargetType { get; set; }
    }
    public class StudentManagementPageViewModel : ViewModelBase
    {

        public Account AccLogin { get; set; }
        public ObservableCollection<StudentManagementPageMenuItem> MenuItems { get; set; }
        public StudentManagementPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Quản lý sinh viên";
            MenuItems = new ObservableCollection<StudentManagementPageMenuItem>(new[]
                {
                    new StudentManagementPageMenuItem { Id = 0, TitleDetail = "Thông tin cá nhân", TargetType = "PSInfoP" },
                    new StudentManagementPageMenuItem { Id = 1, TitleDetail = "Danh sách sinh viên", TargetType = "ListStuP" },
                });
            OnNavigateCommand = new DelegateCommand<string>(Navigate);
            LogoutCommand = new DelegateCommand(Logout);
        }

        public DelegateCommand LogoutCommand { get; set; }

        void Logout()
        {
            NavigationService.NavigateAsync(new Uri("/LoginP"));
        }
        public DelegateCommand<string> OnNavigateCommand { get; set; }
        void Navigate(string page)
        {
            if (!string.IsNullOrEmpty(page))
            {

                NavigationParameters para = new NavigationParameters
                {
                    { "AccLogin", AccLogin }
                };
                NavigationService.NavigateAsync(new Uri(page, UriKind.Absolute), para);
            }

        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            AccLogin = parameters["AccLogin"] as Account;
        }

        #region SelectedItem
        private StudentManagementPageMenuItem _selectedItemb;
        public StudentManagementPageMenuItem SelectedItemb
        {
            get
            {
                return _selectedItemb;
            }
            set
            {
                _selectedItemb = value;

                if (_selectedItemb == null)
                    return;
                OnNavigateCommand.Execute("/Main/NP/"+_selectedItemb.TargetType);
                SelectedItemb = null;
            }
        }
        #endregion
    }
}
