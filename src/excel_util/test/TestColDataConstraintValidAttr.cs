using eh.attributes;
using eh.attributes.enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test
{
    [TestClass]
    public class TestColDataConstraintValidAttr
    {
        [TestMethod]
        public void TestConstraint()
        {
            var b = new ColDataConstraintAttribute(ConstraintsEnum.NOTNULL);
            Assert.AreEqual(false, b.Validate(null, 1, "a"));
            Assert.AreEqual(true, b.Validate("as", 1, "a"));
            Assert.AreEqual(true, b.Validate(123, 1, "a"));
            Assert.AreEqual(true, b.Validate(true, 1, "a"));

            Console.WriteLine(b.GetErrMsg());
        }
    }
}
