using System;
using System.Collections.Generic;
using System.Text;

namespace QuizModelLib
{
    public class Question
    {
        public virtual int _QuestionID { get; set; }
        public virtual string _QuestionText { get; set; }
        public virtual List<Option> _Optionslist { get; set; }
        public virtual int _QuizID { get; set; }
        public virtual double _PointScore { get; set; }
    }
}
