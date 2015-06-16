using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToegangsControleSysteem
{
    public class Event
    {

        private int id;
        private string name;
        private int locationID;
        private string locationName;
        private string locationStreet;
        private int locationNumber;
        private string locationZipCode;
        private string locationCity;
        private DateTime startDate;
        private DateTime endDate;
        private int maxVisistors;

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

        public int LocationID
        {
            get { return locationID; }
            set { locationID = value; }
        }

        public string LocationName
        {
            get { return locationName; }
            set { locationName = value; }
        }

        public string LocationStreet
        {
            get
            {
                if (locationStreet == null)
                {
                    return "";
                }
                else
                {
                    return locationStreet;
                }
            }
            set { locationStreet = value; }
        }

        public int LocationNumber
        {
            get { return locationNumber; }
            set { locationNumber = value; }
        }

        public string LocationZipCode
        {
            get
            {
                if (locationZipCode == null)
                {
                    return "";
                }
                else
                {
                    return locationZipCode;
                }
            }
            set { locationZipCode = value; }
        }

        public string LocationCity
        {
            get
            {
                if (locationCity == null)
                {
                    return "";
                }
                else
                {
                    return locationCity;
                }
            }
            set { locationCity = value; }
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

        public int MaxVisitors
        {
            get { return maxVisistors; }
            set { maxVisistors = value; }
        }
    }
}