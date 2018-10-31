using System;
using System.Collections.Generic;
using System.Text;
using App1.Model;
using App1.ViewModel;


namespace App1.ViewModel
{
    class AppLoginViewModel
        {
            public bool NewUser(string Username, string Password)
            {
                User user = new User(Username, Password);
                if (DoesUserExsist(user))
                    return false;

                LoginDBUtilitiesViewModel AddNewUser = new LoginDBUtilitiesViewModel();
                AddNewUser.AddUserDB(ref user);
                return true;
            }
            public bool AppLogin(string Username, string Password)
            {
                User user = new User(Username, Password);
                User TestUser = new User(Username, "");
                LoginDBUtilitiesViewModel login = new LoginDBUtilitiesViewModel();
                login.GetUserByUsername(ref TestUser);
                if (TestUser.Password == user.Password)
                    return true;
                else
                    return false;
            }
            public bool DoesUserExsist(User user)
            {
                User TestUser = user;
                LoginDBUtilitiesViewModel does_user_exsist = new LoginDBUtilitiesViewModel();
                does_user_exsist.GetUserByUsername(ref TestUser);
                if (TestUser.UserID != -1)
                {
                    return true;
                }
                return false;
            }
        }
    }

