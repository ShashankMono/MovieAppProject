using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppLib.Exceptions
{
    public class MovieStackFullException:Exception
    {
        public MovieStackFullException(string message):base(message) { }
    }
}
