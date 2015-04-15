using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBeheerSysteem
{
    public class EventManager
    {
        public List<Event> eventList = new List<Event>();

        public DatabaseManager databaseHandler = new DatabaseManager();

        public EventManager()
        {
            GetAllEvents();
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

        public void GetAllEvents()
        {
            eventList.Clear();
            eventList = databaseHandler.GetEvents();
        }
    }
}
