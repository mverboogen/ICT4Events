﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReserveringSysteem
{
    class Manager
    {
        private List<Visitor> visitors = new List<Visitor>();
        private List<Campsite> campsites = new List<Campsite>();
        private List<Item> items = new List<Item>();

        public List<Visitor> Visitors { get { return visitors; } }
        public List<Campsite> Campsites { get { return campsites; } }
        public List<Item> Items { get { return items; } }

        public void AddCampsite(Campsite campsite)
        {
            foreach(Campsite c in campsites)
            {
                if(c.CampsiteID == campsite.CampsiteID)
                {
                    MessageBox.Show("Deze kampeerplaats is al toegevoegd");
                    return;
                }
            }
            campsites.Add(campsite);
        }

        public void AddVisitor(Visitor visitor)
        {
            visitors.Add(visitor);
        }

        public void AddItem(Item item)
        {
            foreach(Item i in items)
            {
                if(i.ItemID == item.ItemID)
                {
                    MessageBox.Show("Dit item is al toegevoegd");
                    return;
                }
            }
            items.Add(item);
        }

        public Visitor FindVisitor(string VisitorID)
        {
            foreach (Visitor visitor in visitors)
            {
                if(visitor.Name.ToLower() == VisitorID.ToLower())
                {
                    return visitor;
                }
            }
            return null;
        }

        public Campsite FindCampsite(int CampsiteID)
        {
            foreach (Campsite campsite in campsites)
            {
                if (campsite.CampsiteID == CampsiteID)
                {
                    return campsite;
                }
            }
            return null;
        }
        public Item FindItem(int ItemID)
        {
            foreach (Item item in items)
            {
                if (item.ItemID == ItemID)
                {
                    return item;
                }
            }
            return null;
        }
        
        public void RemoveVisitor(Visitor visitor)
        {
            visitors.Remove(visitor);
        }
        
        public void RemoveCampsite(Campsite campsite)
        {
            campsites.Remove(campsite);
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }
         
    }
}
