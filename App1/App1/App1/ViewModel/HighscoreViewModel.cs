using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using App1.Model;
using App1.Services;
using Xamarin.Forms;

namespace App1.ViewModel
{
    class HighscoreViewModel
    {
        private ApiServices _apiServices = new ApiServices();
        public List<CategoryScoreModel> Highscores { get; set; }

        public ICommand GetHighscores
        {
            get { return new Command(async () => { Highscores = await _apiServices.GetHighScoreForQuiz(); }); }

        }

        public ICommand PostHighscore
        {
            get
            {
                return new Command(async () =>
                {
                    //todo
                    await _apiServices.PostHighscore(category, score, isHighscore);
                });
            }
        }
    }
}
