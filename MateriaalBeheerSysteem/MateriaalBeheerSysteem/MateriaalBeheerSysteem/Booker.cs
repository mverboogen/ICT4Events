using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateriaalBeheerSysteem
{
    public class Booker : Visitor
    {
        private string address;
        private string zipcode;
        private string city;

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

        public Booker(int id, string surname, string lastname, string email, int bookerID, int reservationID, string address, string zipcode, string city)
            :base(id, surname, lastname, email, bookerID, reservationID)
        {
            Address = address;
            Zipcode = zipcode;
            City = city;
        }
    }
}
