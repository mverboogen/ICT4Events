using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReserveringSysteem
{

    public class Account
    {
        private string username;
        private string email;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public Account(string username, string email)
        {
            this.username = username;
            this.email = email;
        }
    }
}