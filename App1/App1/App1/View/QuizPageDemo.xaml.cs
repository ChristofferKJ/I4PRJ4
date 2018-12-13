using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.Model;
using App1.Services;
using App1.ViewModel;

namespace App1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizPageDemo : ContentPage
    {

        QuizViewModel _viewModel;

        public QuizPageDemo(Quiz quiz)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _viewModel = new QuizViewModel(quiz);
            _viewModel.QuizCompleted += OnQuizCompleted;
            BindingContext = _viewModel;

        }

        public QuizPageDemo()
        {
            InitializeComponent();
        }

        async void OnQuizCompleted(object sender, EventArgs e)
        {
            Application.Current.MainPage = new QuizConclusionPage(_viewModel.TheQuiz, _viewModel.TotalScore);
            // await Navigation.PushModalAsync(new QuizConclusionPage(_viewModel.TheQuiz, _viewModel.TotalScore));
        }

        

    }
}