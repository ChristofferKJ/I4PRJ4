using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using App1.Annotations;
using Xamarin.Forms;
using App1.Services;

namespace App1.ViewModel
{
    public class NewUserViewModel : INotifyPropertyChanged
    {
        ApiServices apiServices = new ApiServices();

        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        private string _message;


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
                    var isSuccessful = await apiServices.RegisterAsync(Username, Email, Password, ConfirmPassword);

                    Message = isSuccessful ? "Bruger oprettet" : "Der opstod en fejl under oprettelse af bruger, prøv igen";
                    
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
