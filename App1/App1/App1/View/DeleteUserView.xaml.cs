using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DeleteUserView : PopupPage
	{
		public DeleteUserView ()
		{
			InitializeComponent ();
		}

	    private void cancel(object sender, EventArgs e)
	    {
	        PopupNavigation.Instance.PopAsync();

	    }

	    private void DeleteUser_OnClicked(object sender, EventArgs e)
	    {
	        PopupNavigation.Instance.PopAsync();
            Application.Current.MainPage = new LoginPage();
	    }
	}
}