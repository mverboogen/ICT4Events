using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBeheerSysteem
{
    class NoCampsiteException : Exception
    {

        public NoCampsiteException()
        {

        }

        public NoCampsiteException(string message)
            :base(message)
        {

        }

    }
}
