using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using App1;
using App1.Annotations;
using App1.Services;
using Plugin.Connectivity;

namespace App1.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        private readonly ApiServices _apiServices = new ApiServices();
        public string Username { get; set; }
        public string Password { get; set; }
        public string LoginResponse
        {
            get { return _LoginResponse;}
            set
            {
                _LoginResponse = value;
                OnPropertyChanged();
            } }
        private string _LoginResponse;
        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var isConnected = CrossConnectivity.Current.IsConnected;
                    if (!isConnected)
                    {
                        LoginResponse = "Kan ikke oprette forbindelse";

                    }
                    else
                    {
                        var response = await _apiServices.LoginAsync(Username, Password);
                        switch (response.StatusCode)
                        {
                            case HttpStatusCode.OK:
                            {
                                LoginResponse = "Login succes";
                                break;
                            }
                            default:
                                LoginResponse = "Fejl i brugernavn eller kodeord";
                                break;
                        }
                    }
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
