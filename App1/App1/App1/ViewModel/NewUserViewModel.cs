using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using App1.Services;

namespace App1.ViewModel
{
    public class NewUserViewModel
    {
        ApiServices apiServices = new ApiServices();

        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string Message { get; set; }
        public ICommand NewUserCommand
        {
            get
            {
                return new Command(async() =>
                {
                    var IsSuccess = await apiServices.RegisterAsync(Username, Email, Password, ConfirmPassword);

                    if (IsSuccess)
                        Message = "New user created";
                    else
                        Message = "Failed to create new user, please retry later";
                        
                });
            }
        }
    }
}
