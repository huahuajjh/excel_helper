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
        }
    }
}
