using eh.attributes;
using eh.impls.configurations;
using eh.impls.errs;
using eh.interfaces;
using eh.util;
using eh.util.helper;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace eh.impls
{
    public class ExcelImportImpl:IImport
    {
        private ExcelConfiguration Cfg { get; set; }
        private ErrMsg ErrMsg { get; set; }
        public ExcelImportImpl(ExcelConfiguration cfg, ErrMsg err_msg)
        {
            this.Cfg = cfg;
            this.ErrMsg = err_msg;
        }
        public ExcelConfiguration ReadCfg()
        {
            return Cfg;
        }
        
        public ErrMsg ReadErrMsg()
        {
            return this.ErrMsg;
        }
        public IList<T> Import<T>(Stream _stream) where T : new()
        {
            IWorkbook wb = ExcelHelper.GenerateWorkbook(_stream);
            try
            {
                ISheet st = wb.GetSheetAt(Cfg.SheetIndex);
                var list = IterateRow<T>(st);
                if (this.ErrMsg.Count > 0)
                {
                    return null;
                }
                return list;
            }
            finally
            {
                wb.Close();
            }
        }

        private IList<K> IterateRow<K>(ISheet st) where K:new()
        {
            IList<K> list = new List<K>();
            int _row_count = st.LastRowNum;
            for (int i = Cfg.RowIndex; i <= _row_count; i++)
            {
                IRow _row = st.GetRow(i);
                if (_row == null) continue;
                K k = IterateCol<K>(_row);
                list.Add(k);
            }

            return list;
        }

        private E IterateCol<E>(IRow _row) where E : new()
        {
            Type type = typeof(E);
            E e = new E();
            
            var props = type.GetProperties();

            foreach (var p in props)
            {
                var valid_attrs = p.GetCustomAttributes(typeof(IColAbsValidateAttriute), true) as IColAbsValidateAttriute[];
                if (valid_attrs.Length <= 0) continue;
                var col_attr = Attribute.GetCustomAttribute(p, typeof(ColAttribute)) as ColAttribute;

                //validate data's efficiency
                foreach (var valid_attr in valid_attrs)
                {
                    bool r = valid_attr.Validate(ExcelHelper.GetCellValue(_row.GetCell(col_attr.ColIndex)), _row.RowNum+1, col_attr.ColName);
                    if (!r) { this.ErrMsg.AddErrMsg(valid_attr.GetErrMsg()); break; }
                }

                if (this.ErrMsg.Count > 0) continue;

                //put data into entity
                ICell cell = _row.GetCell(col_attr.ColIndex);
                SetDataIntoEntity(p, e,cell);
            }

            return e;
        }

        private void SetDataIntoEntity(PropertyInfo p,Object o, ICell cell)
        {

            if (p.PropertyType == typeof(DateTime))
            { 
                if(ExcelHelper.GetCellType(cell)==typeof(string))
                {
                    DateTime dt = DateTime.Now;
                    DateTime.TryParse(cell.StringCellValue, out dt);
                    p.SetValue(o, dt, null);
                }
                else
                {
                    p.SetValue(o, cell.DateCellValue, null);
                }
                
            }
            

            if(p.PropertyType == typeof(string))
            {
                switch (cell.CellType)
                {
                    case CellType.Blank:
                        p.SetValue(o, "NA", null);
                        break;
                    case CellType.Boolean:
                        p.SetValue(o, "NA", null);
                        break;
                    case CellType.Error:
                        p.SetValue(o, "Error", null);
                        break;
                    case CellType.Formula:
                        p.SetValue(o, cell.CellFormula, null);
                        break;
                    case CellType.Numeric:
                        p.SetValue(o, cell.NumericCellValue.ToString(), null);
                        break;
                    case CellType.String:
                        p.SetValue(o, cell.StringCellValue, null);
                        break;
                    case CellType.Unknown:
                        p.SetValue(o, "Unknown", null);
                        break;
                    default:
                        p.SetValue(o, "default", null);
                        break;
                }
            }

            if (!TypeUtil.CompType(p.PropertyType, ExcelHelper.GetCellType(cell))) return;

            else if (p.PropertyType == typeof(int)) p.SetValue(o, (int)cell.NumericCellValue, null);

            else return;
            
        }
    }
}
