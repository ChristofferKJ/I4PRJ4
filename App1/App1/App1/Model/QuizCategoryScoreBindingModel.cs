using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Model
{
    public class QuizCategoryScoreBindingModel
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public int HighScore { get; set; }

        public int UserId { get; set; }
    }
}
