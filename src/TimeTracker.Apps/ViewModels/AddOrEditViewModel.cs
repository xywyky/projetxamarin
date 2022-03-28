using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Storm.Mvvm;
using Storm.Mvvm.Navigation;
using TimeTracker.Apps.Services;
using Xamarin.Forms;

namespace TimeTracker.Apps.ViewModels
{
    public class AddOrEditViewModel : ViewModelBase
    {
        private string _name;
        private string _description;
        private int _index;

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        [NavigationParameter]
        public int Index
        {
            get => _index;
            set => SetProperty(ref _index, value);
        }

        public ICommand CancelCommand { get; }

        public ICommand ValidateCommand { get; }

        public AddOrEditViewModel()
        {
            ValidateCommand = new Command(ValidateAction);
            CancelCommand = new Command(CancelAction);
        }

        public override Task OnResume()
        {
            if (Index >= 0)
            {
                var todoService = DependencyService.Get<ProjetService>();
                Name = todoService.Projet[Index];
            }
            return base.OnResume();
        }

        private async void CancelAction()
        {
            await NavigationService.PopAsync();
        }

        private async void ValidateAction()
        {
            string name = Name;
            string description = Description;
            if (string.IsNullOrEmpty(name))
            {
                return;
            }

            var todoService2 = DependencyService.Get<ApiService>();
            if (Index < 0)
            {
                todoService2.postProjects(name,description);
            }
            else
            {
            }

            Name = "";
            Description = "";
            await NavigationService.PopAsync();
        }
    }
}