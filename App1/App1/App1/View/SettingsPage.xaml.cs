using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.View;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage ()
		{
			InitializeComponent ();
		}
         
        private void Button_OnClicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new ChangeLoginView());
             
        }

	    private void ResetHighscore(object sender, EventArgs e)
	    {
	        PopupNavigation.Instance.PushAsync(new ResetHighscoreView());
	    }

	    private void Delete_OnClicked(object sender, EventArgs e)
	    {
	        PopupNavigation.Instance.PushAsync(new DeleteUserView());
	    }
	}
}