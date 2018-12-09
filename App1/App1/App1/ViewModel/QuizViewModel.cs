using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Input;
using System.Timers;
using App1.Model;
using Xamarin.Forms;


namespace App1.ViewModel
{
    public class QuizViewModel : BaseViewModel
    {
        Quiz theQuiz;
        public Quiz TheQuiz { get => theQuiz; set => SetProperty(ref theQuiz, value); }

        private string b_animation = "#9ab7b6"; 

        private Question theQuestion;
        public Question TheQuestion { get => theQuestion; set => SetProperty(ref theQuestion, value); }

        public Command AnswerCommand { get; private set; }

        public event EventHandler QuizCompleted;

        private double timeLeft;
        public double TimeLeft
        {
            get => timeLeft;
            set => SetProperty(ref timeLeft, value);
        }

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
            TheQuestion.RandomizeOptionOrder();

            TotalScore = 0;
            AnswerCommand = new Command<bool>(ExcuteAnswerCommand);
            timeLeft = 1;

            startTimerForTimeLeft();
        }

        protected virtual void OnQuizCompleted()
        {
            QuizCompleted?.Invoke(this, new EventArgs());
        }

        void ExcuteAnswerCommand(bool isRightAnswer) //Kan kaldes med false, hvis timelimit overstiges.
        {
           updateScore(isRightAnswer);

        

            var nextQuestion = theQuiz.NextQuestion();

            if (nextQuestion != null)
            {
                nextQuestion.RandomizeOptionOrder();
                updateQuestion(nextQuestion);
            }
            else
            {
                OnQuizCompleted();
            }
        }

        void updateScore(bool isRightAnswer)
        {
            if (isRightAnswer)
                TotalScore += TheQuestion.Score * TimeLeft;
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
