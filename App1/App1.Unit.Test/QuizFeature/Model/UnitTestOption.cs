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
    class UnitTestOption
    {
      
        private Option uut_;
        [SetUp]
        [Author("Kasper Andersen")]
        public void Setup()
        {

            uut_ = new Option();
            uut_.IsRight = true;
            uut_.OptionText = "";
        }

        [Test]
        public void IsRightChangedToNewValue_PropertyChangedInvoked()
        {
            int propertychangedCounter = 0;
            uut_.PropertyChanged += (o, arg) => { propertychangedCounter++; };

            uut_.IsRight = false;

            Assert.That(propertychangedCounter, Is.EqualTo(1));
            Assert.That(uut_.IsRight, Is.EqualTo(false));

        }

        [Test]
        public void IsRightChangedToSameValue_PropertyChangedNotInvoked()
        {
            int propertychangedCounter = 0;
            uut_.PropertyChanged += (o, arg) => { propertychangedCounter++; };

            uut_.IsRight = false;
            uut_.IsRight = false;

            Assert.That(propertychangedCounter == 2, Is.EqualTo(false));
            Assert.That(propertychangedCounter == 1, Is.EqualTo(true));
            Assert.That(uut_.IsRight, Is.EqualTo(false));

        }

        [Test]
        public void OptionTextChangedToNewString_PropertyChangedInvoked()
        {
            int propertychangedCounter = 0;
            uut_.PropertyChanged += (o, arg) => { propertychangedCounter++; };

            string answer = "anwser";
            uut_.OptionText = answer;

            Assert.That(propertychangedCounter, Is.EqualTo(1));
            Assert.That(uut_.OptionText, Is.EqualTo(answer));

        }

        [Test]
        public void OptionTextChangedToNewString_PropertyChangedNotInvoked()
        {
            int propertychangedCounter = 0;
            uut_.PropertyChanged += (o, arg) => { propertychangedCounter++; };

            string answer = "anwser";
            uut_.OptionText = answer;
            uut_.OptionText = answer;

            Assert.That(propertychangedCounter == 2, Is.EqualTo(false));
            Assert.That(propertychangedCounter == 1, Is.EqualTo(true));
            Assert.That(uut_.OptionText, Is.EqualTo(answer));
        }



    }

}