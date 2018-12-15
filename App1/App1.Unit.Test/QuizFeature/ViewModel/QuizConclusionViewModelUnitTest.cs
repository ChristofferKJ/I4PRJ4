using System
    ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using App1.Model;
using App1.Services;
using App1.ViewModel;
using NSubstitute;
using NUnit.Framework;

namespace App1.Unit.Test.QuizFeature.ViewModel
{
    [TestFixture]
    class QuizConclusionViewModelUnitTest
    {
        private QuizConclusionViewModel uut_;
        private IAPIService fakeService_;
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

            List<Question> testQuestions = new List<Question>() { question1, question2 };

            quiz.Question = testQuestions;

            #endregion


            fakeService_ = Substitute.For<IAPIService>();
            uut_ = new QuizConclusionViewModel(quiz, 0,fakeService_);
            eventsReceived = 0;
        }


        [Test]
        public void CompletedQuizSetToNewQuiz_PropertyChangedInvoked()
        {
            Quiz newQuiz = new Quiz();

            uut_.PropertyChanged += (o, arg) => { eventsReceived++; };

            uut_.CompletedQuiz = newQuiz;

            Assert.That(eventsReceived, Is.EqualTo(1));

        }

        [Test]
        public void CompletedQuizSetToSameQuiz_PropertyChangedNotInvoked()
        {

            Quiz newQuiz = new Quiz();

            uut_.PropertyChanged += (o, arg) => { eventsReceived++; };

            uut_.CompletedQuiz = newQuiz;
            uut_.CompletedQuiz = newQuiz;

            Assert.That(eventsReceived, Is.EqualTo(1));
        }

        [Test]
        public void TotalScoreSetToNewValue_PropertyChangedInvoked()
        {

            uut_.PropertyChanged += (o, arg) => { eventsReceived++; };

            uut_.TotalScore = 10000;

            Assert.That(eventsReceived, Is.EqualTo(1));

        }

        [Test]
        public void TotalScoreSetToSameValue_PropertyChangedNotInvoked()
        {

           
            uut_.PropertyChanged += (o, arg) => { eventsReceived++; };

            uut_.TotalScore = 10000;
            uut_.TotalScore = 10000;

            Assert.That(eventsReceived, Is.EqualTo(1));
        }

        [Test]
        public void ScoreLabelSetToNewString_PropertyChangedInvoked()
        {

            string testLabel = "TestLabel";

            uut_.PropertyChanged += (o, arg) => { eventsReceived++; };

            uut_.ScoreLabel = testLabel;

            Assert.That(eventsReceived, Is.EqualTo(1));

        }

        [Test]
        public void ScoreLabelSetToSameString_PropertyChangedNotInvoked()
        {

            string testLabel = "TestLabel";

            uut_.PropertyChanged += (o, arg) => { eventsReceived++; };

            uut_.ScoreLabel = testLabel;
            uut_.ScoreLabel = testLabel;

            Assert.That(eventsReceived, Is.EqualTo(1));
        }

        [Test]
        public void QuizDescriptionSetToNewString_PropertyChangedInvoked()
        {

            string testDescription = "TestDescription";

            uut_.PropertyChanged += (o, arg) => { eventsReceived++; };

            uut_.QuizDescription = testDescription;

            Assert.That(eventsReceived, Is.EqualTo(1));

        }

        [Test]
        public void QuizDescriptionSetToSameString_PropertyChangedNotInvoked()
        {

            string testDescription = "TestDescription";

            uut_.PropertyChanged += (o, arg) => { eventsReceived++; };

            uut_.QuizDescription = testDescription;
            uut_.QuizDescription = testDescription;

            Assert.That(eventsReceived, Is.EqualTo(1));
        }

        [Test]
        public void HighScoreUpdatedDescriptionSetToNewString_PropertyChangedInvoked()
        {

            string testDescription = "TestDescription";

            uut_.PropertyChanged += (o, arg) => { eventsReceived++; };

            uut_.HighScoreUpdatedDescription = testDescription;

            Assert.That(eventsReceived, Is.EqualTo(1));

        }

        [Test]
        public void HighScoreUpdatedDescriptionSetToSameString_PropertyChangedNotInvoked()
        {

            string testDescription = "TestDescription";

            uut_.PropertyChanged += (o, arg) => { eventsReceived++; };

            uut_.HighScoreUpdatedDescription = testDescription;
            uut_.HighScoreUpdatedDescription = testDescription;

            Assert.That(eventsReceived, Is.EqualTo(1));
        }

        [Test]
        public void updateHighScore_TotalScoreGreaterThanHighScore_HighScoreDescriptionUpdated()
        {
            CategoryScoreModel testModel = new CategoryScoreModel();
            testModel.Category = uut_.CompletedQuiz.Category;
            testModel.HighScore = 0;
            List<CategoryScoreModel> testList = new List<CategoryScoreModel>(){testModel};

            uut_.TotalScore = 1000;

          string comparisonString = $"Tillykke du har slået din egen highscore for {uut_.CompletedQuiz.Category} på {testModel.HighScore}";
            fakeService_.GetHighScoreForCurrentUser().ReturnsForAnyArgs(testList);

            uut_.updateHighScore();

            Assert.That(uut_.HighScoreUpdatedDescription, Is.EqualTo(comparisonString));

        }

        [Test]
        public void updateHighScore_TotalScoreLesserThanHighScore_HighScoreDescriptionUpdated()
        {
            CategoryScoreModel testModel = new CategoryScoreModel();
            testModel.Category = uut_.CompletedQuiz.Category;
            testModel.HighScore = 1000;
            List<CategoryScoreModel> testList = new List<CategoryScoreModel>() { testModel };

            uut_.TotalScore = 100;

            fakeService_.GetHighScoreForCurrentUser().ReturnsForAnyArgs(testList);

            uut_.updateHighScore();

            Assert.That(uut_.HighScoreUpdatedDescription, Is.EqualTo(""));

        }

        [Test]
        public void updateHighScore_TotalScoreEqualsHighScore_HighScoreDescriptionUpdated()
        {
            CategoryScoreModel testModel = new CategoryScoreModel();
            testModel.Category = uut_.CompletedQuiz.Category;
            testModel.HighScore = 1000;
            List<CategoryScoreModel> testList = new List<CategoryScoreModel>() { testModel };

            uut_.TotalScore = 1000;

            fakeService_.GetHighScoreForCurrentUser().ReturnsForAnyArgs(testList);



            uut_.updateHighScore();

            Assert.That(uut_.HighScoreUpdatedDescription, Is.EqualTo(""));

        }

    }
}

