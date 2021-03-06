using System;
using System.Collections.Generic;
using System.Windows.Input;
using Newtonsoft.Json;
using Storm.Mvvm;

namespace TimeTracker.Apps.ViewModels
{
    public class Time : NotifierBase
    {
        public int _id;

        public DateTime _start_time;
        public DateTime _end_time;


        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        [JsonProperty("start_time")]
        public DateTime StartTime
        {
            get => _start_time;
            set => SetProperty(ref _start_time, value);
        }

        [JsonProperty("end_time")]
        public DateTime EndTime
        {
            get => _end_time;
            set => SetProperty(ref _end_time, value);
        }


    }
}
