using System;
using System.Collections.Generic;
using System.Text;
using Prism.Navigation;

namespace AppStudent.ViewModels
{
    public class PersonnalInfoPageViewModel : ViewModelBase
    {
        public PersonnalInfoPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Thông tin cá nhân";
        }
    }
}
