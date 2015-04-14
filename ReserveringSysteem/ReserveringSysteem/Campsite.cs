using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveringSysteem
{
    class Campsite
    {
        private int campsiteID;
        private decimal campPrice;
        private int maxOccupation;

        public int CampsiteID
        {
            get { return campsiteID; }
            set { campsiteID = value; }
        }

        public decimal CampPrice
        {
            get { return campPrice; }
            set { campPrice = value; }
        }

        public int MaxOccupation
        {
            get { return maxOccupation; }
            set { maxOccupation = value; }
        }

        public Campsite(int campsiteID, decimal campPrice, int maxOccupation)
        {
            this.CampsiteID = campsiteID;
            this.campPrice = campPrice;
            this.maxOccupation = maxOccupation;
        }
    }
}
