using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using App1; 

namespace App1.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public Action LoginSuccess; 
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this,new PropertyChangedEventArgs("Password"));
            }
        }

        public ICommand SubmitCommand { get; set; }

        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }

        public void OnSubmit()
        {
            LoginSuccess(); 
        }
    }
}
