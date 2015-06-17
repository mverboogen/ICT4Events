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
        private string hash;
        private string password;

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

        public string Hash
        {
            get { return hash; }
            set { hash = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public Account(string username, string email, string password)
        {
            this.username = username;
            this.email = email;
            this.password = password;
        }
    }
}