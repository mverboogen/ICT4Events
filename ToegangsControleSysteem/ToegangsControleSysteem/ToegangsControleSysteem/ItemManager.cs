using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToegangsControleSysteem
{
    public class ItemManager
    {

        public List<Item> itemList = new List<Item>();

        public void AddItem(Item item)
        {
            foreach(Item selectedItem in itemList)
            {
                if(selectedItem.ID == item.ID)
                {
                    throw new UsedIDException("Item ID " + item.ID + " is already used, no item was added");
                }
            }

            itemList.Add(item);
        }

        public void RemoveItem(Item item)
        {
            int index;

            index = itemList.IndexOf(item);
            if (index != -1)
            {
                itemList.Remove(item);
            }
            else
            {
                throw new UnkownIDException("Campsite ID " + item.ID + " was not found, no campsite was deleted");
            }
        }

        public void EditItem(Item item)
        {
            int index;

            index = itemList.IndexOf(item);
            if(index != -1)
            {
                itemList[index] = item;
            }
            else
            {
                throw new UnkownIDException("Campsite ID " + item.ID + " was not found, no campsite was edited");
            }
        }

        public Item GetItem(int id)
        {
            foreach(Item item in itemList)
            {
                if(item.ID == id)
                {
                    return item;
                }
            }

            return null;
        }

        public Item SearchItemByName(string name)
        {
            foreach(Item item in itemList)
            {
                if(item.Name == name)
                {
                    return item;
                }
            }

            return null;
        }

        public List<Item> SearchItemByReservation(Reservation reservation)
        {
            if(reservation.ItemList != null)
            {
                return reservation.ItemList;
            }
            else
            {
                throw new NoItemException("This reservation has no Items reserved");
            }
        }

        public List<Item> SearchItemByVisitor(Visitor visitor)
        {
            if(visitor.VisitorReservation == null)
            {
                throw new NoReservationException("This visitor has no reservation");
            }
            if(visitor.VisitorReservation.ItemList != null)
            {
                return visitor.VisitorReservation.ItemList;
            }
            else
            {
                throw new NoItemException("This visitors reservation has no items reserved");
            }
        }

    }
}
