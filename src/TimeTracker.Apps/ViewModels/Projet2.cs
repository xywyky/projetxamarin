using System;
using System.Collections.Generic;
using System.Windows.Input;
using Microcharts;
using Newtonsoft.Json;
using Storm.Mvvm;

namespace TimeTracker.Apps.ViewModels
{

    public class Datum : NotifierBase
    {
        public int _id; 
        public string _name;
        public string _description;
        public long _total_seconds;

        public Datum(ICommand deleteCommand, ICommand modifCommand, ICommand taskCommand)
        {
            DeleteCommand = deleteCommand;
            ModifCommand = modifCommand;
            TaskCommand = taskCommand;
        }


        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public long Total_seconds
        {
            get => _total_seconds;
            set => SetProperty(ref _total_seconds, value);
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

        public ICommand TaskCommand { get; }


    }

    public class Projet2 
    {
        public List<Datum> data { get; set; }
        public bool is_success { get; set; }
        public object error_code { get; set; }
        public object error_message { get; set; }
    }

    
}
