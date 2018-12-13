using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using App1.Helpers;
using App1.Model;
using App1.Services;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace App1.ViewModel
{
    class ChangePasswordViewModel
    {

        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string Response { get; set; }
        private readonly ApiServices _apiServices = new ApiServices();

        public ICommand ChangePaswordCommand
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

                    var isPasswordChanged = _apiServices.ChangePassword(OldPassword, NewPassword, ConfirmPassword);
                    Settings.Password = (ConfirmPassword == NewPassword) && (OldPassword == Settings.Password)
                        ? NewPassword
                        : Settings.Password;
                });
            }
        }
    }
}
