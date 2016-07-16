using eh.impls.configurations;
using eh.impls.errs;
using eh.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eh.impls
{
    public class ExcelFactory
    {
        private static ExcelFactory self;
        private ExcelFactory() { }
        public static ExcelFactory Instance()
        {
            if (self == null)
            {
                self = new ExcelFactory();
                return self;
            }
            else 
            {
                return self;
            }
        }
        public IImport GetExcelImporter(ExcelConfiguration cfg,ErrMsg msg)
        {
            return new ExcelImportImpl(cfg,msg);
        }
        public IExport GetExcelExporter(ExcelConfiguration cfg,ErrMsg msg)
        {
            return new ExcelExportImpl(cfg,msg);
        }
    }
}
