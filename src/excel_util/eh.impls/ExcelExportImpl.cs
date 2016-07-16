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
        private ExcelConfiguration Cfg { get; set; }
        private ErrMsg ErrMsg { get; set; }
        public ExcelExportImpl(ExcelConfiguration cfg,ErrMsg msg)
        {
            this.Cfg = cfg;
            this.ErrMsg = msg;
        }
        public MemoryStream Export<T>(IList<T> data)
        {
            IWorkbook wb = ExcelHelper.CreateWorkbook((int)Cfg.ExcelVersion,Cfg.TemplatePath);
            ISheet st = wb.GetSheetAt(Cfg.TemplateSheetIndex);

            IteratorObj <T>(st,data);

            using(var ms = new MemoryStream())
            {
            //var ms = new MemoryStream();
                if (wb != null)
                {
                    wb.Write(ms);
                    if (ms != null)
                    {
                        return ms;
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

        private void IteratorObj<E>(ISheet st,IList<E> data)
        {
            foreach (var e in data)
            {
                IRow row = st.CreateRow(Cfg.TemplateRowIndex++);
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
                ICell cell = row.CreateCell(col_attr.ColIndex);
                cell.SetCellValue(p.GetValue(e, null).ToString());
                //SetCellValueByPropType(p,e,cell);
            }
        }

        private void SetCellValueByPropType(PropertyInfo prop,object o,ICell cell)
        {
            if (prop.PropertyType == typeof(int)) cell.SetCellValue(prop.GetValue(o, null).ToString());

            else if (prop.PropertyType == typeof(bool)) cell.SetCellValue(prop.GetValue(o, null).ToString());

            else if (prop.PropertyType == typeof(DateTime)) cell.SetCellValue((DateTime)prop.GetValue(o, null));

            else cell.SetCellValue((string)prop.GetValue(o, null));
        }

    }
}
