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
       
	    public QuizPageDemo()
	    {
	        InitializeComponent();

            _viewModel = new QuizViewModel();
	       

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
    }


}