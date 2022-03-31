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
        public List<Time> times { get; set; }
        


        public ICommand DeleteCommand { get; }
        public ICommand ModifCommand { get; }
        public ICommand HistoCommand { get; }
        public ICommand TimerCommand { get; }
        public ICommand FinTimerCommand { get; }

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

        
        public Tassk(ICommand deleteCommand, ICommand modifCommand, ICommand histoCommand, ICommand timerCommand, ICommand finTimerCommand )
        {
            DeleteCommand = deleteCommand;
            ModifCommand = modifCommand;
            HistoCommand = histoCommand;
            TimerCommand = timerCommand;
            FinTimerCommand = finTimerCommand;

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