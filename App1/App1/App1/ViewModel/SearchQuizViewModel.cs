using System.Collections.Generic;
using System.Threading.Tasks;
using App1.Model;
using App1.Services;

using Xamarin.Forms;
namespace App1.ViewModel
{
    public class SearchQuizViewModel : BaseViewModel
    {
        private QuizDBServices quizService_;

        private List<string> categories_;
        public List<string> Categories { get => categories_; set => SetProperty(ref categories_, value); }

        private List<Quiz> quizzes_;

        public List<Quiz> Quizzes { get => quizzes_; set => SetProperty(ref quizzes_, value); }


        public SearchQuizViewModel(string title)
        {
            Title = title;
            Categories = new List<string>();
            Quizzes = new List<Quiz>();
            quizService_ = new QuizDBServices();
        }

        public async void LoadCategories()
        {
            await ExecuteLoadCategories();
        }

        public async void LoadQuizzesFromCategory(string category)
        {
            await ExecuteLoadQuzzesFromCategory(category);
        }

         async Task ExecuteLoadQuzzesFromCategory(string category)
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                Quizzes = await quizService_.GetQuizzesByCategoryAsync(category);

                
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task ExecuteLoadCategories()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                var quizzes = await quizService_.GetAllQuizzesAsync();

                if (quizzes.Count != 0)
                    Categories = ExtractCategories(quizzes);
            }
            finally
            {
                IsBusy = false;
            }
           
        }

        List<string> ExtractCategories(List<Quiz> quizzes)
        {
            List<string> categories = new List<string>();
            

            foreach (var quiz in quizzes)
            {
                bool categoryAdded = false;
                foreach (var category in categories)
                {
                    if (quiz.Category == category) categoryAdded = true;
                }

                if (!categoryAdded)
                    categories.Add(quiz.Category);
            }

            return categories; 
        }
         
    }
}
