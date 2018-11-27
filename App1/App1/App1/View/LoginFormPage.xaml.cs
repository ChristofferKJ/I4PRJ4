using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.ViewModel;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class LoginFormPage : ContentPage
	{
		public LoginFormPage()
		{
            InitializeComponent();

            Username_Entry.Completed += (object sender, EventArgs e) =>
            {
                Password_Entry.Focus();
            };
        }


	    private void ShowPass_OnTapped(object sender, EventArgs e)
	    {
	        Password_Entry.IsPassword = Password_Entry.IsPassword ? false : true; 
	    }


	    private async void CreateUser_Clicked(object sender, EventArgs e)
	    {
	        await Navigation.PushModalAsync(new NewUserPage()); 
	    }

	    
	}
}