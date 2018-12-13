using System;
using System.Collections.Generic;
using System.IO;
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
	public partial class ChangeLoginView : PopupPage
	{
		public ChangeLoginView ()
		{
			InitializeComponent ();
		}

	    private void NewPassword_onClicked(object sender, EventArgs e)
	    {
	        PopupNavigation.Instance.PopAsync();
	    }
	}
}