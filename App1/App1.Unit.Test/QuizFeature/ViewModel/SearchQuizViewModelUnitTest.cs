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
    class SearchQuizViewModelUnitTest
    {
        private SearchQuizViewModel uut_;
        private IQuizDBService fakeService_;
        private int eventsReceived;

        [SetUp]
        public void Setup()
        {
            fakeService_ = Substitute.For<IQuizDBService>();
            uut_ = new SearchQuizViewModel("",fakeService_);
            eventsReceived = 0;
        }

        [Test]
        public void CategoriesSetToNewList_PropertyChangedInvoked()
        {
            List<string> testCategoryList = new List<string>(){"category1", "category2", "category3" };
           
            uut_.PropertyChanged += (o, arg) => { eventsReceived++; };

            uut_.Categories = testCategoryList;

            Assert.That(eventsReceived, Is.EqualTo(1));

        }

        [Test]
        public void CategoriesSetToSameList_PropertyChangedNotInvoked()
        {

            List<string> testCategoryList = new List<string>() { "category1", "category2", "category3" };
            uut_.PropertyChanged += (o, arg) => { eventsReceived++; };

            uut_.Categories = testCategoryList;
            uut_.Categories = testCategoryList;

            Assert.That(eventsReceived, Is.EqualTo(1));
        }

        [Test]
        public void QuizzsesSetToNewList_PropertyChangedInvoked()
        {
            
            List<Quiz> testQuizList = new List<Quiz>() { new Quiz(), new Quiz(), new Quiz() };

            uut_.PropertyChanged += (o, arg) => { eventsReceived++; };

            uut_.Quizzes = testQuizList;

            Assert.That(eventsReceived, Is.EqualTo(1));

        }

        [Test]
        public void QuizzesSetToSameList_PropertyChangedNotInvoked()
        {
            
            List<Quiz> testQuizList = new List<Quiz>() { new Quiz(), new Quiz(), new Quiz() };

            uut_.PropertyChanged += (o, arg) => { eventsReceived++; };

            uut_.Quizzes = testQuizList;
            uut_.Quizzes = testQuizList;

            Assert.That(eventsReceived, Is.EqualTo(1));
        }

        [Test]
        public void LoadCategoriesCalled_CategoriesPropertyChangedCalled()
        {

            //Arrange:
            Quiz quiz1 = new Quiz();
            quiz1.Category = "Category 1";
            Quiz quiz2 = new Quiz();
            quiz2.Category = "Category 2";
            Quiz quiz3 = new Quiz();
            quiz3.Category = "Category 3";
            Quiz quiz4 = new Quiz();
            quiz4.Category = "Category 4";
            Quiz quiz5 = new Quiz();
            quiz5.Category = "Category 5";

            List<Quiz> fakedQuizList = new List<Quiz>() {quiz1, quiz2, quiz3, quiz4, quiz5};

            uut_.PropertyChanged += (o, arg) => { eventsReceived++; };

            fakeService_.GetAllQuizzesAsync().ReturnsForAnyArgs(fakedQuizList);

            //Act:
            uut_.LoadCategories();


            //Assert:
            Assert.That(eventsReceived, Is.EqualTo(1));
        }

        [Test]
        public void LoadCategories_OnlyUniqueCategoriesLoaded()
        {

            // Arrange:
            Quiz quiz1 = new Quiz(); quiz1.Category = "Category 1";
            Quiz quiz2 = new Quiz(); quiz2.Category = "Category 1";
            Quiz quiz3 = new Quiz(); quiz3.Category = "Category 2";
            Quiz quiz4 = new Quiz(); quiz4.Category = "Category 2";
            Quiz quiz5 = new Quiz(); quiz5.Category = "Category 3";
            Quiz quiz6 = new Quiz(); quiz6.Category = "Category 3";

            List<Quiz> fakedQuizList = new List<Quiz>() { quiz1, quiz2, quiz3, quiz4, quiz5, quiz6 };

            fakeService_.GetAllQuizzesAsync().ReturnsForAnyArgs(fakedQuizList);

            //Act
            uut_.LoadCategories();

            bool onlyUniqueCategories = (uut_.Categories.Distinct().Count() == uut_.Categories.Count);

            //Assert
            Assert.That(onlyUniqueCategories, Is.EqualTo(true));

        }

        [Test]
        public void LoadQuizzesFromCategoryCalled_CategoriesPropertyChangedCalled()
        {

            //Arrange:
            Quiz quiz1 = new Quiz(); quiz1.Category = "Test Category";
            Quiz quiz2 = new Quiz(); quiz2.Category = "Test Category";
            Quiz quiz3 = new Quiz(); quiz3.Category = "Test Category";
            Quiz quiz4 = new Quiz(); quiz4.Category = "Test Category";
            Quiz quiz5 = new Quiz(); quiz5.Category = "Test Category";

            List<Quiz> fakedQuizList = new List<Quiz>() { quiz1, quiz2, quiz3, quiz4, quiz5 };

            uut_.PropertyChanged += (o, arg) => { eventsReceived++; };

            fakeService_.GetAllQuizzesAsync().ReturnsForAnyArgs(fakedQuizList);

            //Act:
            uut_.LoadQuizzesFromCategory("Test Category");

            //Assert:
            Assert.That(eventsReceived, Is.EqualTo(1));
        }

    }
}

