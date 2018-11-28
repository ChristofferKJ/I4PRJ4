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
        Quiz theQuiz;

        public Quiz TheQuiz{ get => theQuiz; set => SetProperty(ref theQuiz, value); }

        List<Quiz> myQuizzes;

        public List<Quiz> MyQuizzes{ get => myQuizzes; set => SetProperty(ref myQuizzes, value); }
        public ICommand RefreshCommand { get; }

        public QuizViewModel()
        {
            theQuiz = new Quiz();
            myQuizzes = new List<Quiz>();
            
            
            RefreshCommand = new Command(async () => await ExecuteRefreshQuizListCommand());
        }

        
        async Task ExecuteRefreshQuizListCommand()
        {
            var services = new QuizDBServices();
            MyQuizzes = await services.RefreshDataAsync();
            TheQuiz = MyQuizzes[0];
        }
    }

    
}
