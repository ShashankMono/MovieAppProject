﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppLib.Exceptions
{
    internal class InvalidNameException:Exception
    {
        public InvalidNameException(string message):base(message) { }
    }
}
