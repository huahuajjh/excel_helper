using eh.attributes.enums;
using eh.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eh.attributes
{
    public class ColDataValidAttribute : Attribute, IColAbsValidateAttriute
    {
        private DataTypeEnum DataType { get; set; }
        public ColDataValidAttribute(DataTypeEnum _data_type)
        {
            this.DataType = _data_type;
        }
        private string ErrMsg { get; set; }
        public bool Validate(object _cell_data,int _row_index,string _col_name)
        {
            if (_cell_data == null) return true;
            switch (DataType)
            {
                case DataTypeEnum.INT:
                    return Check(typeof(int), _cell_data.GetType(), _row_index, _col_name, "整数");

                case DataTypeEnum.BOOL:
                    return Check(typeof(bool), _cell_data.GetType(), _row_index, _col_name, "布尔");

                case DataTypeEnum.DATETIME:
                    return CheckDate(_cell_data.ToString(), _row_index, _col_name);

                case DataTypeEnum.DATE:
                    return CheckDate(_cell_data.ToString(),_row_index,_col_name);

                case DataTypeEnum.FLOAT:
                    return Check(typeof(float), _cell_data.GetType(), _row_index, _col_name, "小数");

                case DataTypeEnum.INT_N:
                    if (_cell_data as Type == typeof(Nullable)) return true;
                    else return Check(typeof(int), _cell_data.GetType(), _row_index, _col_name, "整数");

                case DataTypeEnum.BOOL_N:
                    if (_cell_data as Type == typeof(Nullable)) return true;
                    else return Check(typeof(bool), _cell_data.GetType(), _row_index, _col_name, "布尔");

                case DataTypeEnum.DATETIME_N:
                    if (_cell_data as Type == typeof(Nullable)) return true;
                    else return Check(typeof(DateTime), _cell_data.GetType(), _row_index, _col_name, "日期");

                case DataTypeEnum.FLOAT_N:
                    if (_cell_data as Type == typeof(Nullable)) return true;
                    else return Check(typeof(float), _cell_data.GetType(), _row_index, _col_name, "小数");

                default:
                    return true;
            }
        }
        public string GetErrMsg()
        {
            return ErrMsg;
        }
        private bool Check(Type _correct_data_type,Type _cell_data_type, int _col_index, string _col_name,string _type_name)
        {
            bool b = true;

            b = TypeUtil.CompType(_correct_data_type, _cell_data_type);

            if (!b) { this.ErrMsg = String.Format("第[{0}]行,第[{1}]列数据类型错误,此处应当为[{2}]类型", _col_index, _col_name, _type_name); }

            return b;
        }

        private bool CheckDate(string _cell_data, int _col_index, string _col_name)
        {
            if(TypeUtil.IsDate(_cell_data))
            { 
                return true;
            }
            else
            {
                this.ErrMsg = String.Format("第[{0}]行,第[{1}]列数据格式错误,日期格式错误",_col_index,_col_name);
                return false;
            }
        }
    }
}
