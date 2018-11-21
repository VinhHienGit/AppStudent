using Prism;
using Prism.Ioc;
using AppStudent.ViewModels;
using AppStudent.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppStudent
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("LoginP");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register Page
            containerRegistry.RegisterForNavigation<NavigationPage>("NP");
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>("LoginP");
            containerRegistry.RegisterForNavigation<StudentManagementPage, StudentManagementPageViewModel>("Main");
            containerRegistry.RegisterForNavigation<PersonalInfoPage, PersonnalInfoPageViewModel>("PSInfoP");
            containerRegistry.RegisterForNavigation<ListStudentsPage, ListStudentsPageViewModel>("ListStuP");
            containerRegistry.RegisterForNavigation<StudentInfoPage, StudentInfoPageViewModel>("stuInfoP");

            // Register signgleton
        }
    }
}
