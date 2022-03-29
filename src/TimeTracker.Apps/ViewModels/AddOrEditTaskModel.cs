using System;
using System.Collections.Generic;
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

            if (Index >= 0)
            {
                List<Tassk> todoService = DependencyService.Get<ApiService>().Tasks;

                foreach (Tassk test in todoService)
                {

                    bool essei = testid(test);
                    if (essei)
                    {
                        return base.OnResume();
                    }

                }



            }

            

            return base.OnResume();
        }

        private bool testid(Tassk test)
        {
            if (test.Id == Index)
            {
                Name = test.Name;

                return true;
            }
            return false;
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
                todoService2.postTaskAsync(name);
            }
            else
            {
                todoService2.putTaskAsync(name, Index);
            }

            Name = "";

            todoService2.getTasks(todoService2.proj);
            await NavigationService.PopAsync();
        }

    }
}

