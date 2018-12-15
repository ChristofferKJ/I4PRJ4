using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App1.Model;

namespace App1.Services
{
    public interface IAPIService
    {
        Task<string> LoginAsync(string username, string password);

        Task<List<CategoryScoreModel>> GetHighScoreForQuiz();
        Task<List<CategoryScoreModel>> GetHighScoreForCurrentUser();

        Task<bool> PostHighscore(CategoryScoreModel model);
       

       Task<bool> PutHighscore(CategoryScoreModel model);

       Task<bool> DeleteHighscores();


        Task<bool> ChangePassword(string oldPW, string newPW, string conPW);


        Task<bool> DeleteUser();

    }
}

