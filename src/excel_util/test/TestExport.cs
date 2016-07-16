using eh.attributes;
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
    public class TestExport
    {
        [TestMethod]
        public void TestExport1()
        {
            ExcelConfiguration cfg = new ExcelConfiguration();
            cfg.TemplatePath = @"D:\projects\excel_helper\docs\x.xlsx";
            ErrMsg err = new ErrMsg();
            IExport export = ExcelFactory.Instance().GetExcelExporter(cfg,err);
            IList<Person1> list = new List<Person1>();
            for (int i = 0; i < 300000;i++ )
            {
                Person1 p = new Person1();
                p.Age = i;
                p.gender = "g" + i;
                p.Name = "zs" + i;
                p.Time = DateTime.Now.AddHours(i);

                list.Add(p);
            }
            MemoryStream ms= export.Export<Person1>(list);
            FileStream file = new FileStream(@"D:\projects\excel_helper\docs\file.xlsx", FileMode.OpenOrCreate);
            BinaryWriter bw = new BinaryWriter(file);
            bw.Write(ms.ToArray());
            bw.Close();
            file.Close();
            ms.Close();

        }
    }

    public class Person1
    {
        [Col(1, "B")]
        public int Age { get; set; }

        [Col(0, "A")]
        public string Name { get; set; }

        [Col(2, "C")]
        public string gender { get; set; }
        [Col(3, "D")]
        public DateTime Time { get; set; }


    }
}
