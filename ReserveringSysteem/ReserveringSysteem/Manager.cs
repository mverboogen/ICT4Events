using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveringSysteem
{
    class Manager
    {
        public List<Visitor> visitors = new List<Visitor>();
        public List<Campsite> campsites = new List<Campsite>();

        public void AddCampsite(Campsite campsite)
        {
            campsites.Add(campsite);
        }

        public void AddVisitor(Visitor visitor)
        {
            visitors.Add(visitor);
        }

        public void RemoveVisitor(Visitor visitor)
        {
            visitors.Remove(visitor);
        }
    }
}
