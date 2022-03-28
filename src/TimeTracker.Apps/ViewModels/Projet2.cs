using System;
using System.Collections.Generic;
using System.Windows.Input;
using Newtonsoft.Json;
using Storm.Mvvm;

namespace TimeTracker.Apps.ViewModels
{

    public class Datum : NotifierBase
    {
        public int _id; 
        public string _name;
        public string _description;
        public int _total_seconds;

        public Datum(ICommand deleteCommand, ICommand modifCommand)
        {
            DeleteCommand = deleteCommand;
            ModifCommand = modifCommand;
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

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public ICommand DeleteCommand { get; }

        public ICommand ModifCommand { get; }


    }

    public class Projet2 
    {
        public List<Datum> data { get; set; }
        public bool is_success { get; set; }
        public object error_code { get; set; }
        public object error_message { get; set; }
    }

    
}
