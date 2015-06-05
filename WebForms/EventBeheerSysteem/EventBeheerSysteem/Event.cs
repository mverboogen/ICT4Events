using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventBeheerSysteem
{
    public class Event
    {

        private int id;
        private string name;
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

        public string LocationName
        {
            get { return locationName; }
            set { locationName = value; }
        }

        public string LocationStreet
        {
            get { return locationStreet; }
            set { locationStreet = value; }
        }

        public int LocationNumber
        {
            get { return locationNumber; }
            set { locationNumber = value; }
        }

        public string LocationZipCode
        {
            get { return locationZipCode; }
            set { locationZipCode = value; }
        }

        public string LocationCity
        {
            get { return locationCity; }
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