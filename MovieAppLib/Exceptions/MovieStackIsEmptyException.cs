using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppLib.Exceptions
{
    public class MovieStackIsEmptyException:Exception
    {
        public MovieStackIsEmptyException(string message) : base(message) { }
    }
}
