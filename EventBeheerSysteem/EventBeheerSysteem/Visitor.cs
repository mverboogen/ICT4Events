using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBeheerSysteem
{
    class Visitor
    {

        private int id;
        private string name;
        private string email;
        private int bookerID;
        private int reservationID;
        private Booker booker;
        private Reservation reservation;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
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


        public Visitor(int id, string name, string email, int bookerID, int reservationID)
        {
            ID = id;
            Name = name;
            Email = email;
            BookerID = bookerID;
            ReservationID = reservationID;
        }

        public Visitor(int id, string name, string email, Booker booker, Reservation reservation)
        {
            ID = id;
            Name = name;
            Email = email;
            this.booker = booker;
            this.reservation = reservation;
        }

    }
}
