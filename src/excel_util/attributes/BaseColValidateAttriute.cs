using eh.attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace attributes
{
    public abstract class BaseColValidateAttriute : Attribute, IColAbsValidateAttriute
    {
        public abstract bool Validate(object _cell_data, int _row_index, string _col_name);

        public abstract string GetErrMsg();

        protected string SetErrMsg(int _col_index, string _col_name, string _err_msg)
        {
            return String.Format("第[{0}]行,[{1}]列错误,{2}", _col_index, _col_name, _err_msg);
        }
    }
}
