using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using App1.Helpers;
using App1.Services;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace App1.ViewModel
{
    class LogoutViewModel
    {
            public ICommand LogoutCommand
            {
                get
                {
                    return new Command(() =>
                    {
                        Settings.AccessToken = "";
                        Settings.Password = "";
                        Settings.Username = "";
                        Settings.AccessTokenExpirationDate = DateTime.UtcNow;
                        
                    });
                }
            }

            private readonly ApiServices _apiServices = new ApiServices();
            public string Response { get; set; }
        }
    }
    
