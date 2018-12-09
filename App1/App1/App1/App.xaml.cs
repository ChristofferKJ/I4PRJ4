using System;
using App1.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            setMainPage();
        }

        private void setMainPage()
        {
            if (!string.IsNullOrEmpty(Settings.AccessToken))
            {
               MainPage = new MainPage();
            }
            else if (!string.IsNullOrEmpty(Settings.Password)
            && !string.IsNullOrEmpty(Settings.Username))
            {
                MainPage = new LoginFormPage();
            }
            else
            {
                MainPage = new LoginPage();
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
