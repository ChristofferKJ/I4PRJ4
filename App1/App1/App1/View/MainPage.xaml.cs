using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Model;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }


        private async void Hiscore_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HiscoreWindow());
        }

        private async void Quiz_Clicked(object sender, EventArgs e)
        {
            var myQuiz = new Quiz();
            var QuizPage = new QuizPage(myQuiz, true);
            await Navigation.PushModalAsync(new NavigationPage(QuizPage));
        }

        private async void Spil_OnTapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SpilPage());

        }
    }
}
