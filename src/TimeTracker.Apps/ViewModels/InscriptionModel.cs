using System;
using System.Windows.Input;
using Storm.Mvvm;
using TimeTracker.Apps.Pages;
using TimeTracker.Apps.Services;
using Xamarin.Forms;

namespace TimeTracker.Apps.ViewModels
{
    public class InscriptionModel : ViewModelBase
    {

        private string _firstName;
        private string _lastName;
        private string _email;
        private string _pass;

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

        public string Pass
        {
            get => _pass;
            set => SetProperty(ref _pass, value);
        }

        public ICommand InscriptionCommand { get; }
        public ICommand RetourCommand { get; }

        public InscriptionModel()
        {

            InscriptionCommand = new Command(InscriptionAction);
            RetourCommand = new Command(ConnectionPageAction);

        }

        private async void ConnectionPageAction()
        {
            First_name = "";
            Last_name = "";
            Email = "";
            Pass = "";
            await NavigationService.PopAsync();
        }



        private async void InscriptionAction()
        {
            var todoService = DependencyService.Get<ApiService>();

            string FN = First_name;
            string LN = Last_name;
            string email = Email;
            string pass = Pass;
            Console.WriteLine("lala");

            var response = await todoService.inscription(FN,LN,email, pass);


            if (!response.IsSuccessStatusCode)
            {
                //faire un message d'erreur 
            }
            else
            {
                First_name = "";
                Last_name = "";
                Email = "";
                Pass = "";
                await NavigationService.PopAsync();
            }


        }


    }
}
