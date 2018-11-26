using App1.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Diagnostics;
using System.Net;

namespace App1.Services
{
    class ApiServices
    {
        internal async Task<bool> RegisterAsync(string username, string email, string password, string confirmPassword)
        {
            var client = new HttpClient();

            var model = new NewUserBindingModel()
            {
                Email = email,
                Username = username,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("https://asestudyhelper.azurewebsites.net/api/Account/Register", content);

            return response.IsSuccessStatusCode;
        }
        public async Task<HttpResponseMessage> LoginAsync(string username, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string,string> ("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string,string> ("grant_type", "password")
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "https://asestudyhelper.azurewebsites.net/Token");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            return response;
            //Debug.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }
}
