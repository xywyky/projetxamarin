using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Storm.Mvvm;
using TimeTracker.Apps.Services;
using Xamarin.Forms;

namespace TimeTracker.Apps.ViewModels
{
    public class ListTaskViewModel : ViewModelBase
    {

        private ObservableCollection<Tassk> _tasks;

        public ICommand AddCommand { get; }

        public ICommand EditCommand { get; }

        public ObservableCollection<Tassk> Tasks
        {
            get => _tasks;
            set => SetProperty(ref _tasks, value);
        }



        public ListTaskViewModel()
        {
            Tasks = new ObservableCollection<Tassk>();

            AddCommand = new Command(AddAction);
            EditCommand = new Command(EditAction);
        }

        private void EditAction(object obj)
        {
            throw new NotImplementedException();
        }

        private void AddAction(object obj)
        {
            throw new NotImplementedException();
        }

        public override Task OnResume()
        {
            Tasks.Clear();
            List<Tassk> iems2 = DependencyService.Get<ApiService>().Tasks;

            foreach (Tassk i in iems2)
            {
                Tasks.Add(Create(i));
            }

            return base.OnResume();
        }

        public Tassk Create(Tassk tassk)
        {
            return new Tassk(
                )
            {
                Name = tassk.Name
            }
                ;


            return null;

        }
    }
}

