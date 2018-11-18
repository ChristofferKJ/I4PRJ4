using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Model;
using App1.Services;
using App1.View;
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

        
        private async void hiscore_OnTapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HiscoreWindow());
        }

        private async void quiz_OnTapped(object sender, EventArgs e)
        {
            var myQuiz = new Quiz();
            myQuiz.Question = "Er der hul igennem?";
            myQuiz.Option1 = "Måske";
            myQuiz.Category = "Quiz";
            var QuizPage = new QuizPageDemo(myQuiz);

            await Navigation.PushModalAsync(new NavigationPage(QuizPage));
        }

        private async void spil_OnTapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SpilPage());

        }
        private async void settings_OnTapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SpilPage());
        }
        private async void omos_OnTapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new OmOsPage());

        }


    }
}
