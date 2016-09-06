using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace attributes
{
    public class ColDataEqualsAttribute : BaseColValidateAttriute
    {
        private int row_index;
        private string col_name;

        private List<string> vals = new List<string>();

        public ColDataEqualsAttribute(params string[] vals)
        {
            if (vals == null || vals.Length == 0) throw new NotImplementedException("匹配的内容不能为空");
            this.vals.AddRange(vals);
        }

        public override bool Validate(object _cell_data, int _row_index, string _col_name)
        {
            this.row_index = _row_index;
            this.col_name = _col_name;
            if (_cell_data == null || string.IsNullOrEmpty(_cell_data.ToString())) return true;
            string val = _cell_data.ToString().Trim();
            return this.vals.Contains(val);
        }

        public override string GetErrMsg()
        {
            return base.SetErrMsg(this.row_index, this.col_name, "只能输入\"" + string.Join(",", this.vals) +"\"");
        }
    }
}
