using System;
using System.Collections.Generic;
using System.Windows.Input;
using Newtonsoft.Json;
using Storm.Mvvm;
using Xamarin.Forms;

namespace TimeTracker.Apps.ViewModels
{
    public class Tassk : NotifierBase
    {
        public int _id;
        public string _name;
        public Time _temps;
        private TimeSpan _current;


        public ICommand DeleteCommand { get; }
        public ICommand ModifCommand { get; }

        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public Time Temps
        {
            get => _temps;
            set => SetProperty(ref _temps, value);
        }

        public TimeSpan Current
        {
            get => _current;
            set
            {
                SetProperty(ref _current, value);
                Update();
            }
        }

        public Tassk(ICommand deleteCommand, ICommand modifCommand)
        {
            DeleteCommand = deleteCommand;
            ModifCommand = modifCommand;
        }

        public void Update()
        {
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                // do something every 1 second
                Device.BeginInvokeOnMainThread(() =>
                {
                    Current = Current.Subtract(new TimeSpan(0,0,1));
                });
                return true; // runs again, or false to stop
            });
        }

    }

    public class Root
    {
        public List<Tassk> data { get; set; }
        public bool is_success { get; set; }
        public string error_code { get; set; }
        public string error_message { get; set; }
    }
}