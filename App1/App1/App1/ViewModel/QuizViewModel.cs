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
            RefreshCommand = new Command(async () => await ExecuteRefreshQuizListCommand());
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

        async Task ExecuteRefreshQuizListCommand()
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

    /*
     public class QuizViewModel : BaseViewModel
    {
        public Quiz TheQuiz { get; set; }
        Question currentQuetsion;

        public Question CurrentQuestion
        {
            get => currentQuetsion;
            set
            {
                if (currentQuetsion == value)
                    return;

                currentQuetsion = value;

                HandlePropertyChanged();
            }
        }
    

        public event EventHandler AnswerGiven;
        public ICommand AnswerSelectedCommand { get; }

        public QuizViewModel(Quiz theQuiz, bool isNew)
        {

            #region
            TotalScore = 0;
            //_isNew = isNew;
            //TheQuiz = theQuiz;
            //test:
            Quiz quiz = new Quiz();

            var q1 = new Question();
            var q2 = new Question();
            q1.QuestionText = "Hvad står ASE for";
            q2.QuestionText = "Hvor høj er mount everest";
            Option op1_1 = new Option();
            Option op1_2 = new Option();
            Option op1_3 = new Option();
            Option op1_4 = new Option();
            Option op2_1 = new Option();
            Option op2_2 = new Option();
            Option op2_3 = new Option();
            Option op2_4 = new Option();

            op1_1.OptionText = "Aarhus School of Mathematics";
            op1_1.IsRight = false;
            op1_2.OptionText = "Aarhus School of Eletronics";
            op1_2.IsRight = false;
            op1_3.OptionText = "Aalborg School of Eletronics";
            op1_3.IsRight = false;
            op1_4.OptionText = "Aarhus School of Engineering";
            op1_4.IsRight = true;
            op2_1.OptionText = "8848 m";
            op2_1.IsRight = true;
            op2_2.OptionText = "8672 m";
            op2_2.IsRight = false;
            op2_3.OptionText = "9018 m";
            op2_3.IsRight = false;
            op2_4.OptionText = "8901 m";
            op2_4.IsRight = false;

            q1.Option0 = op1_1;
            q1.Option1 = op1_2;
            q1.Option2 = op1_3;
            q1.Option3 = op1_4;

            q2.Option0 = op2_1;
            q2.Option1 = op2_2;
            q2.Option2 = op2_3;
            q2.Option3 = op2_4;

            quiz.Questions[0] = q1;
            quiz.Questions[1] = q1;

            #endregion

            currentQuetsion = quiz.GetNextQuestion();

            //Title = isNew ? "New Quiz" : TheQuiz.Category;
            //SaveCommand = new Command(async () => await ExecuteSaveCommand());

            //MyQuizzes = new List<Quiz>();
            //RefreshCommand = new Command(async () => await ExecuteRefreshQuizListCommand());
            AnswerSelectedCommand = new Command(async () => await ExecuteAnswerSelectedCommand());



        }

        public double TotalScore { get; set; }

        async Task ExecuteAnswerSelectedCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                // TotalScore += SCOREMETHOD(option??)
                currentQuetsion = TheQuiz.GetNextQuestion();
                Thread.Sleep(1000);
            }
            finally
            {
                IsBusy = false;
            }
        }



        #region legacy 
        /*

         public ICommand SaveCommand { get; }
         private bool _isNew;
         public event EventHandler SaveComplete;

         //<Quiz> myQuizzes;
         //public List<Quiz> MyQuizzes { get => myQuizzes; set => SetProperty(ref myQuizzes, value); }
         //public ICommand RefreshCommand { get; }

         public QuizViewModel(Quiz theQuiz, bool isNew)
         {
             _isNew = isNew;
             TheQuiz = theQuiz;
             Title = isNew ? "New Quiz" : TheQuiz.Category;
             SaveCommand = new Command(async () => await ExecuteSaveCommand());

             MyQuizzes = new List<Quiz>();
             RefreshCommand = new Command(async () => await ExecuteRefreshQuizListCommand());
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

         async Task ExecuteRefreshQuizListCommand()
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
         */

}
