using eh.attributes.enums;
using eh.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eh.attributes
{
    public class ColDataValidAttribute : ColAbsValidateAttriute
    {
        private DataTypeEnum DataType { get; set; }
        public ColDataValidAttribute(DataTypeEnum _data_type)
        {
            this.DataType = _data_type;
        }
        private string ErrMsg { get; set; }
        public override bool Validate(object _cell_data,int _col_index,string _col_name)
        {
            switch (DataType)
            {       
                case DataTypeEnum.STRING:
                    return Check(typeof(string),_cell_data.GetType(),_col_index,_col_name,"字符串");

                case DataTypeEnum.INT:
                    return Check(typeof(int), _cell_data.GetType(), _col_index, _col_name, "整数");

                case DataTypeEnum.BOOL:
                    return Check(typeof(bool), _cell_data.GetType(), _col_index, _col_name, "布尔");

                case DataTypeEnum.DATETIME:
                    return Check(typeof(DateTime), _cell_data.GetType(), _col_index, _col_name, "日期");

                case DataTypeEnum.FLOAT:
                    return Check(typeof(float), _cell_data.GetType(), _col_index, _col_name, "小数");

                default:
                    this.ErrMsg = String.Format("{0}行,{1}列错误,未识别的数据类型",_col_index,_col_name);
                    return false;
            }
        }
        public override string GetErrMsg()
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

    }
}
