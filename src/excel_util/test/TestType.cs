using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test
{
    [TestClass]
    public class TestType
    {
        [B]
        [C]
        public int MyProperty { get; set; }

        [TestMethod]
        public void TestType1()
        {
            var ps = typeof(TestType).GetProperties();
            foreach (var p in ps)
            {
                var attrs = p.GetCustomAttributes(typeof(B),true);
                foreach (var attr in attrs)
                {
                    Console.WriteLine(attr);
                }
            }

        }

        [TestMethod]
        public void TestTryParseInt()
        {
            int a = 123;
            double b = 12343111111d;
            int c = (int)b;
            Console.WriteLine(c);
        }
    }

    public interface A { }
    public class B :Attribute,A{ 
        
    }
    public class C : Attribute,A { }
}
