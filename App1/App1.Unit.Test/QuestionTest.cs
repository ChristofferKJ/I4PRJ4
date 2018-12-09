using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Model;
using NUnit.Framework;


namespace App1.Unit.Test
{
    [TestFixture]
    public class QuestionTest
    {
        private Question uut;
        private int eventsreceived;

        [SetUp]
        public void Setup()
        {
            uut = new Question();
            eventsreceived = 0;

            uut.PropertyChanged += (o, args) => { eventsreceived++; };
        }

        [Test]
        public void TestPropertyChangedIsSetOnQuestionText()
        {
            uut.QuestionText = "TestQuestionText";

            Assert.That(eventsreceived, Is.EqualTo(1));
        }

        [Test]
        public void TestPropertyChangedCountsUpOnQuestionText()
        {
            uut.QuestionText = "TestQuestionText";
            uut.QuestionText = "TestQuestionText1";

            Assert.That(eventsreceived, Is.EqualTo(2));
        }

        [Test]
        public void TestPropertyChangedIsSetRightWithSameValueOnQuestionText()
        {
            uut.QuestionText = "TestQuestionText";
            uut.QuestionText = "TestQuestionText";

            Assert.That(eventsreceived, Is.Not.EqualTo(2));
            Assert.That(eventsreceived, Is.EqualTo(1));
        }

        [Test]
        public void TestPropertyChangedIsSetOnScore()
        {
            uut.Score = 1068;

            Assert.That(eventsreceived, Is.EqualTo(1));
        }

        [Test]
        public void TestPropertyChangedCountsUpOnScore()
        {
            uut.Score = 1068;
            uut.Score = 1069;

            Assert.That(eventsreceived, Is.EqualTo(2));
        }

        [Test]
        public void TestPropertyChangedIsSetRightWithSameValueOnScore()
        {
            uut.Score = 1068;
            uut.Score = 1068;

            Assert.That(eventsreceived, Is.Not.EqualTo(2));
            Assert.That(eventsreceived, Is.EqualTo(1));
        }

        [Test]
        public void TestPropertyChangedIsSetOnOptions()
        {
            uut.Options = new List<Option>();

            Assert.That(eventsreceived, Is.EqualTo(1));
        }

        [Test]
        public void TestPropertyChangedIsSetRightWithSameValueOnOptions()
        {
            uut.Options = new List<Option>();
            uut.Options = new List<Option>();

            Assert.That(eventsreceived, Is.EqualTo(2));
        }

        // RandomizeOptionOrder isn't tested, due to its randomness


    }
}
