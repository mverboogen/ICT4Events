﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBeheerSysteem
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
