using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AppStudent.Models;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using Refit;

namespace AppStudent.ViewModels
{
    public interface IMakeUpApi
    {
        [Get("/api/v1/products.json?brand=maybelline")]
        Task<string> GetMakeUps();
    }

    
    public class ListStudentsPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        private ObservableCollection<Student> _itemSouce;
        private List<Student> _listStudent;
        public ListStudentsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Danh sách sinh viên";
            OnNavigateCommand = new DelegateCommand<INavigationParameters>(Navigate);
            CallApi();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }
        async void CallApi()
        {
            var nsAPI = RestService.For<IMakeUpApi>("http://makeup-api.herokuapp.com");
            var sugars = await nsAPI.GetMakeUps();
            ListStudent =  JsonConvert.DeserializeObject<List < Student >> (sugars.ToString());
        }
        public DelegateCommand<INavigationParameters> OnNavigateCommand { get; set; }
        void Navigate(INavigationParameters p)
        {
                NavigationService.NavigateAsync("stuInfoP", p);
        }

        private Student _selectedItemb;
        public Student SelectedItemb
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
                NavigationParameters parameter = new NavigationParameters
                {
                    { "stuSelected", _selectedItemb }
                };
                OnNavigateCommand.Execute(parameter);
                SelectedItemb = null;
            }
        }

        public ObservableCollection<Student> ItemSouce
        {
            get { return _itemSouce; }

            set
            {
                _itemSouce = value;
                PropertyChanged?.Invoke(this,
                  new PropertyChangedEventArgs("ItemSouce"));// Throw!!
            }
        }

        public List<Student> ListStudent
        {
            get { return _listStudent; }

            set
            {
                _listStudent = value;
                int p(Student x, Student y)
                {
#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
                    if (x.Id == null && y.Id == null) return 0;
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
                    else if (x.Id == null) return -1;
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
                    else return y.Id == null ? 1 : x.Id.CompareTo(y.Id);
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
                }
                ListStudent.Sort(p);
                ItemSouce = new ObservableCollection<Student>(ListStudent);
            }
        }
    }
}
