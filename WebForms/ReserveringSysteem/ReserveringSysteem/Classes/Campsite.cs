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
        private int size;
        private bool comfort;
        private int xCor;
        private int yCor;
        private bool crane;
        private bool handicap;

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

        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        public bool Comfort
        {
            get { return comfort; }
            set { comfort = value; }
        }

        public int XCor
        {
            get { return xCor; }
            set { xCor = value; }
        }

        public int YCor
        {
            get { return yCor; }
            set { yCor = value; }
        }

        public bool Crane
        {
            get { return crane; }
            set { crane = value; }
        }

        public bool Handicap
        {
            get { return handicap; }
            set { handicap = value; }
        }

        public Campsite()
        {
        
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
            return "ID: " + id.ToString() + "  -  Nummer: " + number.ToString() + "  -  Aantal personen: " + capacity.ToString() + "  -  Grootte: " + size.ToString() + "  -  Comfort: " + comfort.ToString() + "  - Heeft kraan: " + crane.ToString() + "  -  Handicap: " + handicap.ToString();
        }
    }
}