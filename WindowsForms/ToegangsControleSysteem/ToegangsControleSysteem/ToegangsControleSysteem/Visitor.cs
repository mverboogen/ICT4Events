using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToegangsControleSysteem
{
    public class Visitor : IComparable<Visitor>
    {

        protected int id;
        protected string surname;
        protected string lastname;
        private string email;
        private string rfid;
        private int bookerID;
        private int reservationID;
        private Booker booker;
        private Reservation reservation;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public int BookerID
        {
            get { return bookerID; }
            set { bookerID = value; }
        }

        public int ReservationID
        {
            get { return reservationID; }
            set { reservationID = value; }
        }

        public Booker VisitorBooker
        {
            get { return booker; }
            set { booker = value; }
        }

        public Reservation VisitorReservation
        {
            get { return reservation; }
            set { reservation = value; }
        }

        public string RFID
        {
            get { return rfid; }
            set { rfid = value; }
        }

        public Visitor(int id, string surname, string lastname, string email, int bookerID, int reservationID, string rfid)
        {
            ID = id;
            Surname = surname;
            Lastname = lastname;
            Email = email;
            BookerID = bookerID;
            RFID = rfid;
            ReservationID = reservationID;
        }

        public Visitor(int id, string surname, string lastname, string email, Booker booker, Reservation reservation)
        {
            ID = id;
            Surname = surname;
            Lastname = lastname;
            Email = email;
            this.booker = booker;
            this.reservation = reservation;
        }

        public override string ToString()
        {
            return Surname + " " + Lastname;
        }

        public int CompareTo(Visitor visitor)
        {
            return id.CompareTo(visitor.ID);
        }
    }
}
