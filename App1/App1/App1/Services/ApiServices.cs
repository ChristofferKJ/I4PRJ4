using App1.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace App1.Services
{
    class ApiServices
    {
        internal async Task<bool> RegisterAsync(string username, string email, string password, string confirmPassword)
        {
            var client = new HttpClient();

            var model = new NewUserBindingModel()
            {
                Id = 0,
                UserName = username,
                Password = password,
                Email = email,
                QuizCategoryScore = null,
                TotalHighscore = null,
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("https://asestudyhelper.azurewebsites.net/api/Users",content);

            return response.IsSuccessStatusCode;
        }
    }
}
