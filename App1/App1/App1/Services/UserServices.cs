using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App1.Model;
using Xamarin.Forms;

namespace App1.Services
{
    public class UserServices
    {
        public UserServices()
        {

        }
<<<<<<< HEAD
=======

>>>>>>> e1c3120525ef6e3140224b2b0fde56e36ac4303d
        public List<User> GetUsers()
        {
            var list = new List<User>
            {
                new User
                {
                    Username = "Bruger1",
                    UserHiscore = 9999999
                },

                new User
                {
                    Username = "Bruger2",
                    UserHiscore = 999999

                },
                new User
                {
                    Username = "Bruger3",
                    UserHiscore = 99999
                },
                new User
                {
                    Username = "Bruger4",
                    UserHiscore = 9999
                }
            };

            List<User> sortedlist = list.OrderByDescending(o => o.UserHiscore).ToList();

            list = sortedlist;

            return list;
        }


    }
}
