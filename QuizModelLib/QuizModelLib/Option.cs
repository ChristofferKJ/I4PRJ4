using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace QuizModelLib
{
    public class Option
    {
        public virtual int _OptionID { get; set; }
        public virtual string _OptionText { get; set; }
        public virtual bool _IsRight { get; set; }
        public virtual int _QuestionID { get; set; }
    }
}
