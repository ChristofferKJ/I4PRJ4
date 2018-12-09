using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Model;
using NUnit.Framework;

namespace App1.Unit.Test.QuizFeature.Model
{
    
    [TestFixture]
    class UnitTestQuiz
    {

        private Quiz uut_;
        [SetUp]
        [Author("Kasper Andersen")]
        public void Setup()
        {
            uut_ = new Quiz();
        }

       

    } 

}