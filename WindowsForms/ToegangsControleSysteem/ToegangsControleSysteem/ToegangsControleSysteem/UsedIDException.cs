using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToegangsControleSysteem
{
    class UsedIDException : Exception
    {
        public UsedIDException()
        {

        }

        public UsedIDException(string message)
            :base(message)
        {

        }
    }
}
