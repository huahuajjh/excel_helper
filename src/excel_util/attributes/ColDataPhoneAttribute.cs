using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace attributes
{
    public class ColDataPhoneAttribute : BaseColValidateAttriute
    {
        private int row_index;
        private string col_name;

        public override bool Validate(object _cell_data, int _row_index, string _col_name)
        {
            this.row_index = _row_index;
            this.col_name = _col_name;
            if (_cell_data == null || string.IsNullOrEmpty(_cell_data.ToString())) return true;
            return new Regex("^1[3|4|5|7|8][0-9]{9}$").IsMatch(_cell_data.ToString());
        }

        public override string GetErrMsg()
        {
            return base.SetErrMsg(this.row_index, this.col_name, "不是正确的手机号码格式");
        }
    }
}
