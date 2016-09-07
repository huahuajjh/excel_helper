using eh.util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eh.test
{
    [TestClass]
    public class TestUtil
    {
        [TestMethod]
        public void TestTypeComp()
        {
            Object o = new Int32();
            Object o1 = new String(new char[]{'1','2'});
            Object o2 = new Int32();
            Assert.AreEqual(true, TypeUtil.CompType(o2.GetType(), o.GetType()));
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
        }

        [TestMethod]
        public void TestIsDate()
        {
            Assert.AreEqual(true, TypeUtil.IsDate("2016.12.12"));
            Assert.AreEqual(true, TypeUtil.IsDate("2016-12-12"));
            Assert.AreEqual(true, TypeUtil.IsDate("2016/12/12"));
            Assert.AreEqual(true, TypeUtil.IsDate("2016年12月12日"));
            Assert.AreEqual(true, TypeUtil.IsDate("2016.12.12 12:12:12"));
            Assert.AreEqual(true, TypeUtil.IsDate("2016年12月12"));

            Assert.AreEqual(false, TypeUtil.IsDate("2016.13.12"));            
            Assert.AreEqual(false, TypeUtil.IsDate("2016年1212日"));
            Assert.AreEqual(false, TypeUtil.IsDate("201612月12日"));
            Assert.AreEqual(false, TypeUtil.IsDate(""));
            Assert.AreEqual(false, TypeUtil.IsDate("   "));
            Assert.AreEqual(false, TypeUtil.IsDate(null));

        }
    }
}
