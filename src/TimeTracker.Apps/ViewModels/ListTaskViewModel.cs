using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Storm.Mvvm;
using TimeTracker.Apps.Pages;
using TimeTracker.Apps.Services;
using Xamarin.Forms;

namespace TimeTracker.Apps.ViewModels
{
    public class ListTaskViewModel : ViewModelBase
    {

        private ObservableCollection<Tassk> _tasks;

        public ICommand AddCommand { get; }

        public ObservableCollection<Tassk> Tasks
        {
            get => _tasks;
            set => SetProperty(ref _tasks, value);
        }



        public ListTaskViewModel()
        {
            Tasks = new ObservableCollection<Tassk>();

            AddCommand = new Command(AddAction);
        }


        private void AddAction(object obj)
        {
            NavigationService.PushAsync<AddOrEditTask>(new Dictionary<string, object>()
            {
                ["Index"] = -1
            });
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

        //surment ajouter le temps plus tard dans un Task 
        public Tassk Create(Tassk tassk)
        {

            return new Tassk(
                new Command<Tassk>(DeleteAction),
                new Command<Tassk>(ModifAction),
                new Command<Tassk>(HistoAction)
                )
            {
                Name = tassk.Name,
                Id = tassk.Id,
                times = tassk.times
               
                
            }
                ;


            return null;

        }

        private void HistoAction(Tassk tassk)
        {
            NavigationService.PushAsync<ListTimerHistorique>(new Dictionary<string, object>()
            {
                ["Index"] = tassk.Id
            });
        }

        private void ModifAction(Tassk tassk)
        {
            NavigationService.PushAsync<AddOrEditTask>(new Dictionary<string, object>()
            {
                ["Index"] = tassk.Id
            });
        }

        private void DeleteAction(Tassk tassk)
        {
            int index = tassk.Id;
            var todoService = DependencyService.Get<ApiService>();
            todoService.deleteTaskAsync(index);
            todoService.getTasks(todoService.proj);
        }
    }
}

