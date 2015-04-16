using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateriaalBeheerSysteem 
{
    public class CampSite : IComparable<CampSite>
    {
        private int id;
        private string name;
        private decimal price;
        private int type;
        private int campSize;
        private int maxOccupation;
        private int occupation;
        private int reservationID;
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

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public int CampSize
        {
            get { return campSize; }
            set { campSize = value; }
        }

        public int MaxOccupation
        {
            get { return maxOccupation; }
            set { maxOccupation = value; }
        }
        
        public int Occupation
        {
            get { return occupation; }
            set { occupation = value; }
        }

        public CampSite(int id)
        {
            ID = id;
        }

        public int ReservationID
        {
            get { return reservationID; }
            set { reservationID = value; }
        }

        public Reservation CampSiteReservation
        {
            get { return reservation; }
            set { reservation = value; }
        }

        public CampSite(int id, string name, decimal price, int type, int size, int maxOccupation)
        {
            ID = id;
            Name = name;
            Price = price;
            Type = type;
            CampSize = size;
            MaxOccupation = maxOccupation;
        }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(CampSite campSite)
        {
            return id.CompareTo(campSite.ID);
        }
    }
}
