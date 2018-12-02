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

            _viewModel = new QuizViewModel(quiz);
	      

	        BindingContext = _viewModel;
	    }

	    public  QuizPageDemo()
	    {
	        InitializeComponent();
        }

	    protected override void OnDisappearing()
	    {
	        base.OnDisappearing();

	    }


	    async Task DismissPage()
	    {
	       await Navigation.PopAsync();
	    }
    }


}