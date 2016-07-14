using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eh.util.exceptions
{
    public class WrongFileTypeException:Exception
    {
        public WrongFileTypeException(){}
        public WrongFileTypeException(string msg) : base(msg) {}
    }
}
