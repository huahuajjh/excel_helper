using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eh.attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColAttribute:Attribute
    {
        public int ColIndex { get; set; }
        public string ColName { get; set; }

        public ColAttribute(int _col_index,string _col_name)
        {
            this.ColIndex = _col_index;
            this.ColName = _col_name;
        }
    }
}
