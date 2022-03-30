using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Storm.Mvvm;
using Storm.Mvvm.Navigation;
using TimeTracker.Apps.Services;
using Xamarin.Forms;

namespace TimeTracker.Apps.ViewModels
{
    public class ListTimerViewModel : ViewModelBase
    {

        private ObservableCollection<Time> _times;

        public ICommand BackCommand { get; }

        private int _index;

        [NavigationParameter]
        public int Index
        {
            get => _index;
            set => SetProperty(ref _index, value);
        }

        public ObservableCollection<Time> Times
        {
            get => _times;
            set => SetProperty(ref _times, value);
        }



        public ListTimerViewModel()
        {
            Times = new ObservableCollection<Time>();

            BackCommand = new Command(BackAction);

        }

        private async void BackAction()
        {
            await NavigationService.PopAsync();
        }

        public override Task OnResume()
        {
            List<Tassk> iems2 = DependencyService.Get<ApiService>().Tasks;

            foreach (Tassk i in iems2)
            {
                if (testid(i) == Index)
                {

                    List<Time> j = i.times;

                    Console.WriteLine(i.Name);
                    if (j != null)
                    {

                        Create(j);
                    }
                    else
                    {
                        Console.WriteLine(Index);
                    }

                    return base.OnResume();
                }

            }

            //retourner une erreur
            return base.OnResume();
        }

        private int testid(Tassk i)
        {
            return i.Id;
        }


        public void Create(List<Time> time)
        {

            foreach (Time j in time)
            {
                Times.Add(new Time()
                {
                    Id = j.Id,
                    StartTime = j.StartTime,
                    EndTime = j.EndTime
                });

            }
        }
    }
}

