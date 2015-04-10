using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBeheerSysteem
{
    class Reservation
    {
        private List<CampSite> campSiteList = new List<CampSite>();
        private List<Visitor> visitorList = new List<Visitor>();
        private List<Item> itemList = new List<Item>();

        private int id;
        private bool payed;
        private int bookerID;
        private Booker booker;
        private DateTime reservationDate;
        private DateTime checkinDate;
        private DateTime departDate;
        private int reservedItemID;
        private decimal price;
        private int visitorAmount;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int  BookerID
        {
            get { return bookerID; }
            set { bookerID = value; }
        }

        public Booker Booker
        {
            get { return booker; }
            set { booker = value; }
        }

        public DateTime ReservationDate
        {
            get { return reservationDate; }
            set { reservationDate = value; }
        }

        public DateTime CheckinDate
        {
            get { return checkinDate; }
            set { checkinDate = value; }
        }

        public DateTime DepartDate
        {
            get { return departDate; }
            set { departDate = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public int ReservedItemID
        {
            get { return reservedItemID; }
            set { reservedItemID = value; }
        }

        public int VisitorAmount
        {
            get { return visitorAmount; }
            set { visitorAmount = value; }
        }

        public bool Payed
        {
            get { return payed; }
            set { payed = value; }
        }

        public List<CampSite> CampSiteList
        {
            get { return campSiteList; }
        }

        public List<Visitor> VisitorList
        {
            get { return visitorList; }
        }

        public List<Item> ItemList
        {
            get { return itemList; }
        }

        public Reservation(int id, DateTime reservationDate)
        {
            ID = id;
            ReservationDate = reservationDate;
        }

        public Reservation(int id, Booker booker, DateTime reservationDate)
        {
            ID = id;
            Booker = booker;
            ReservationDate = reservationDate;
        }

        public void AddVisitor(Visitor visitor)
        {
            foreach(Visitor v in visitorList)
            {
                if(v.ID == visitor.ID)
                {
                    throw new UsedIDException("There is already a visitor added to this list with the same ID: " + visitor.ID);
                }
            }

            visitorList.Add(visitor);

            VisitorAmount = visitorList.Count;
        }

    }
}
