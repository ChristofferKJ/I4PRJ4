using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using App1.Annotations;
using Xamarin.Forms;
using App1.Services;
using MongoDB.Driver.Core.Operations;
using Plugin.Connectivity;

namespace App1.ViewModel
{
    public class NewUserViewModel : INotifyPropertyChanged
    {
        ApiServices apiServices = new ApiServices();

        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        private string _message;

        public bool IsEverythingFilled()
        {
            if (Email == string.Empty || Username== string.Empty || Password == string.Empty || ConfirmPassword == string.Empty)
                return false;
            return true;
        }
        public string WhatIsNotFilled()
        {
            if (Email == string.Empty)
                return  "Feltet email er ikke udfyldt";
            else if (Username == "")
                return "Feltet brugernavn er ikke udfyldt";
            else if (Password == string.Empty)
                return "Feltet password er ikke udfyldt";
            else if (ConfirmPassword == string.Empty)
                return "Feltet bekræft password er ikke udfyldt";
            else
                return string.Empty;
        }

        public string Message
        {
            get { return _message;}
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }
        public ICommand NewUserCommand
        {
            get
            {
                return new Command(async() =>
                {
                    var isConnected = CrossConnectivity.Current.IsConnected;
                    if (!isConnected)
                    {
                        Message = "Kan ikke oprette forbindelse";
                    }
                    else if (Password != ConfirmPassword)
                    {
                        Message = "password og bekræft password er ikke ens";
                    }
                    else if (!IsEverythingFilled())
                    {
                        Message = WhatIsNotFilled();
                    }
                    else
                    {
                        var isSuccessful = await apiServices.RegisterAsync(Username, Email, Password, ConfirmPassword);
                        Message = isSuccessful
                            ? "Bruger oprettet"
                            : "Der opstod en fejl under oprettelse af bruger, prøv igen";
                    }

                    if (Message == "Bruger oprettet")
                    {
                        
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
