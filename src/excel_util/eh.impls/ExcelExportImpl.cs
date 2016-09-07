using eh.attributes;
using eh.impls.configurations;
using eh.impls.errs;
using eh.interfaces;
using eh.util.helper;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace eh.impls
{
    public class ExcelExportImpl:IExport
    {
        private IWorkbook workbook;
        private ExcelConfiguration Cfg { get; set; }
        private ErrMsg ErrMsg { get; set; }
        public ExcelExportImpl(ExcelConfiguration cfg,ErrMsg msg)
        {
            this.Cfg = cfg;
            this.ErrMsg = msg;
        }
        public byte[] Export<T>(IList<T> data)
        {
            workbook = ExcelHelper.CreateWorkbook((int)Cfg.ExcelVersion, Cfg.TemplatePath);
            try
            {
                ISheet st = workbook.GetSheetAt(Cfg.TemplateSheetIndex);
                IteratorObj<T>(st, data);

                using (var ms = new MemoryStream())
                {
                    if (workbook != null)
                    {
                        workbook.Write(ms);
                        if (ms != null)
                        {
                            return ms.GetBuffer();
                        }
                        else
                        {
                            throw new NullReferenceException("尝试写入内存流，失败");
                        }
                    }
                    else
                    {
                        throw new NullReferenceException("生成工作簿异常，失败");
                    }
                }
            }
            finally
            {
                workbook.Close();
            }
        }

        private void IteratorObj<E>(ISheet st,IList<E> data)
        {
            foreach (var e in data)
            {
                int index = Cfg.TemplateRowIndex++;
                IRow row = st.GetRow(index);
                if(row == null) row = st.CreateRow(index);
                IteratorProp<E>(e, row);
            }
        }

        private void IteratorProp<E>(E e, IRow row)
        {
            Type type = e.GetType();
            var props = type.GetProperties();

            foreach (var p in props)
            {
                var col_attr = Attribute.GetCustomAttribute(p,typeof(ColAttribute)) as ColAttribute;
                ICell cell = row.GetCell(col_attr.ColIndex);
                if (cell == null) cell = row.CreateCell(col_attr.ColIndex);
                SetCellValueByPropType(p,e,cell);
            }
        }

        private void SetCellValueByPropType(PropertyInfo prop,object o,ICell cell)
        {
            if (prop.PropertyType.Equals(typeof(int))) cell.SetCellValue((int)prop.GetValue(o, null));

            else if (prop.PropertyType == typeof(bool)) cell.SetCellValue((bool)prop.GetValue(o, null));

            else if (prop.PropertyType == typeof(DateTime))
            {
                cell.SetCellValue((DateTime)prop.GetValue(o, null));
                ICellStyle styledate = workbook.CreateCellStyle();
                styledate.DataFormat = 0x16;
                cell.CellStyle = styledate;
            }

            else if (prop.PropertyType == typeof(string)) cell.SetCellValue((string)prop.GetValue(o, null));

            else throw new NullReferenceException("不支持该类型");
        }

    }
}
