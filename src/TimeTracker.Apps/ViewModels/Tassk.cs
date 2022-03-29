using System;
using System.Collections.Generic;
using System.Windows.Input;
using Newtonsoft.Json;
using Storm.Mvvm;

namespace TimeTracker.Apps.ViewModels
{
    public class Tassk : NotifierBase
    {
        public int _id;
        public string _name;
        public List<Time> _temps;

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

        public List<Time> Temps
        {
            get => _temps;
            set => SetProperty(ref _temps, value);
        }

        public Tassk(ICommand deleteCommand, ICommand modifCommand)
        {
            DeleteCommand = deleteCommand;
            ModifCommand = modifCommand;
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