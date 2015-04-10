using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveringSysteem
{
    class Visitor
    {
        private string name;
        private string lastname;
        private string email;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public string Email
        {
            get { return email; }
            set { email= value;}
        }

        public Visitor(string name, string lastname, string email)
        {
            this.name = name;
            this.lastname = lastname;
            this.email = email;
        }

        public override string ToString()
        {
            return name + lastname + email;
        }
    }
}
