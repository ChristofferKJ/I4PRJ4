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
        public Quiz TheQuiz { get; set; }
        public ICommand SaveCommand { get; }
        private bool _isNew;
        public event EventHandler SaveComplete;

        List<Quiz> myQuizzes;
        public List<Quiz> MyQuizzes { get => myQuizzes; set => SetProperty(ref myQuizzes, value); }
        public ICommand RefreshCommand { get; }

        public QuizViewModel(Quiz theQuiz, bool isNew)
        {
            _isNew = isNew;
            TheQuiz = theQuiz;
            Title = isNew ? "New Quiz" : TheQuiz.Category;
            SaveCommand = new Command(async () => await ExecuteSaveCommand());

            MyQuizzes = new List<Quiz>();
            RefreshCommand = new Command(async () => await ExecuteRefreshCommand());
            IsBusy = false;
        }

        async Task ExecuteSaveCommand()
        {
            var quizServices = new QuizServices();

            if (_isNew)
                await quizServices.CreateTask(TheQuiz);
            else
                await quizServices.UpdateTask(TheQuiz);

            SaveComplete?.Invoke(this, new EventArgs());
        }

        async Task ExecuteRefreshCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var quizServices = new QuizServices();
                MyQuizzes = await quizServices.GetAllQuizzes();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }

}
