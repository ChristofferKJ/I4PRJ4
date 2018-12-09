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
        public int fontSizeforUser { get; set; }


        public User() {}

        public int calculateFontSize()
        {
            
            int newsize = 10;
            int score = 0; 
            UserHiscore = score;
            if (score > 10000)
                newsize = 15;
            if (score > 100000)
                newsize = 20; 

                return newsize;

        }

        public User(string _username, string _password)
        {
            Username = _username;
            Password = _password;
            UserHiscore = 0;
            UserID = -1;
            fontSizeforUser = 0;
            calculateFontSize(); 
        }
        
    }
}
