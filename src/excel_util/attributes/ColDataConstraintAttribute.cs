using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eh.attributes.enums;

namespace eh.attributes
{
    public class ColDataConstraintAttribute:Attribute,IColAbsValidateAttriute
    {
        private string ErrMsg { get; set; }
        public ConstraintsEnum[] Constraints { get; set; }
        public ColDataConstraintAttribute(params ConstraintsEnum[] _constraints)
        {
            this.Constraints = _constraints;
        }
        public bool Validate(object _cell_data, int _col_index, string _col_name)
        {
            foreach (var c in Constraints)
            {
                switch (c)
                {
                    case ConstraintsEnum.NOTNULL:
                        {
                            if (_cell_data == null)
                            {
                                SetErrMsg(_col_index, _col_name, "不能传入空的值");
                                return false;
                            }
                            else { return true; }
                        }

                    case ConstraintsEnum.NULL:
                        return true;

                    default:
                        return true;
                }
            }
            return true;
        }

        public string GetErrMsg()
        {
            return this.ErrMsg;
        }

        private void SetErrMsg(int _col_index, string _col_name, string _err_msg)
        {
            this.ErrMsg = String.Format("第[{0}]行,[{1}]列错误,{2}",_col_index,_col_name,_err_msg);
        }
        
    }
}
