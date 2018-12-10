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
    class DeleteUserViewModel
    {
            public ICommand DeleteUserCommand
            {
                get
                {
                    return new Command(() =>
                    {
                        var isConnected = CrossConnectivity.Current.IsConnected;

                        if (!isConnected)
                        {
                            Response = "Kan ikke oprette forbindelse";

                        }


                        var isUserDeleted = _apiServices.DeleteUser();
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
