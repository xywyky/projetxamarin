using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TimeTracker.Apps.ViewModels;

namespace TimeTracker.Apps.Services
{
    public class ApiService
    {


        public string baseUrl = "https://timetracker.julienmialon.ovh/";

        public HttpClient client;

        public ApiService()
        {
           client = new HttpClient()
           {
               BaseAddress = new Uri(baseUrl)
           };

        }
        //il faut recuperer le token bearer et refresh et les stockers
        public async Task<HttpResponseMessage> connect(string log, string pass)
        {
            var values = new Dictionary<string, string>
            {
                { "login", log },
                { "password", pass},
                { "client_id", "MOBILE" },
                { "client_secret", "COURS" }

            };

            var json = JsonConvert.SerializeObject(values);
            var content =
                new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/v1/login", content);
            var bodyresponse = await response.Content.ReadAsStringAsync();

            Console.WriteLine("hihi");
            Console.WriteLine(response.Content.GetType());
            Console.WriteLine(bodyresponse);
            if (!response.IsSuccessStatusCode)
            {

                
            }

            return response;

        }

        public async Task<HttpResponseMessage> inscription(string FN, string LN, string email, string pass)
        {

            var values = new Dictionary<string, string>
            {
                { "client_id", "MOBILE"},
                { "client_secret", "COURS"},
                { "email", email},
                { "first_name", FN},
                { "last_name", LN},
                { "password", pass}

            };
           
            var json = JsonConvert.SerializeObject(values);
            var content =
                new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/v1/register", content);

            return response;

        }

        //il faut changer la Class Projet
        //il faut aussi ajouter le fait de devoir utiliser le token bearer
        //et du coup la class ne fonction pas encore 
        public async Task<IEnumerable<Projet>> getProjects()
        {
            var json = await client.GetStringAsync("api/v1/projects");
            var projects = JsonConvert.DeserializeObject<IEnumerable<Projet>>(json);
            return projects;
        }



    }
}
