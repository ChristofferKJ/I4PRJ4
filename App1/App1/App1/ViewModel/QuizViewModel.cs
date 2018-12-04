using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Timers;
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

        private double timeLeft;
        public double TimeLeft
        {
            get => timeLeft;
            set => SetProperty(ref timeLeft, value);
        }

       // private int count;

        private double totalScore;
        public double TotalScore
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

            // Adding timer test
            timeLeft = 1;
            
            startTimerForTimeLeft();
        }

        
        async Task ExecuteRefreshQuizListCommand()
        {
            var services = new QuizDBServices();
            MyQuizzes = await services.GetAllQuizzesAsync();
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
                TotalScore += TheQuestion.Score * TimeLeft;

            //replace with scoring method
        }

        void updateQuestion(Question newQuestion)
        {
            theQuestion.QuestionText = newQuestion.QuestionText;
            theQuestion.Options = newQuestion.Options;
            theQuestion.Score = newQuestion.Score;
            TimeLeft = 1;
        }

        void startTimerForTimeLeft()
        {
            System.Timers.Timer timer = new System.Timers.Timer(500);
            timer.Enabled = true;
            timer.Elapsed += new ElapsedEventHandler(TimerTick);
            timer.AutoReset = true;
        }

        void TimerTick(object sender, ElapsedEventArgs e)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= 0.025;
            }
            else
            {
                ExcuteAnswerCommand(false);
            }
        }
    }

    
}
