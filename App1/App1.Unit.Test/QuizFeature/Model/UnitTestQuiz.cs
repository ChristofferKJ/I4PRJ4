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
        private int eventsreceived;
        private Quiz uut;

        [SetUp]
        public void Setup()
        {
            uut = new Quiz();
            eventsreceived = 0;

            uut.PropertyChanged += (o, args) => { eventsreceived++; };
        }

        [Test]
        public void TestPropertyChangedIsSetOnId()
        {
            uut.Id = "TestId";

            Assert.That(eventsreceived, Is.EqualTo(1));
        }

        [Test]
        public void TestPropertyChangedCountsUpOnId()
        {
            uut.Id = "TestId";
            uut.Id = "TestId1";

            Assert.That(eventsreceived, Is.EqualTo(2));
        }

        [Test]
        public void TestPropertyChangedIsSetRightWithSameValueOnId()
        {
            uut.Id = "TestId";
            uut.Id = "TestId";

            Assert.That(eventsreceived, Is.Not.EqualTo(2));
            Assert.That(eventsreceived, Is.EqualTo(1));
        }

        [Test]
        public void TestPropertyChangedIsSetOnCategory()
        {
            uut.Id = "TestCategory";

            Assert.That(eventsreceived, Is.EqualTo(1));
        }


        [Test]
        public void TestPropertyChangedCountsUpOnCategory()
        {
            uut.Category = "TestCategory";
            uut.Category = "TestCategory1";

            Assert.That(eventsreceived, Is.EqualTo(2));
        }

        [Test]
        public void TestPropertyChangedIsSetRightWithSameValueOnCategory()
        {
            uut.Category = "TestCategory";
            uut.Category = "TestCategory";

            Assert.That(eventsreceived, Is.Not.EqualTo(2));
            Assert.That(eventsreceived, Is.EqualTo(1));
        }

        [Test]
        public void TestPropertyChangedIsSetOnQuizName()
        {
            uut.QuizName = "TestQuizName";

            Assert.That(eventsreceived, Is.EqualTo(1));
        }


        [Test]
        public void TestPropertyChangedCountsUpOnQuizName()
        {
            uut.QuizName = "TestQuizName";
            uut.QuizName = "TestQuizName1";

            Assert.That(eventsreceived, Is.EqualTo(2));
        }

        [Test]
        public void TestPropertyChangedIsSetRightWithSameValueOnQuizName()
        {
            uut.QuizName = "TestQuizName";
            uut.QuizName = "TestQuizName";

            Assert.That(eventsreceived, Is.Not.EqualTo(2));
            Assert.That(eventsreceived, Is.EqualTo(1));
        }


        [Test]
        public void TestPropertyChangedIsSetOnQuestions()
        {
            uut.Question = new List<Question>();

            Assert.That(eventsreceived, Is.EqualTo(1));
        }

        [Test]
        public void TestPropertyChangedIsSetRightWithSameValueOnQuestions()
        {
            uut.Question = new List<Question>();
            uut.Question = new List<Question>();

            Assert.That(eventsreceived, Is.EqualTo(2));
        }

        [Test]
        public void NextQuestionWhenNotLastQuestion_ReturnsQuestion()
        {
            uut.Question = new List<Question>(){new Question(), new Question()};

            Question question = uut.NextQuestion();
            bool exists = question != null;

            Assert.That(exists, Is.EqualTo(true));

        }

        [Test]
        public void NextQuestionWhenLastQuestion_ReturnsNull()
        {
            uut.Question = new List<Question>() {};

            Question question = uut.NextQuestion();
            bool exists = question == null;

            Assert.That(exists, Is.EqualTo(true));

        }
    } 
}