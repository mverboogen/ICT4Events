using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToegangsControleSysteem
{
    class NoItemException : Exception
    {
        public NoItemException()
        {

        }

        public NoItemException(string message)
            :base(message)
        {

        }
    }
}
