﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OmOsPage : ContentPage
	{
		public OmOsPage ()
		{
			InitializeComponent ();
		}

        private async void ScrollViewTo(object sender, EventArgs e)
        {
            await scrollingfar.ScrollToAsync(10.0,600,true); 
            
        }
    }
}


