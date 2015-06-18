using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReserveringSysteem
{
    public class Person
    {
        private string firstname;
        private string insertion;
        private string lastname;
        private string street;
        private string adress;
        private string city;
        private string bank;

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public string Insertion
        {
            get { return insertion; }
            set { insertion = value; }
        }

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public string Street
        {
            get { return street; }
            set { street = value; }
        }

        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string Bank
        {
            get { return bank; }
            set { bank = value; }
        }

        public Person(string firstname, string insertion, string lastname, string street, string adress, string city, string bank)
        {
            this.firstname = firstname;
            this.insertion = insertion;
            this.lastname = lastname;
            this.street = street;
            this.adress = adress;
            this.city = city;
            this.bank = bank;
        }
    }
}