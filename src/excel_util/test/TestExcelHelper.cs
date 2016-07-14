using Microsoft.VisualStudio.TestTools.UnitTesting;
using eh.util.helper;
using System.IO;
using eh.impls.configurations;

namespace test
{
    [TestClass]
    public class TestExcelHelper
    {
        [TestMethod]
        public void TestGenerateWB()
        {
            var wb = ExcelHelper.GenerateWorkbook(@"D:\projects\excel_helper\docs\test.xlsx");
            var cfg = new ExcelConfiguration();

            var st = wb.GetSheetAt(cfg.SheetIndex);
            var row_num = st.LastRowNum;

            System.Console.WriteLine(row_num);
            System.Console.WriteLine(st.GetRow(row_num).GetCell(0));
        }
    }
}
