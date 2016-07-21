using attributes;
using eh.attributes;
using eh.attributes.enums;
using eh.impls;
using eh.impls.configurations;
using eh.impls.errs;
using eh.interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace test
{
    [TestClass]
    public class TestImport
    {
        [TestMethod]
        public void TestImportExcel()
        {
            ErrMsg msg = new ErrMsg();
            IImport import = ExcelFactory.Instance().GetExcelImporter(new ExcelConfiguration(2, 0, 0),msg);
            IList<Ticket> list = import.Import<Ticket>(new FileStream(@"G:\路线导入模板.xls", FileMode.Open));
            if (msg.Count > 0)
            {
                foreach (var e in msg.GetErrors())
                {
                    Console.WriteLine(e);
                }
            }
            else
            { 
                Console.WriteLine(list.Count);
                foreach (var item in list)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    }

    public class Ticket
    {
        [Col("A")]
        [ColDataValid(DataTypeEnum.STRING)]
        [ColDataConstraint(ConstraintsEnum.NOTNULL)]
        [ColDataMaxlength(20)]
        public string Name { get; set; }

        [Col("B")]
        [ColDataValid(DataTypeEnum.STRING)]
        [ColDataID]
        [ColDataMaxlength(200)]
        public string Remarks { get; set; }

        [Col("C")]
        [ColDataValid(DataTypeEnum.STRING)]
        public string User { get; set; }

        public string[] Users
        {
            get
            {
                if (string.IsNullOrEmpty(this.User)) return new string[0];
                return this.User.Replace("，", ",").Split(',');
            }
        }
    }

    //public class Person
    //{
    //    [Col(1, "B")]
    //    [ColDataValid(DataTypeEnum.INT_N)]

    //    public int Age { get; set; }
        
    //    [Col(0, "A")]
    //    public string Name { get; set; }

    //    [Col(2, "C")]
    //    [ColDataValid(DataTypeEnum.STRING)]
    //    [ColDataConstraint(ConstraintsEnum.NOTNULL)]
    //    public string gender { get; set; }
    //    [Col(3,"D")]
    //    [ColDataValid(DataTypeEnum.DATETIME_N)]
    //    public DateTime Time { get; set; }

    //    public override string ToString()
    //    {
    //        return "name=" + Name  + "   age=" + Age+"   gender="+gender+"   time="+Time;
    //    }

    //}
}
