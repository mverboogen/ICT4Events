using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToegangsControleSysteem
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

        public bool ReservationChanged(Reservation oldR, Reservation newR)
        {
            if(oldR.StartDate != newR.StartDate)
            {
                return true;
            }
            if (oldR.EndDate != newR.EndDate)
            {
                return true;
            }
            if (oldR.Payed != newR.Payed)
            {
                return true;
            }
            if (oldR.ReservationBooker.Street != newR.ReservationBooker.Street)
            {
                return true;
            }
            if (oldR.ReservationBooker.Number != newR.ReservationBooker.Number)
            {
                return true;
            }
            if (oldR.ReservationBooker.City != newR.ReservationBooker.City)
            {
                return true;
            }

            return false;
        }

        public bool ItemChanged(Item oldI, Item newI)
        {
            if (oldI.Brand != newI.Brand)
            {
                return true;
            }
            if (oldI.Serie != newI.Serie)
            {
                return true;
            }
            if (oldI.Price != newI.Price)
            {
                return true;
            }

            return false;
        }

        public bool CampsiteChanged(Campsite oldC, Campsite newC)
        {
            if(oldC.Capacity != newC.Capacity)
            {
                return true;
            }
            if(oldC.Size != newC.Size)
            {
                return true;
            }
            if(oldC.Comfort != newC.Comfort)
            {
                return true;
            }
            if(oldC.Crane != newC.Crane)
            {
                return true;
            }
            if(oldC.Handicap != newC.Handicap)
            {
                return true;
            }
            if(oldC.XCor != newC.XCor)
            {
                return true;
            }
            if(oldC.YCor != newC.YCor)
            {
                return true;
            }

            return false;
        }
    }
}