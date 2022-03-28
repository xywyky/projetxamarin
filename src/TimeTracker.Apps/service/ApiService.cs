using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public Token token;

        public Profil ME;

        public List<Datum> Projet;

        public ApiService()
        {
           client = new HttpClient()
           {
               BaseAddress = new Uri(baseUrl)
           };

        }


        //ajouter les erreurs pour les affichages
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
            var bodystringresponse = await response.Content.ReadAsStringAsync();
            token = JsonConvert.DeserializeObject<Token>(bodystringresponse);


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


        public async void getProjects()
        {
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.data.access_token);
            var json2 = await client.GetAsync("api/v1/projects");
            var bodystringresponse = await json2.Content.ReadAsStringAsync();
            var presqueproj = JsonConvert.DeserializeObject<Projet2>(bodystringresponse);
            Projet = presqueproj.data;
            
        }

        public async void postProjects(string name, string description)
        {

            var values = new Dictionary<string, string>
            {
                { "name", name },
                { "description", description}

            };
            var json = JsonConvert.SerializeObject(values);
            var content =
                new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/v1/projects", content);

            Console.WriteLine(response);
        }

        public void deleteProjects(int id)
        {
            Console.WriteLine("ho");
            Console.WriteLine(id);
            client.DeleteAsync("api/v1/projects/" + id);
        }


        public async Task<Profil> getMe()
        {
            Console.WriteLine("oui");
            var test = await client.GetAsync("api/v1/me");
            Console.WriteLine("oui");
            var bodystringresponse = await test.Content.ReadAsStringAsync();
            Console.WriteLine(bodystringresponse);
            ME = JsonConvert.DeserializeObject<Profil>(bodystringresponse);

            return ME;
        }

        public async Task<HttpResponseMessage> patchMe(string email, string last_name, string first_name)
        {
            var values = new Dictionary<string, string>
            {
                { "email", email },
                { "first_name", first_name},
                { "last_name", last_name }
            };

            var json = JsonConvert.SerializeObject(values);
            var content =
                new StringContent(json, Encoding.UTF8, "application/json");

            var method = new HttpMethod("PATCH");

            var request = new HttpRequestMessage(method, "api/v1/me")
            {
                Content = content
            };

            var response = await client.SendAsync(request);

            return response;

        }

        public async Task patchpasswordAsync(string old_pass, string new_pass)
        {
            var values = new Dictionary<string, string>
            {
                { "old_password", old_pass },
                { "new_password", new_pass}
            };

            var json = JsonConvert.SerializeObject(values);
            var content =
                new StringContent(json, Encoding.UTF8, "application/json");

            var method = new HttpMethod("PATCH");

            var request = new HttpRequestMessage(method, "api/v1/password")
            {
                Content = content
            };

            client.SendAsync(request);

        }


    }
}


