using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBeheerSysteem
{
    class Event : IComparable<Event>
    {
        private int id;
        private string name;
        private string location;
        private bool reservationsOpen;
        private DateTime beginDate;
        private DateTime endDate;
        private int maxVisitor;

        public ItemManager itemManager = new ItemManager();
        public ReservationManager reservationManager = new ReservationManager();
        public VisitorManager visitorManager = new VisitorManager();
        public CampSiteManager campsiteManager = new CampSiteManager();

        private DatabaseManager databaseHandler = new DatabaseManager();

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

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public bool ReservationsOpen
        {
            get { return reservationsOpen; }
            set { reservationsOpen = value; }
        }

        public DateTime BeginDate
        {
            get { return beginDate; }
            set { beginDate = value; }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public int MaxVisitor
        {
            get { return maxVisitor; }
            set { maxVisitor = value; }
        }

        public Event(int id, string location, DateTime startDate, DateTime endDate, DatabaseManager dbm)
        {
            ID = id;
            Location = location;
            BeginDate = startDate;
            EndDate = endDate;
        }

        public void LoadData()
        {
            itemManager.itemList = databaseHandler.GetAllItems(id);
            reservationManager.reservationList = databaseHandler.GetAllReservations(id);
            visitorManager.visitorList = databaseHandler.GetAllVisitors(id);
            campsiteManager.campSiteList = databaseHandler.GetAllCampSites(id);

            foreach(Reservation reservation in reservationManager.reservationList)
            {

                reservation.Booker = databaseHandler.GetBooker(id, reservation.ID);
                reservation.BookerID = reservation.Booker.ID;

                if(reservation.ReservedItemID != null)
                {
                    List<int> itemIDs = databaseHandler.GetReserverdItems(id, reservation.ID);
                    foreach(int itemID in itemIDs)
                    {
                        foreach(Item item in itemManager.itemList)
                        {
                            if(itemID == item.ID)
                            {
                                reservation.ItemList.Add(item);
                            }
                        }
                    }
                }

                foreach (CampSite campSite in campsiteManager.campSiteList)
                {
                    if (campSite.ReservationID == reservation.ID)
                    {
                        reservation.CampSiteList.Add(campSite);
                    }
                }

                foreach (Visitor visitor in visitorManager.visitorList)
                {
                    if (reservation.ID == visitor.ReservationID)
                    {
                        visitor.VisitorReservation = reservation;
                        visitor.VisitorBooker = reservation.Booker;
                        reservation.AddVisitor(visitor);
                    }
                } 
            }
        }

        public int CompareTo(Event e)
        {
            return id.CompareTo(e.ID);
        }
    }
}
