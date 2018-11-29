using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.Model;
using App1.Services;
using App1.ViewModel;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizPage : ContentPage
    {
        bool _isNew;
        QuizViewModel _viewModel;

        public QuizPage(Quiz quiz, bool isNew)
        {
            InitializeComponent();

            _isNew = isNew;

            _viewModel = new QuizViewModel(quiz);
            _viewModel.SaveComplete += Handle_SaveComplete;

            BindingContext = _viewModel;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            _viewModel.SaveComplete -= Handle_SaveComplete;
        }

        async void Handle_SaveComplete(object sender, EventArgs eventArgs)
        {
            await DismissPage();
        }

        protected async void Handle_CancelClicked(object sender, EventArgs e)
        {
            await DismissPage();
        }

        async Task DismissPage()
        {
            if (_isNew)
                await Navigation.PopModalAsync();
            else
                await Navigation.PopAsync();
        }


    }
}