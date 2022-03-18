using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using Storm.Mvvm;
using TimeTracker.Apps.Pages;
using TimeTracker.Apps.Services;
using Xamarin.Forms;

namespace TimeTracker.Apps.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private string _name;
        private string _pass;
       

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Pass
        {
            get => _pass;
            set => SetProperty(ref _pass, value);
        }

        public ICommand ConnexionCommand { get; }
        public ICommand InscriptionCommand { get; }

        public MainViewModel()
        {
            ConnexionCommand = new Command(ConnexionAction);
            InscriptionCommand = new Command(InscriptonPageAction);

        }

        private async void InscriptonPageAction()
        {
            await NavigationService.PushAsync<PageInscription>();
        }



        private async void ConnexionAction()
        {
            var todoService = DependencyService.Get<ApiService>();

            string log = Name;
            string pass = Pass;

            var response = await todoService.connect(log, pass);

            
            if (!response.IsSuccessStatusCode)
            {
                //faire un message d'erreur 
            }
            else
            {
                NavigationService.PushAsync<ListProjet>();
            }
            

        }
    }
}
