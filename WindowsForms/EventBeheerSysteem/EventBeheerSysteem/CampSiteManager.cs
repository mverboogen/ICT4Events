using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBeheerSysteem
{
    public class CampSiteManager
    {

        public List<CampSite> campSiteList = new List<CampSite>();

        public void AddCampSite(CampSite campSite)
        {

            foreach(CampSite selectedCampsite in campSiteList)
            {
                if(selectedCampsite.ID == campSite.ID)
                {
                    throw new UsedIDException("Campsite ID " + campSite.ID + " is already used, no campsite was added");
                }
            }

            campSiteList.Add(campSite);
        }

        public void RemoveCampSite(CampSite campSite)
        {
            int index;

            index = campSiteList.IndexOf(campSite);
            if(index != -1)
            {
                campSiteList.Remove(campSite);
            }
            else
            {
                throw new UnkownIDException("Campsite ID " + campSite.ID + " was not found, no campsite was deleted");
            }
        }

        public void EditCampSite(CampSite campSite)
        {
            int index;

            index = campSiteList.IndexOf(campSite);
            if(index != -1)
            {
                campSiteList[index] = campSite;
            }
            else
            {
                throw new UnkownIDException("Campsite ID " + campSite.ID + " was not found, no campsite was edited");
            }
        }

        public CampSite GetCampSite(int id)
        {
            foreach(CampSite campSite in campSiteList)
            {
                if(campSite.ID == id)
                {
                    return campSite;
                }
            }

            return null;
        }

        public List<CampSite> SearchCampSiteByReservaton(Reservation reservation)
        {
            if(reservation.CampSiteList != null)
            {
                return reservation.CampSiteList;
            }
            else
            {
                throw new NoCampsiteException("This reservation has no reserved Campsite");
            }
        }

        public List<CampSite> SearchCampSiteByVisitor(Visitor visitor)
        {
            if(visitor.VisitorReservation == null)
            {
                throw new NoReservationException("This visitor has no reservation");
            }
            else if(visitor.VisitorReservation.CampSiteList.Count > 0)
            {
                return visitor.VisitorReservation.CampSiteList;
            }
            else
            {
                throw new NoCampsiteException("The reservation of this visitor has no resevered Campsite");
            }
        }
    }
}
