using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventBeheerSysteem
{
    public class User
    {
        private bool admin;
        private bool worker;

        public bool Admin
        {
            get { return admin; }
            set { admin = value; }
        }

        public bool Worker
        {
            get { return worker; }
            set { worker = value; }
        }
    }
}