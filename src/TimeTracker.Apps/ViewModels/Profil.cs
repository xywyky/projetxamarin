using System;
using Storm.Mvvm;
using Xamarin.Forms;

namespace TimeTracker.Apps.ViewModels
{
    public class Data2
    {
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    }

    public class Profil
    {
        public Data2 data { get; set; }
        public bool is_success { get; set; }
        public object error_code { get; set; }
        public object error_message { get; set; }
    }

}

