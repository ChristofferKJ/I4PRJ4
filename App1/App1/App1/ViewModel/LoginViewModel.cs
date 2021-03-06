﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using App1;
using App1.Annotations;
using App1.Helpers;
using App1.Services;
using Plugin.Connectivity;

namespace App1.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        public LoginViewModel()
        {
            Username = Settings.Username;
            Password = Settings.Password;
        }
        private readonly ApiServices _apiServices = new ApiServices();
        public string Username { get; set; }

        public string Password { get; set; }

        public string LoginResponse
        {
            get { return _loginResponse;}
            set
            {
                _loginResponse = value;
                OnPropertyChanged();
            } }
        private string _loginResponse;
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
                    else if (!IsEverythingFilled())
                    {
                        LoginResponse = WhatIsNotFilled();
                    }
                    else
                    {
                        var accesstoken = await _apiServices.LoginAsync(Username, Password);
                        Settings.AccessToken = accesstoken;

                        LoginResponse = !string.IsNullOrEmpty(accesstoken) ? "Login succes" : "Fejl i brugernavn eller kodeord";
                    }

                    if (LoginResponse == "Login succes")
                    {
                        Application.Current.MainPage = new NavigationPage(new MainPage());
                    }

                    
                });
            }
        }

        public bool IsEverythingFilled()
        {
            if (Username == string.Empty || Password == string.Empty)
                return false;
            return true;
        }
        public string WhatIsNotFilled()
        {
            if (Username == "") 
                return "Feltet brugernavn er ikke udfyldt";
            else if (Password == string.Empty)
                return "Feltet password er ikke udfyldt";
            else
                return string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
