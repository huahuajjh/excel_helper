using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eh.util
{
    public static class TypeUtil
    {
        public static bool CompType(Type t1,Type t2) 
        {
            return t1 == t2 ? true : false;
        }

        public static bool IsDate(string date)
        {
            if (string.IsNullOrEmpty(date)) 
            {
                return false;
            }

            DateTime dt = DateTime.Now;
            bool r = DateTime.TryParse(date,out dt);
            return r;
        }
    }
}
