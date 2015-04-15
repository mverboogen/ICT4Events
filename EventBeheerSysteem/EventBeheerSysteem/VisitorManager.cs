using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBeheerSysteem
{
    class VisitorManager
    {

        public List<Visitor> visitorList = new List<Visitor>();

        public void AddVisitor(Visitor visitor)
        {
            try
            {
                foreach (Visitor selectedVisitor in visitorList)
                {
                    if (selectedVisitor.ID == visitor.ID)
                    {
                        throw new UsedIDException("Visitor ID " + visitor.ID + ", is already used. No visitor was added");
                    }
                }

                visitorList.Add(visitor);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public void RemoveVisitor(Visitor visitor)
        {
            int index;

            index = visitorList.IndexOf(visitor);
            if(index != -1)
            {
                visitorList.Remove(visitor);
            }
            else
            {
                throw new UnkownIDException("Visitor ID " + visitor.ID + " was not found, no visitor was deleted");
            }
        }

        public void EditVisitor(Visitor visitor)
        {
            int index;

            index = visitorList.IndexOf(visitor);
            if (index != -1)
            {
                visitorList[index] = visitor;
            }
            else
            {
                throw new UnkownIDException("Campsite ID " + visitor.ID + " was not found, no campsite was edited");
            }
        }

        public Visitor GetVisitor(int id)
        {
            foreach (Visitor visitor in visitorList)
            {
                if (visitor.ID == id)
                {
                    return visitor;
                }
            }

            return null;
        }

        public Visitor SearchVisitorByName(string name)
        {

            foreach (Visitor visitor in visitorList)
            {
                if(visitor.Surname == name)
                {
                    return visitor;
                }
                else if (visitor.Lastname == name)
                {
                    return visitor;
                }
            }

            return null;
        }


        public List<Visitor> SearchVisitorByReservation(Reservation reservation)
        {
            if(reservation.VisitorList != null)
            {
                return reservation.VisitorList;
            }
            else
            {
                throw new NoVisitorException("This reservation has no visitors");
            }
        }

        public List<Visitor> SearchVisitorByCampSite(CampSite campSite)
        {
            
            if(campSite.CampSiteReservation == null)
            {
                throw new NoReservationException("This campsite has no reservation");
            }
            else if (campSite.CampSiteReservation.VisitorList != null)
            {
                return campSite.CampSiteReservation.VisitorList;
            }
            else
            {
                throw new NoVisitorException("This campsite reservation has no visitor list");
            }

        }

    }
}
