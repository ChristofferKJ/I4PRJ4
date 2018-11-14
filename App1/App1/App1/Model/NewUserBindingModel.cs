using System;
using System.Collections.Generic;
using System.Text;


namespace App1.Model
{
    public class NewUserBindingModel
    {
        public int Id { get; set;}
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string TotalHighscore { get; set; }

        public IList<QuizCategoryScoreBindingModel> QuizCategoryScore { get; set; }
    }

}