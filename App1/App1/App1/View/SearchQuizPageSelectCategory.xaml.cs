using System;
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
	public partial class SearchQuizPageSelectCategory : ContentPage
	{
	    private SearchQuizViewModel viewModel_;

		public SearchQuizPageSelectCategory(SearchQuizViewModel viewModel = null)
		{
			InitializeComponent ();
		    NavigationPage.SetHasNavigationBar(this, false);
            viewModel_ = viewModel;
            if(viewModel_ == null)
		        viewModel_ = new SearchQuizViewModel("Vælg Kategori", new QuizDBServices());

		    BindingContext = viewModel_;
		    viewModel_.IsBusy = false;

            viewModel_.LoadCategories();

		    LViewCategories.ItemSelected += listCategorySelected;
		    LViewCategories.ItemTapped += (sender, args) => LViewCategories.SelectedItem = null;

        }

	     SearchQuizPageSelectCategory() // need for designer view, not used in app
	    {
	        InitializeComponent();
 
	    }

        protected async void listCategorySelected(object sender, SelectedItemChangedEventArgs e)
	    {
	        var selCategory = e.SelectedItem as string;

	        if (selCategory == null)
	            return;

	        Application.Current.MainPage = new SearchQuizPageSelectQuiz(viewModel_, selCategory);
            //await Navigation.PushAsync(new SearchQuizPageSelectQuiz(viewModel_, selCategory));
        }
	}
}