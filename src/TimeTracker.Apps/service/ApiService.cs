using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
            Console.WriteLine(response);

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
            Console.WriteLine(response);

            return response;

        }

    }
}
