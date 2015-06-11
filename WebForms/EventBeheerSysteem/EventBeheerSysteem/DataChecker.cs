using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventBeheerSysteem
{
    public class DataChecker
    {

        private static DataChecker self;

        private DataChecker()
        {
            self = this;
        }

        public static DataChecker GetInstance()
        {
            if(self == null)
            {
                self = new DataChecker();
            }

            return self;
        }
        
        public bool EventChanged(Event oldEvent, Event newEvent)
        {
            if (oldEvent.Name != newEvent.Name)
            {
                return true;
            }
            if (oldEvent.StartDate != newEvent.StartDate)
            {
                return true;
            }
            if (oldEvent.EndDate != newEvent.EndDate)
            {
                return true;
            }
            if (oldEvent.MaxVisitors != newEvent.MaxVisitors)
            {
                return true;
            }
            if (oldEvent.LocationName != newEvent.LocationName)
            {
                return true;
            }
            if (oldEvent.LocationCity != newEvent.LocationCity)
            {
                return true;
            }
            if (oldEvent.LocationStreet != newEvent.LocationStreet)
            {
                return true;
            }
            if (oldEvent.LocationNumber != newEvent.LocationNumber)
            {
                return true;
            }
            if (oldEvent.LocationZipCode != newEvent.LocationZipCode)
            {
                return true;
            }

            return false;
        }
    }
}