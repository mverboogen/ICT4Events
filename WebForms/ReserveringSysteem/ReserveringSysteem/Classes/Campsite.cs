using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReserveringSysteem
{
    public class Campsite
    {
        private int id;
        private int number;
        private int capacity;
        private decimal price;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public Campsite(int id)
        {
            this.id = id;
        }

        public Campsite(int id, int number, int capacity, decimal price)
        {
            this.id = id;
            this.number = number;
            this.capacity = capacity;
            this.price = price;
        }

        public override string ToString()
        {
            return "ID: " + id.ToString() + "  -  Nummer: " + number.ToString() + "  -  Aantal personen: " + capacity.ToString() + "  -  Prijs: " + price.ToString();
        }
    }
}