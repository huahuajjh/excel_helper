using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace attributes
{
    public class ColDataMaxlengthAttribute : BaseColValidateAttriute
    {
        private int row_index;
        private string col_name;

        private int length;

        public ColDataMaxlengthAttribute(int length)
        {
            this.length = length;
        }

        public override bool Validate(object _cell_data, int _row_index, string _col_name)
        {
            this.row_index = _row_index;
            this.col_name = _col_name;
            if (_cell_data == null || string.IsNullOrEmpty(_cell_data.ToString())) return true;
            return _cell_data.ToString().Length <= this.length;
        }

        public override string GetErrMsg()
        {
            return base.SetErrMsg(this.row_index, this.col_name, "内容长度不能超出" + this.length + "个字符");
        }
    }
}
