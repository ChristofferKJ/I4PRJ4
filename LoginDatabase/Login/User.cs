using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace Login
    {
        public class User
        {
            public virtual int UserID { get; set; }
            public virtual string Username { get; set; }
            public virtual string Password { get; set; }

            public User(string _username, string _password)
            {
            Username = _username;
            Password = _password;
            UserID = -1;
            }
        }
    }

