using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eh.attributes;
using eh.attributes.enums;

namespace eh.test
{
    [TestClass]
    public class TestColDataAttr
    {
        [TestMethod]
        public void TestValid()
        {
            var b = new ColDataValidAttribute(DataTypeEnum.FLOAT);
            Assert.AreEqual(true,b.Validate(1.1f,1,"a"));
            Assert.AreEqual(false, b.Validate(1.1, 1, "a"));
            Assert.AreEqual(false, b.Validate(12, 1, "a"));
            Assert.AreEqual(false, b.Validate("abc", 1, "a"));

            b = new ColDataValidAttribute(DataTypeEnum.INT);
            Assert.AreEqual(false, b.Validate("abc", 1, "a"));
            Assert.AreEqual(false, b.Validate(1.2, 1, "a"));
            Assert.AreEqual(true, b.Validate(1, 1, "a"));

            b = new ColDataValidAttribute(DataTypeEnum.STRING);
            Assert.AreEqual(false, b.Validate(1, 1, "a"));
            Assert.AreEqual(false, b.Validate(1.2, 1, "a"));
            Assert.AreEqual(true, b.Validate("asd", 1, "a"));
            Assert.AreEqual(false, b.Validate(1.2f, 1, "a"));
            Assert.AreEqual(false, b.Validate(1.2d, 1, "a"));

            b = new ColDataValidAttribute(DataTypeEnum.BOOL);
            Assert.AreEqual(false, b.Validate(1, 1, "a"));
            Assert.AreEqual(false, b.Validate(1.2, 1, "a"));
            Assert.AreEqual(false, b.Validate("1.2", 1, "a"));
            Assert.AreEqual(true, b.Validate(true, 1, "a"));
            Assert.AreEqual(true, b.Validate(false, 1, "a"));

            b = new ColDataValidAttribute(DataTypeEnum.DATETIME);
            Assert.AreEqual(false, b.Validate("asd", 1, "a"));
            Assert.AreEqual(false, b.Validate(12, 1, "a"));
            Assert.AreEqual(false, b.Validate(12.2, 1, "a"));
            Assert.AreEqual(true, b.Validate(DateTime.Now, 1, "a"));
        }
    }
}
