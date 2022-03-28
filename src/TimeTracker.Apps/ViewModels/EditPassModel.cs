using System;
using System.Windows.Input;
using Storm.Mvvm;
using TimeTracker.Apps.Pages;
using TimeTracker.Apps.Services;
using Xamarin.Forms;

namespace TimeTracker.Apps.ViewModels
{
    public class EditPassModel : ViewModelBase
    {

        private string _old_password;
        private string _new_password;

        public ICommand ChangeCommand { get; }
        public ICommand RetourCommand { get; }

        public string Old_password
        {
            get => _old_password;
            set => SetProperty(ref _old_password, value);
        }

        public string New_password
        {
            get => _new_password;
            set => SetProperty(ref _new_password, value);
        }


        public EditPassModel()
        {
            ChangeCommand = new Command(ChangeActionAsync);
            RetourCommand = new Command(RetourActionAsync);

        }

        private async void RetourActionAsync()
        {
            await NavigationService.PushAsync<EditProfil>();
        }

        private async void ChangeActionAsync(object obj)
        {
            var todoService = DependencyService.Get<ApiService>();

            string OP = Old_password;
            string NP = New_password;

            todoService.patchpasswordAsync(OP, NP);

            await NavigationService.PushAsync<EditProfil>();
        }
    }
}

