using System;
using System.Collections.Generic;
using System.Windows.Input;
using Newtonsoft.Json;
using Storm.Mvvm;

namespace TimeTracker.Apps.ViewModels
{
    public class Task : NotifierBase
    {
        public int _id;
        public string _name;
        public Time _temps;

        public Task(ICommand deleteCommand)
        {
            DeleteCommand = deleteCommand;
        }
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

        public ICommand DeleteCommand { get; }

        public ICommand EditCommand { get; }
    }
}
