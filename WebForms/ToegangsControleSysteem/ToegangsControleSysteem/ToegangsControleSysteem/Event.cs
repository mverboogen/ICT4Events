using System;

namespace ToegangsControleSysteem
{
    public class Event
    {
        private string locationCity;
        private string locationStreet;
        private string locationZipCode;
        public int ID { get; set; }
        public string Name { get; set; }
        public int LocationID { get; set; }
        public string LocationName { get; set; }

        public string LocationStreet
        {
            get
            {
                if (locationStreet == null)
                {
                    return "";
                }
                return locationStreet;
            }
            set { locationStreet = value; }
        }

        public string LocationNumber { get; set; }

        public string LocationZipCode
        {
            get
            {
                if (locationZipCode == null)
                {
                    return "";
                }
                return locationZipCode;
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
                return locationCity;
            }
            set { locationCity = value; }
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxVisitors { get; set; }
    }
}