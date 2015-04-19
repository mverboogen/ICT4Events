using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaSharingSystem
{
    class UserData
    {
        private readonly int userID;
        private String userName;
        private String password;
        private bool isAdmin;

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

        public bool IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }

        public UserData(int id, String username, String password, bool isadmin)
        {
            this.userID = id;
            userName = username;
            this.password = password;
            isAdmin = isadmin;
        }


    }
}
