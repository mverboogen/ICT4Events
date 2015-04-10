using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaSharingSystem
{
    class User
    {
        private String userName;
        private String password;

        public String Username
        {
            get { return userName; }
            set { userName = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        public User(String username, String password)
        {
            userName = username;
            this.password = password;
        }


    }
}
