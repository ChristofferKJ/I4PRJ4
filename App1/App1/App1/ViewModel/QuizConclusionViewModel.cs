using System.Collections.Generic;
using System.Threading.Tasks;
using App1.Model;
using App1.Services;

namespace App1.ViewModel
{
    class QuizConclusionViewModel : BaseViewModel
    {
        private IAPIService _apiServices;
        private List<CategoryScoreModel> Highscores { get; set; }
        public CategoryScoreModel CurrentHighScore{ get; set; }

        Quiz completedQuiz;
        public Quiz CompletedQuiz { get => completedQuiz; set => SetProperty(ref completedQuiz, value); }

        private double totalScore;
        public double TotalScore
        {
            get => totalScore;
            set => SetProperty(ref totalScore, value);
        }

        private string scoreLabel;
        public string ScoreLabel
        {
            get => scoreLabel;
            set => SetProperty(ref scoreLabel, value);
        }

        private string quizDescription_;

        public string QuizDescription
        {
            get => quizDescription_;
            set => SetProperty(ref quizDescription_, value);
        }

        private string highScoreUpdatedDescription_;

        public string HighScoreUpdatedDescription
        {
            get => highScoreUpdatedDescription_;
            set => SetProperty(ref highScoreUpdatedDescription_, value);
        }

        public QuizConclusionViewModel(Quiz quiz, double score, IAPIService service = null)
        {
            if (service != null)
                _apiServices = service;
            else
            {
                _apiServices = new ApiServices();
            }
            
            Title = "Quiz Afsluttet";
            completedQuiz = quiz;
            TotalScore = score;
            ScoreLabel = string.Format("Du har scoret: {0:0.00} Points", TotalScore);
            QuizDescription = $"{completedQuiz.QuizName}, {completedQuiz.Category}";
            HighScoreUpdatedDescription = "";
            updateHighScore();

            
        }

        private void updateHighScore()
        {
            // LoadUserHighScores();
            // CurrentHighScore = findUserHighScoreForQuizCategory(completedQuiz.Category);

            int currentHighScore = 0;

            if((int) TotalScore > currentHighScore)
           // if ((int) TotalScore > CurrentHighScore.HighScore)
            {

                // HighScoreUpdatedDescription =
                //   $"Tillykke du har slået din egen highscore for {completedQuiz.Category} på {CurrentHighScore.HighScore}";

                 HighScoreUpdatedDescription =
                   $"Tillykke du har slået din egen highscore for {completedQuiz.Category} på {currentHighScore}";
            }
        }

        private async void LoadUserHighScores()
        {
            Highscores = await _apiServices.GetHighScoreForCurrentUser();
        }

        private CategoryScoreModel findUserHighScoreForQuizCategory(string category)
        {

            CategoryScoreModel currentHighCategoryScoreModel = null;

            foreach (var score in Highscores)
            {
                if (score.Category == category)
                    currentHighCategoryScoreModel = score;
            }

            return currentHighCategoryScoreModel;
        }

        private async void updateUserHighScoreOnDatabase(double newHighScore)
        {

            if (CurrentHighScore != null)
            {
                CurrentHighScore.HighScore = (int) TotalScore;
                await _apiServices.PutHighscore(CurrentHighScore);
            }
            else
            {
                CurrentHighScore = new CategoryScoreModel();
                CurrentHighScore.Category = completedQuiz.Category;
                CurrentHighScore.HighScore = (int)TotalScore;
                await _apiServices.PostHighscore(CurrentHighScore);
            }
        }



    }

}
