﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Model;
using App1.Services;
using App1.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchQuizPageSelectQuiz : ContentPage
	{
	    private SearchQuizViewModel viewModel_;

        public SearchQuizPageSelectQuiz(SearchQuizViewModel viewModel , string category =null)
	    {
	        InitializeComponent();
	        NavigationPage.SetHasNavigationBar(this, false);
            viewModel_ = viewModel;
	        if (viewModel_ == null)
	            viewModel_ = new SearchQuizViewModel("Vælg Quiz", new QuizDBServices());

	        BindingContext = viewModel_;

	        if (category != null)
	            viewModel_.LoadQuizzesFromCategory(category);

	        LViewQuizzes.ItemSelected += listQuizSelected;
	        LViewQuizzes.ItemTapped += (sender, args) => LViewQuizzes.SelectedItem = null;
        }

        public SearchQuizPageSelectQuiz ()
		{
			InitializeComponent ();
		}

	    protected async void listQuizSelected(object sender, SelectedItemChangedEventArgs e)
	    {
	        var selQuiz = e.SelectedItem as Quiz;

	        if (selQuiz == null)
	            return;

	        Application.Current.MainPage = new QuizPageDemo(selQuiz);
            //await Navigation.PushAsync(new QuizPageDemo(selQuiz));
        }
    }


}
