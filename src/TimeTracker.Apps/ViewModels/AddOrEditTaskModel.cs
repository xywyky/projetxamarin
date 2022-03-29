using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Storm.Mvvm;
using Storm.Mvvm.Navigation;
using TimeTracker.Apps.Services;
using Xamarin.Forms;

namespace TimeTracker.Apps.ViewModels
{
    public class AddOrEditTaskModel : ViewModelBase
    {
        private string _name;
        private int _index;


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

        public AddOrEditTaskModel()
        {
            ValidateCommand = new Command(ValidateAction);
            CancelCommand = new Command(CancelAction);
        }

        public override Task OnResume()
        {
        
            return base.OnResume();
        }

        private async void CancelAction()
        {
            await NavigationService.PopAsync();
        }


        private async void ValidateAction()
        {
            string name = Name;
            if (string.IsNullOrEmpty(name))
            {
                return;
            }

            var todoService2 = DependencyService.Get<ApiService>();
            if (Index < 0)
            {
                Console.WriteLine(Index);
                todoService2.postTaskAsync(todoService2.proj , name);
            }
            else
            {
            }

            Name = "";
            await NavigationService.PopAsync();
        }

    }
}

