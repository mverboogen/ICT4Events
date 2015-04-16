using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToegangsControleSysteem
{
    class NoVisitorException : Exception
    {
        
        public NoVisitorException()
        {

        }

        public NoVisitorException(string message)
            :base(message)
        {

        }

    }
}
