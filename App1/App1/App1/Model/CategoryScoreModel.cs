using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Model
{
    class CategoryScoreModel
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public int HighScore { get; set; }
        public bool IsTotalHighscore { get; set; }

        public string UserId { get; set; }
    }
}
