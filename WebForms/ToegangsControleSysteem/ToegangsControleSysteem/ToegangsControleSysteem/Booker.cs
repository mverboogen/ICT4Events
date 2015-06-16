using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToegangsControleSysteem
{
    public class Booker
    {
        private int id;
        private string firstname;
        private string inlas;
        private string surname;
        private string street;
        private int number;
        private string city;
        private string bankaccount;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public string Inlas
        {
            get { return inlas; }
            set { inlas = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Name
        {
            get { return inlas != null ? inlas + " " : "" + surname + ", " + firstname.Substring(0, 1); }
        }

        public string Street
        {
            get { return street; }
            set { street = value; }
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string BankAccount
        {
            get { return bankaccount; }
            set { bankaccount = value; }
        }
    }
}