using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Model
{
    public class User
    {
        public int UserHiscore { get; set; }
        public virtual int UserID { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }

        public User() {}
        public User(string _username, string _password)
        {
            Username = _username;
            Password = _password;
            UserHiscore = 0;
            UserID = -1;
        }
        
    }
}
