using System;
using System.Collections.Generic;

namespace ToegangsControleSysteem
{
    public class Reservation
    {
        private List<Account> accountList;
        private List<Campsite> campsiteList;
        private List<int> campsiteNumberList;
        public int ID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Payed { get; set; }
        public int BookerID { get; set; }
        public Booker ReservationBooker { get; set; }

        public List<Account> AccountList
        {
            get { return accountList; }
            set
            {
                if (accountList == null && value == null)
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
                if (campsiteList == null && value == null)
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
                if (campsiteNumberList == null && value == null)
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