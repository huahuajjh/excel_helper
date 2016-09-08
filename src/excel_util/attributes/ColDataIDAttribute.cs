using eh.attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace attributes
{
    public class ColDataIDAttribute : BaseColValidateAttriute
    {
        private static readonly char[] VS = new char[] { '1', '0', 'x', '9', '8', '7', '6', '5', '4', '3', '2' };
        private static readonly int[] PS = new int[] { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };

        private int row_index;
        private string col_name;

        public override bool Validate(object _cell_data, int _row_index, string _col_name)
        {
            try
            {
                this.row_index = _row_index;
                this.col_name = _col_name;
                if (_cell_data == null || string.IsNullOrEmpty(_cell_data.ToString())) return true;
                string idCard = _cell_data.ToString().ToLower().Trim();
                if (new Regex("^\\d{15}$").IsMatch(idCard))
                    return true;
                else if (new Regex("^\\d{17}[0-9xX]$").IsMatch(idCard))
                {
                    int r = 0;
                    for (var i = 0; i < 17; i++)
                    {
                        r += PS[i] * int.Parse(idCard[i].ToString());
                    }
                    return VS[r % 11] == idCard[17];
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override string GetErrMsg()
        {
            return base.SetErrMsg(this.row_index, this.col_name, "不是正确的身份证格式");
        }
    }
}
