using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBeheerSysteem
{
    class Item : IComparable<Item>
    {
        private int id;
        private string name;
        private string brand;
        private decimal price;
        private decimal newPrice;
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

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public decimal NewPrice
        {
            get { return newPrice; }
            set { newPrice = value; }
        }

        public int ReservationID
        {
            get { return reservationID; }
            set { reservationID = value; }
        }

        public Reservation itemReservation
        {
            get { return reservation; }
            set { reservation = value; }
        }

        public Item(int id, string name, decimal price)
        {
            ID = id;
            Name = name;
            Price = price;
        }

        public Item(int id, string name, decimal price, decimal newPrice)
        {
            ID = id;
            Name = name;
            Price = price;
            NewPrice = newPrice;
        }

        public Item(int id, string name, string brand, decimal price, decimal newPrice)
        {
            ID = id;
            Name = name;
            Brand = brand;
            Price = price;
            NewPrice = newPrice;
        }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(Item item)
        {
            return id.CompareTo(item.ID);
        }
    }
}
