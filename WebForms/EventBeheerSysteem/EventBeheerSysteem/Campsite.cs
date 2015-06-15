using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventBeheerSysteem
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
        private Booker campsiteBooker;

        public int ID
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

        public Booker CampsiteBooker
        {
            get { return campsiteBooker; }
            set { campsiteBooker = value; }
        }

        public Campsite()
        {

        }

        public Campsite(int id, string name)
        {
            ID = id;
        }

        public Campsite(int id, int number, string name, int capacity, decimal price)
        {
            ID = id;
            Number = number;
            Capacity = capacity;
            Price = price;
        }
    }
}