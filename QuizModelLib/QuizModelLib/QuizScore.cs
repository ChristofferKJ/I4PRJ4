using System;
using System.Collections.Generic;
using System.Text;

namespace QuizModelLib
{
    public class QuizScore
    {
        public virtual int _QuizScoreID { get; set; }
        public virtual int _UserID { get; set; }
        public virtual int _QuizID { get; set; }
        public virtual int _CorrectQuestions { get; set; }

    }
}
