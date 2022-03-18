
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using TimeTracker.Apps.ViewModels;
using Xamarin.Essentials;

namespace TimeTracker.Apps.Services
{
    public class ProjetService
    {
        public List<string> Projet { get; }

        public ProjetService()
        {
            string projet = Preferences.Get(nameof(ProjetService), "[]");
            Projet = JsonConvert.DeserializeObject<List<string>>(projet);
           
        }
        public void Save()
        {
            string content = JsonConvert.SerializeObject(Projet);
            Preferences.Set(nameof(ProjetService), content);
        }

    }
}
