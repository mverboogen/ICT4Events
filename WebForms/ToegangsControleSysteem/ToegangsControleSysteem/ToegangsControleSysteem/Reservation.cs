using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToegangsControleSysteem
{
    public class Reservation
    {
        private int id;
        private DateTime startDate;
        private DateTime endDate;
        private bool payed;
        private int bookerID;
        private Booker reservationBooker;
        private List<Account> accountList;
        private List<Campsite> campsiteList;
        private List<int> campsiteNumberList;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public bool Payed
        {
            get { return payed; }
            set { payed = value; }
        }

        public int BookerID
        {
            get { return bookerID; }
            set { bookerID = value; }
        }

        public Booker ReservationBooker
        {
            get { return reservationBooker; }
            set { reservationBooker = value; }
        }

        public List<Account> AccountList
        {
            get { return accountList; }
            set 
            { 
                if(accountList == null && value == null)
                {
                    accountList = new List<Account>();
                }
                accountList = value;
            }
        }

        public List<Campsite> CampsiteList
        {
            get { return campsiteList; }
            set 
            { 
                if(campsiteList == null && value == null)
                {
                    campsiteList = new List<Campsite>();
                }
            }
        }

        public List<int> CampsiteNumberList
        {
            get { return campsiteNumberList; }
            set
            {
                if(campsiteNumberList == null && value == null)
                {
                    campsiteNumberList = new List<int>();
                }
                campsiteNumberList = value;
            }
        }

        public Reservation()
        {

        }

        public Reservation(int id, DateTime startDate, DateTime endDate)
        {
            ID = id;
            StartDate = startDate;
            EndDate = endDate;
        }

        public Reservation(int id, DateTime startDate, DateTime endDate, bool payed)
        {
            ID = id;
            StartDate = startDate;
            EndDate = endDate;
            Payed = payed;
        }

        public Reservation(int id, DateTime startDate, DateTime endDate, bool payed, int bookerID)
        {
            ID = id;
            StartDate = startDate;
            EndDate = endDate;
            Payed = payed;
            BookerID = bookerID;
        }

        public Reservation(int id, DateTime startDate, DateTime endDate, bool payed, Booker reservationBooker)
        {
            ID = id;
            StartDate = startDate;
            EndDate = endDate;
            Payed = payed;
            ReservationBooker = reservationBooker;
        }
    }
}