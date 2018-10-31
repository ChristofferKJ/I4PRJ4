using System;
using System.Collections.Generic;

namespace QuizModelLib
{
    public class Quiz
    {
        public virtual int _QuizID { get; set; }
        public virtual List<Question> _QuestionsList { get; set; }
        public virtual string _QuizName { get; set; }
        public virtual int _TopicID { get; set; }
        public virtual double _TotalScore { get; set; }
    }
}
