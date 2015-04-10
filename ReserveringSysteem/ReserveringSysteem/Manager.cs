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
