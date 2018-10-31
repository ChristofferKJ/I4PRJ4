using System;
using System.Collections.Generic;
using System.Text;
using App1.Model;

namespace App1.Services
{
    public class QuizServices
    {
        public QuizServices()
        {

        }

        public List<Quiz> GetQuiz()
        {
            var list = new List<Quiz>
            {
                new Quiz
                {
                    Questions = "Hvad er 2+2?",
                    Answers = "4"

                },

                new Quiz
                {
                    Questions = "Hvad er 4*4?",
                    Answers = "16"
                }
                


            };

            return list; 
        }

    }
}
