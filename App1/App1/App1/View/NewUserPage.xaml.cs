﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.ViewModel;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewUserPage : ContentPage
	{
		public NewUserPage ()
		{
			InitializeComponent ();
        }

        private async void GoBack_Clicked(object sender, EventArgs e)
	    {
	        await Navigation.PopModalAsync(); 
	    }
    }
}