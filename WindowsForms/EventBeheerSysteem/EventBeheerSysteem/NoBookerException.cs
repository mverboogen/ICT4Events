using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBeheerSysteem
{
    class NoBookerException : Exception
    {

        public NoBookerException()
        {

        }

        public NoBookerException(string message)
            :base(message)
        {

        }
    }
}
