using System;

using Xamarin.Forms;

namespace TimeTracker.Apps.ViewModels
{
    public class Body 
    {

        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }


    }

    public class Token
    {
        public Body data { get; set; }
        public bool is_success { get; set; }
        public object error_code { get; set; }
        public object error_message { get; set; }
    }
}

