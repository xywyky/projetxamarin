using Storm.Mvvm;
using TimeTracker.Apps.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TimeTracker.Apps.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace TimeTracker.Apps
{
    public partial class App : MvvmApplication
    {
        public App() : base(CreateStartPage)
        {
            InitializeComponent();
            DependencyService.Register<ProjetService>();
            DependencyService.Register<ApiService>();
        }

        private static Page CreateStartPage()
        {
            return new MainPage();
        }
    }
}

