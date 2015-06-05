using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateriaalBeheerSysteem
{
    class UnkownIDException : Exception
    {
        public UnkownIDException()
        {

        }

        public UnkownIDException(string message)
            :base(message)
        {

        }
    }
}
