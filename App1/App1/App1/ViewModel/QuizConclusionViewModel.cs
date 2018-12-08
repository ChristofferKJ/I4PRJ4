using App1.Model;

namespace App1.ViewModel
{
    class QuizConclusionViewModel : BaseViewModel
    {
        //need private userService

        Quiz completedQuiz;
        public Quiz CompletedQuiz { get => completedQuiz; set => SetProperty(ref completedQuiz, value); }

        private double totalScore;
        public double TotalScore
        {
            get => totalScore;
            set => SetProperty(ref totalScore, value);
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

        public QuizConclusionViewModel(Quiz quiz, double score)
        {
            //initialize userService
            Title = "Quiz Afsluttet";
            completedQuiz = quiz;
            TotalScore = score;
            QuizDescription = $"{completedQuiz.QuizName}, {completedQuiz.Category}";
            HighScoreUpdatedDescription = "";
            updateHighScore();

            
        }

        private void updateHighScore()
        {
            double currentHighScore = 0;
           // get currentHighScore
            if (TotalScore > currentHighScore)
            {
                //update highScore
                HighScoreUpdatedDescription =
                    $"Tillykke du har slået din egen highscore for {completedQuiz.Category} på {currentHighScore}";
            }
        }




    }

}
