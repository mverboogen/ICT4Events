using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveringSysteem
{
    class Booker
    {
        private string name;
        private string lastname;
        private string address;
        private string zipcode;
        private string city;
        private string email;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Zipcode
        {
            get { return zipcode; }
            set { zipcode = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }
        
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public Booker(string name, string lastname, string address, string zipcode, string city, string email)
        {
            this.name = name;
            this.lastname = lastname;
            this.address = address;
            this.zipcode = zipcode;
            this.city = city;
            this.email = email;
        }
    }
}
