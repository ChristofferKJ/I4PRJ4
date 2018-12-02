using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using App1.Model;
using App1.Services;
using Xamarin.Forms;


namespace App1.ViewModel
{
    public class QuizViewModel : BaseViewModel
    {
        Quiz theQuiz;
        public Quiz TheQuiz { get => theQuiz; set => SetProperty(ref theQuiz, value); }

        private Question theQuestion;
        public Question TheQuestion { get => theQuestion; set => SetProperty(ref theQuestion, value); }

        List<Quiz> myQuizzes;

        public List<Quiz> MyQuizzes{ get => myQuizzes; set => SetProperty(ref myQuizzes, value); }
        public ICommand RefreshCommand { get; }

        public ICommand AnswerCommand { get; private set; }

       // private int count;

        private int totalScore;
        public int TotalScore
        {
            get => totalScore;
            set => SetProperty(ref totalScore, value);}

        public QuizViewModel(Quiz quiz)
        {
            theQuiz = quiz;
            theQuiz.RandomizeQuestionOrder();
            Title = theQuiz.Category;
            TheQuestion = theQuiz.Question[0];
            TheQuestion.RandomizeOptionOrder(); //  
            //myQuizzes = new List<Quiz>();
            //count = 0;
            TotalScore = 0;
            //RefreshCommand = new Command(async () => await ExecuteRefreshQuizListCommand());
            AnswerCommand = new Command<bool>(ExcuteAnswerCommand);
        }

        
        async Task ExecuteRefreshQuizListCommand()
        {
            var services = new QuizDBServices();
            MyQuizzes = await services.RefreshDataAsync();
           TheQuiz = MyQuizzes[0];
           TheQuestion = TheQuiz.Question[0];
            TheQuestion.RandomizeOptionOrder();
            Title = theQuiz.Category;
            
        }



        void ExcuteAnswerCommand(bool isRightAnswer) //Kan kaldes med false, hvis timelimit overstiges.
        {
            /* if (count < TheQuiz.Question.Count)
                 TotalScore += TheQuiz.Question[count].Score;
             count++;
             if(count < TheQuiz.Question.Count)
                 TheQuestion = TheQuiz.Question[count]; */

           updateScore(isRightAnswer);

            var nextQuestion = theQuiz.NextQuestion();
            
            if (nextQuestion != null)
            {
                nextQuestion.RandomizeOptionOrder();
                updateQuestion(nextQuestion);
            }
            else
            {
                //terminate quiz - update highscore
            }
        }

        void updateScore(bool isRightAnswer)
        {
            if (isRightAnswer)
                TotalScore = TotalScore + TheQuestion.Score;

            //replace with scoring method
        }

        void updateQuestion(Question newQuestion)
        {
            theQuestion.QuestionText = newQuestion.QuestionText;
            theQuestion.Options = newQuestion.Options;
            theQuestion.Score = newQuestion.Score;
        }
    }

    
}
