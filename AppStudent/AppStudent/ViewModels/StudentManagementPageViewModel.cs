using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using AppStudent.Models;
using AppStudent.Views;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

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
            NavigationService.NavigateAsync("LoginP");
        }
        public DelegateCommand<string> OnNavigateCommand { get; set; }
        void Navigate(string page)
        {
            if (!string.IsNullOrEmpty(page))
            {
                NavigationService.NavigateAsync(new Uri(page, UriKind.Absolute));
            }

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
