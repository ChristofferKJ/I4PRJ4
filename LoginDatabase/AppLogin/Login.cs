using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login;
using Infrastruktur;

namespace Login
{
    public class Login
    {
        public bool NewUser(string Username, string Password)
        {
            User user = new User(Username, Password);
            if (DoesUserExsist(user))
                return false;

            LoginDBUtil AddNewUser = new LoginDBUtil();
            AddNewUser.AddUserDB(ref user);
            return true;
        }
        public bool AppLogin(string Username, string Password)
        {
            User user = new User(Username, Password);
            User TestUser = new User(Username, "");
            LoginDBUtil login = new LoginDBUtil();
            login.GetUserByUsername(ref TestUser);
            if (TestUser.Password == user.Password)
                return true;
            else
                return false;
        }
        public bool DoesUserExsist(User user)
        {
            User TestUser = user;
            LoginDBUtil does_user_exsist = new LoginDBUtil();
            does_user_exsist.GetUserByUsername(ref TestUser);
            if (TestUser.UserID != -1)
            {
                return true;
            }
            return false;
        }
    }
}
    