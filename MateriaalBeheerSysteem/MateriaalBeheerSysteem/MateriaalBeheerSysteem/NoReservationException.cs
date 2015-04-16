using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateriaalBeheerSysteem
{
    class NoReservationException : Exception
    {
        public NoReservationException()
        {

        }

        public NoReservationException(string message)
            :base(message)
        {

        }

    }
}
