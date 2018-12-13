using System
    ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using App1.Model;
using App1.ViewModel;
using NUnit.Framework;

namespace App1.Unit.Test.QuizFeature.ViewModel
{
    [TestFixture]
    class QuizViewModelUnitTest
    {
        private QuizViewModel uut_;
        private int eventsReceived;

        [SetUp]
        public void Setup()
        {
            Quiz quiz = new Quiz();

            #region setup test Quiz



            
            List<Option> testOptions = new List<Option>() { new Option(), new Option(), new Option(), new Option() };
            testOptions[0].IsRight = true; testOptions[0].OptionText = "Answer1";
            testOptions[1].IsRight = false; testOptions[1].OptionText = "Answer2";
            testOptions[2].IsRight = false; testOptions[2].OptionText = "Answer3";
            testOptions[3].IsRight = false; testOptions[3].OptionText = "Answer4";
            quiz.QuizName = "Test Quiz";

            Question question1 = new Question();
            question1.QuestionText = "Question1";
            Question question2 = new Question();
            question2.QuestionText = "Question2";
            question1.Options = testOptions; question1.Score = 100;
            question2.Options = testOptions; question2.Score = 100;

            List<Question> testQuestions = new List<Question>(){question1, question2};

           quiz.Question = testQuestions;

            #endregion

            uut_ = new QuizViewModel(quiz);
            eventsReceived = 0;
        }

        #region Ctor Tests

        [Test]
        public void Ctor_QuizSet()
        {
            Assert.That(uut_.TheQuiz.QuizName, Is.EqualTo("Test Quiz"));
        }

        [Test]
        public void Ctor_FirstQuestionSet()
        {
            Assert.That(uut_.TheQuestion.QuestionText, Is.EqualTo("Question1"));
        }

        [Test]
        public void Ctor_TotalScoreReset()
        {


            Assert.That(uut_.TotalScore, Is.EqualTo(0));
        }

        [Test]
        public void Ctor_TimeLeftReset()
        {


            Assert.That(uut_.TimeLeft, Is.EqualTo(1));
        }


        #endregion

        #region property Changed Test

        [Test]
        public void TheQuizUpdatedToNewQuestion_PropertyChangedInvoked()
        {
         
            Question newTestQuestion = new Question();
            uut_.PropertyChanged += (o, arg) => { eventsReceived++; };

            uut_.TheQuestion = newTestQuestion;

            Assert.That(eventsReceived, Is.EqualTo(1));

        }

        [Test]
        public void TheQuizUpdatedToSameQuestion_PropertyChangedNotInvoked()
        {

            Question newTestQuestion = new Question();
            uut_.PropertyChanged += (o, arg) => { eventsReceived++; };

            uut_.TheQuestion = newTestQuestion;
            uut_.TheQuestion = newTestQuestion;

            Assert.That(eventsReceived, Is.EqualTo(1));
        }

        [Test]
        public void TotalScoreUpdatedToNewValue_PropertyChangedInvoked()
        {

          
            uut_.PropertyChanged += (o, arg) => { eventsReceived++; };

            uut_.TotalScore = 1000;

            Assert.That(eventsReceived, Is.EqualTo(1));

        }

        [Test]
        public void TotalScoreUpdatedSameValue_PropertyChangedNotInvoked()
        {

           
            uut_.PropertyChanged += (o, arg) => { eventsReceived++; };

            uut_.TotalScore = 1000;
            uut_.TotalScore = 1000;

            Assert.That(eventsReceived, Is.EqualTo(1));
        }

        [Test]
        public void TimeLeftUpdatedToNewValue_PropertyChangedInvoked()
        {


            uut_.PropertyChanged += (o, arg) => { eventsReceived++; };

            uut_.TimeLeft = 0.8;

            Assert.That(eventsReceived, Is.EqualTo(1));

        }

        [Test]
        public void TimeLeftUpdatedSameValue_PropertyChangedNotInvoked()
        {


            uut_.PropertyChanged += (o, arg) => { eventsReceived++; };

            uut_.TimeLeft = 0.8;
            uut_.TimeLeft = 0.8;

            Assert.That(eventsReceived, Is.EqualTo(1));
        }



        #endregion

        #region AnswerCommand Tests

        //AnswerCommand false tests :

        [Test]
        public void WrongAnswerGivenScoreIsNotIncreased()
        {

            uut_.AnswerCommand.Execute(false);

            Assert.That(uut_.TotalScore, Is.LessThanOrEqualTo(0));

        }

        [Test]
        public void WrongAnswerGivenTheQuestionUpdated()
        {

            string firstQuestionText = "Question1";
            string secondQuestionText = "Question2";

            Assert.That(uut_.TheQuestion.QuestionText, Is.EqualTo(firstQuestionText));
            uut_.AnswerCommand.Execute(false);
            Assert.That(uut_.TheQuestion.QuestionText, Is.EqualTo(secondQuestionText));
        }


        [Test]
        public void WrongAnswerGivenLastQuestionQuizCompletedEventCalled()
        {

            uut_.QuizCompleted += (o, arg) => { ++eventsReceived; };

            Assert.That(uut_.TheQuestion.QuestionText, Is.EqualTo("Question1"));

            uut_.AnswerCommand.Execute(false);
            uut_.AnswerCommand.Execute(false);
            
            Assert.That(eventsReceived, Is.EqualTo(1));

        }

        //AnswerCommand false tests :

        [Test]
        public void RightAnswerGivenScoreIsIncreased()
        {

            uut_.AnswerCommand.Execute(true);

            Assert.That(uut_.TotalScore, Is.GreaterThan(0));

        }

        [Test]
        public void RightAnswerGivenTheQuestionUpdated()
        {

            Assert.That(uut_.TheQuestion.QuestionText, Is.EqualTo("Question1"));
            uut_.AnswerCommand.Execute(true);
            Assert.That(uut_.TheQuestion.QuestionText, Is.EqualTo("Question2"));
        }


        [Test]
        public void RightAnswerGivenLastQuestionQuizCompletedEventCalled()
        {

            uut_.QuizCompleted += (o, arg) => { ++eventsReceived; };

            Assert.That(uut_.TheQuestion.QuestionText, Is.EqualTo("Question1"));

            uut_.AnswerCommand.Execute(false);
            uut_.AnswerCommand.Execute(true);

            Assert.That(eventsReceived, Is.EqualTo(1));

        }
        
        #endregion




    }
}

