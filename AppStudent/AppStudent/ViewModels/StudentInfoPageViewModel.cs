using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using AppStudent.Models;
using Prism.Navigation;

namespace AppStudent.ViewModels
{
    public class StudentInfoPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

        private Student _studentP;

        

        public StudentInfoPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Thông tin sinh viên";

        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            StudentP = parameters["stuSelected"] as Student;

        }
        public Student StudentP
        {
            get { return _studentP; }
            set
            {
                _studentP = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs("StudentP"));
            }
        }
    }
}
