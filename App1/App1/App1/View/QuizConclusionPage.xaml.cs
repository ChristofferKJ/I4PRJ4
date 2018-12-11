using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Model;
using App1.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizConclusionPage : ContentPage
    {
        private QuizConclusionViewModel _viewModel;

        public QuizConclusionPage(Quiz completedQuiz, double totalScore)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _viewModel = new QuizConclusionViewModel(completedQuiz, totalScore);
            BindingContext = _viewModel;

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }


        async Task DismissPage()
        {
            await Navigation.PopAsync();
        }

        public void goback(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MainPage();
            Navigation.RemovePage(this);

        }

    }
}

