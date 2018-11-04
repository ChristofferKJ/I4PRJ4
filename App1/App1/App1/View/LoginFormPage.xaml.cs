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
		public LoginFormPage ()
		{
            var vm = new LoginViewModel();
            this.BindingContext = vm;
            vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Fejl!", "Forkert logind, prøv igen", "OK");
            vm.LoginSuccess += () => Navigation.PushModalAsync(new MainPage()); 

            InitializeComponent();

            Username_Entry.Completed += (object sender, EventArgs e) =>
            {
                Password_Entry.Focus();
            };

            Password_Entry.Completed += (object sender, EventArgs e) =>
            {
                vm.SubmitCommand.Execute(null);
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