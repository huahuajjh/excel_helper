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
            IList<Ticket> list = import.Import<Ticket>(new FileStream(@"F:\importTicket.xls", FileMode.Open));
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
        [ColDataConstraint(ConstraintsEnum.NOTNULL)]
        [ColDataPhone]
        public string Phone { get; set; }

        [Col("C")]
        [ColDataValid(DataTypeEnum.STRING)]
        [ColDataConstraint(ConstraintsEnum.NOTNULL)]
        [ColDataID]
        public string IdCard { get; set; }

        [Col("D")]
        [ColDataValid(DataTypeEnum.STRING)]
        [ColDataConstraint(ConstraintsEnum.NOTNULL)]
        [ColDataEquals("男", "女")]
        public string Gender { get; set; }

        [Col("E")]
        [ColDataValid(DataTypeEnum.INT)]
        [ColDataConstraint(ConstraintsEnum.NOTNULL)]
        public int SceneryId { get; set; }

        [Col("F")]
        [ColDataValid(DataTypeEnum.DATETIME)]
        [ColDataConstraint(ConstraintsEnum.NOTNULL)]
        public DateTime PlayTime { get; set; }

        [Col("G")]
        [ColDataValid(DataTypeEnum.INT)]
        [ColDataConstraint(ConstraintsEnum.NOTNULL)]
        public int BuyNumber { get; set; }

        [Col("H")]
        [ColDataValid(DataTypeEnum.STRING)]
        [ColDataConstraint(ConstraintsEnum.NOTNULL)]
        [ColDataEquals("是", "否")]
        public string IsPay { get; set; }

        [Col("I")]
        [ColDataValid(DataTypeEnum.STRING)]
        [ColDataMaxlength(20)]
        public string Community { get; set; }

        [Col("J")]
        [ColDataValid(DataTypeEnum.STRING)]
        [ColDataMaxlength(20)]
        public string Unit { get; set; }

        [Col("K")]
        [ColDataValid(DataTypeEnum.STRING)]
        [ColDataMaxlength(200)]
        public string Remarks { get; set; }

        [Col("L")]
        [ColDataValid(DataTypeEnum.STRING)]
        [ColDataMaxlength(20)]
        public string Recommender { get; set; }
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
