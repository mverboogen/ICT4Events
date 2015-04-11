using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaSharingSystem
{
    class User
    {
        private readonly int userID;
        private String userName;
        private String password;

        public int ID
        {
            get { return this.userID; }
        }

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

        public User(int id, String username, String password)
        {
            this.userID = id;
            userName = username;
            this.password = password;
        }


    }
}
