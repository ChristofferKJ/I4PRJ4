using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using App1;
using App1.Services;

namespace App1.ViewModel
{
    class LoginViewModel //: INotifyPropertyChanged
    {
        private ApiServices apiServices = new ApiServices();
        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await apiServices.LoginAsync(Username, Password);
                });
            }
        }
    }
}
