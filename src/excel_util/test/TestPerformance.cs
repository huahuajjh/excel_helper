using eh.impls;
using eh.impls.configurations;
using eh.impls.errs;
using eh.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace test
{
    class TestPerformance
    {
        public static void Main()
        {
            ErrMsg msg = new ErrMsg();
            IImport import = ExcelFactory.Instance().GetExcelImporter(new ExcelConfiguration(), msg);
            IList<Person> list = import.Import<Person>(new FileStream(@"D:\projects\excel_helper\docs\p.xlsx", FileMode.Open), "p.xlsx");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
