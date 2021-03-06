using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Storm.Mvvm;
using TimeTracker.Apps.Pages;
using TimeTracker.Apps.Services;
using Xamarin.Forms;

namespace TimeTracker.Apps.ViewModels
{
    public class EditUserModel : ViewModelBase
    {

        private string _firstName;
        private string _lastName;
        private string _email;

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Last_name
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        public string First_name
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        public ICommand ChangeCommand { get; }
        public ICommand RetourCommand { get; }
        public ICommand ChangePassCommand { get; }

        public override Task OnResume()
        {
            
            Profil profil  = DependencyService.Get<ApiService>().ME;
            CreateAsync(profil);


            return base.OnResume();
        }

        private async Task CreateAsync(Profil profil)
        {
            var todoService = DependencyService.Get<ApiService>();

            var response = await todoService.getMe();

            Email = response.data.email;
            Last_name = response.data.last_name;
            First_name = response.data.first_name;

        }

        public EditUserModel()
        {
            ChangeCommand = new Command(ChangeActionAsync);
            RetourCommand = new Command(RetourActionAsync);
            ChangePassCommand = new Command(ChangePassAsync);

        }

        private async void ChangePassAsync()
        {
            await NavigationService.PushAsync<EditPass>();
        }

        private async void RetourActionAsync()
        {
            First_name = "";
            Last_name = "";
            Email = "";
            await NavigationService.PopAsync();
        }

        private async void ChangeActionAsync()
        {
            var todoService = DependencyService.Get<ApiService>();

            string FN = First_name;
            string LN = Last_name;
            string email = Email;
            
            todoService.patchMe(email, LN, FN);

            First_name = "";
            Last_name = "";
            Email = "";
            await NavigationService.PopAsync();
        }
    }
}