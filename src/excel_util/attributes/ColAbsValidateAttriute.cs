using eh.attributes.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eh.attributes
{
    public abstract class ColAbsValidateAttriute
    {
        public abstract bool Validate(object _cell_data, int _col_index, string _col_name);
        public abstract string GetErrMsg();

    }
}
