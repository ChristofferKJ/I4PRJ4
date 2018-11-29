using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using App1.Model;
using App1.Services;
using TaskList.Core;
using Xamarin.Forms;


namespace App1.ViewModel
{
    public class QuizViewModel : BaseViewModel
    {
        private Question theQuestion;
        public Question TheQuestion { get => theQuestion; set => SetProperty(ref theQuestion, value); }

        Quiz theQuiz;

        public Quiz TheQuiz{ get => theQuiz; set => SetProperty(ref theQuiz, value); }

        List<Quiz> myQuizzes;

        public List<Quiz> MyQuizzes{ get => myQuizzes; set => SetProperty(ref myQuizzes, value); }
        public ICommand RefreshCommand { get; }

        public ICommand AnswerCommand { get; }

        private int count;

        public QuizViewModel()
        {
            theQuiz = new Quiz();
            myQuizzes = new List<Quiz>();
            count = 0;
            TotalScore = 0;
            RefreshCommand = new Command(async () => await ExecuteRefreshQuizListCommand());
            AnswerCommand = new Command(ExcuteAnswerCommand);
        }

        
        async Task ExecuteRefreshQuizListCommand()
        {
            var services = new QuizDBServices();
            MyQuizzes = await services.RefreshDataAsync();
            TheQuiz = MyQuizzes[0];
            TheQuestion = TheQuiz.Question[0];
            Title = theQuiz.Category;
            
        }

        void ExcuteAnswerCommand()
        {
            if (count < TheQuiz.Question.Count)
                TotalScore += TheQuiz.Question[count].Score;
            count++;
            if(count < TheQuiz.Question.Count)
                TheQuestion = TheQuiz.Question[count];
        }
    }

    
}
