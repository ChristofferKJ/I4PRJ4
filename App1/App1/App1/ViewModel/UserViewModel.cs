using System;
using System.Collections.Generic;
using System.Text;
using App1.Model;
using App1.Services;

namespace App1.ViewModel
{
    public class UserViewModel : UserViewModelBase
    {
        public UserViewModel()
        {
            var service = new UserServices();
            UserList = service.GetUsers();
        }

        private List<User> userList;

        public List<User> UserList
        {
            get { return userList;}
            set { SetProperty(ref userList, value); }
        }


    }
}
