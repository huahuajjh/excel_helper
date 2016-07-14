using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.HSSF.UserModel;
using eh.attributes;

namespace test
{
    [TestClass]
    public class TestDefaultExcelUtil
    {
        [TestMethod]
        public void TestExport(NPOI.SS.UserModel.ICell cell) 
        {
            Object o = new String(new char[]{'a','v'});
            Assert.AreEqual(1.GetType(),o.GetType());
        }
    }
}
