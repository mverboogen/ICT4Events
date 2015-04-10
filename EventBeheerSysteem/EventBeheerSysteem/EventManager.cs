using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBeheerSysteem
{
    class EventManager
    {
        public List<Event> eventList = new List<Event>();

        public DatabaseManager databaseHandler = new DatabaseManager();

        public EventManager()
        {

            /*
            //TEST DATA
            //TODO: REMOVE TEST DATA
            eventList.Add(new Event(1, "Eindhoven", new DateTime(2015, 04, 01), new DateTime(2015, 04, 06)));
            eventList.Add(new Event(2, "Amsterdam", new DateTime(2015, 05, 06), new DateTime(2015, 04, 10)));
            eventList.Add(new Event(3, "Rotterdam", new DateTime(2015, 03, 08), new DateTime(2015, 04, 11)));
            eventList.Add(new Event(4, "Someren", new DateTime(2015, 08, 05), new DateTime(2015, 04, 15)));
            eventList.Add(new Event(5, "Miami", new DateTime(2015, 06, 21), new DateTime(2015, 04, 22)));
            

            Event eventHolder = GetEvent(1);

            try
            {
                AddEvent(new Event(6, "London", new DateTime(2015, 04, 20), new DateTime(2015, 04, 21)));
                Event e = GetEvent(10);
            }
            catch (UsedIDException UIE)
            {
                string message = UIE.Message;
            }
            */

            eventList = databaseHandler.GetEvents();
            eventList[0].LoadData();

        }

        public void AddEvent(Event e)
        {
            foreach(Event oldEvent in eventList)
            {
                if(oldEvent.ID == e.ID)
                {
                    throw new UsedIDException("Event ID " + e.ID +", is already used");
                }
            }

            eventList.Add(e);
        }

        public void RemoveEvent(Event e)
        {

            int index;

            index = eventList.IndexOf(e);
            if(index != -1)
            {
                eventList.Remove(e);
            }
            else
            {
                throw new UnkownIDException("Event was not found with " + e.ID + ", no event was deleted");
            }
        }

        public void EditEvent(Event e)
        {
            int index;

            index = eventList.IndexOf(e);
            if(index != -1)
            {
                eventList[index] = e;
            }
            else
            {
                throw new UnkownIDException("Event was not found with " + e.ID + ", no event was edited");
            }
        }

        public Event GetEvent(int id)
        {
            foreach(Event e in eventList)
            {
                if(e.ID == id)
                {
                    return e;
                }
            }

            return null;
        }
    }
}
