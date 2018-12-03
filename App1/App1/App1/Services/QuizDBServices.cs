using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using App1.Model;
using Newtonsoft.Json;

namespace App1.Services
{
    class QuizDBServices
    {
        private HttpClient QuizDBClient;

        public QuizDBServices()
        {
            QuizDBClient = new HttpClient();
            QuizDBClient.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<Quiz>> GetAllQuizzesAsync()
        {
            var uri = new Uri("https://ase-studyhelper-quiz.azurewebsites.net/api/QuizToAPI");
            
            
            var response = await QuizDBClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var Quizzes = JsonConvert.DeserializeObject<List<Quiz>>(content);
                return Quizzes;
            }
            else
            {
                return null;
            }
            
        }

        public async Task<List<Quiz>> GetQuizzesByCategoryAsync(string category)
        {
            var uri = new Uri("https://ase-studyhelper-quiz.azurewebsites.net/api/QuizToAPI/" + category);

            var response = await QuizDBClient.GetAsync(uri);
           
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var Quizzes = JsonConvert.DeserializeObject<List<Quiz>>(content);
                JsonConvert.SerializeObject(new Quiz());
                return Quizzes;
            }
            else
            {
                return null;
            }

        }
    }
}
