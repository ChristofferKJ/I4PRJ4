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
using App1.Helpers;
using Newtonsoft.Json.Linq;




namespace App1.Services
{
    class ApiServices : IAPIService
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

            var response =
                await client.PostAsync("https://asestudyhelper.azurewebsites.net/api/Account/Register", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "https://asestudyhelper.azurewebsites.net/Token");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);


            var jwt = await response.Content.ReadAsStringAsync();

            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(jwt);


            var accessToken = jwtDynamic.Value<string>("access_token");
            var accessTokenExpirationDate = jwtDynamic.Value<DateTime>(".expires");
            Settings.AccessTokenExpirationDate = accessTokenExpirationDate;
            Debug.WriteLine(await response.Content.ReadAsStringAsync());

            return accessToken;

        }

        public async Task<List<CategoryScoreModel>> GetHighScoreForQuiz()
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);

            var json = await client.GetStringAsync("https://asestudyhelper.azurewebsites.net/api/CategoryScores");

            var highscores = JsonConvert.DeserializeObject<List<CategoryScoreModel>>(json);
            Debug.WriteLine(highscores.ToString());
            return highscores;
        }

        public async Task<List<CategoryScoreModel>> GetHighScoreForCurrentUser()
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);

            var json = await client.GetStringAsync("https://asestudyhelper.azurewebsites.net/api/CategoryScores/CurrentUser");

            var highscores = JsonConvert.DeserializeObject<List<CategoryScoreModel>>(json);
            Debug.WriteLine(highscores.ToString());
            return highscores;
        }

        public async Task<bool> PostHighscore(CategoryScoreModel model)
        {
            var client = new HttpClient();

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response =
                await client.PostAsync("https://asestudyhelper.azurewebsites.net/api/CategoryScores", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> PutHighscore(CategoryScoreModel model)
        {
            var client = new HttpClient();

            var json = JsonConvert.SerializeObject(model);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response =
                await client.PutAsync("https://asestudyhelper.azurewebsites.net/api/CategoryScores/" + model.Id,
                    content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteHighscores()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Settings.AccessToken);
            HttpContent content = new StringContent(String.Empty);

            var response =
                await client.PostAsync("https://asestudyhelper.azurewebsites.net/api/CategoryScores/ResetProfileScore",
                    content);
            
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ChangePassword(string oldPW, string newPW, string conPW)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Settings.AccessToken);
            var model = new ChangePasswordBindingModel(){OldPassword = oldPW,NewPassword = newPW,ConfirmPassword = conPW};

            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("https://asestudyhelper.azurewebsites.net/api/Account/ChangePassword",
                content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteUser()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer",Settings.AccessToken);
            HttpContent content = new StringContent("");

            var response = await client.PostAsync("https://asestudyhelper.azurewebsites.net/api/Account/RemoveUser",content);

            return response.IsSuccessStatusCode;    
        }
    }
}
