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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
           
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginFormPage(), true);

        }

        private async void Opret_Bruger_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NewUserPage(), true);
        }

    }
}