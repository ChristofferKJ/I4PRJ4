using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Model;
using App1.Services;
using App1.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HiscoreWindow : ContentPage
	{
		public HiscoreWindow ()
		{
			InitializeComponent ();
		    this.BindingContext = new UserViewModel(); 
		}
	  
	}
}