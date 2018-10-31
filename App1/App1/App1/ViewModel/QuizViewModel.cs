using System;
using System.Collections.Generic;
using System.Text;
using App1.Model;
using App1.Services;

namespace App1.ViewModel
{
    public class QuizViewModel : UserViewModelBase
    {
        public QuizViewModel()
        {
            var service = new QuizServices();
            QuizList = service.GetQuiz();

        }

        private List<Quiz> quizList;

        public List<Quiz> QuizList
        {
            get { return quizList; }
            set { SetProperty(ref quizList, value); }

        }
    }
}
