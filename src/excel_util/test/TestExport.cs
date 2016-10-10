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
    public class TestExport
    {
        [TestMethod]
        public void TestExport1()
        {
            ExcelConfiguration cfg = new ExcelConfiguration();
            cfg.TemplatePath = @"f:\exportTicket.xlsx";
            cfg.TemplateRowIndex = 1;
            ErrMsg err = new ErrMsg();
            IExport export = ExcelFactory.Instance().GetExcelExporter(cfg, err);
            IList<Scenery> list = new List<Scenery>();
            for (int i = 0; i < 300; i++)
            {
                Scenery p = new Scenery();
                p.Id = i;
                p.Name = i.ToString();

                list.Add(p);
            }
            Byte[] ms = export.Export<Scenery>(list);
            FileStream file = new FileStream(@"f:\file.xlsx", FileMode.OpenOrCreate);
            BinaryWriter bw = new BinaryWriter(file);
            bw.Write(ms);
            bw.Close();
            file.Close();
        }
    }

    public class Scenery
    {
        [Col("A")]
        public int Id { get; set; }

        [Col("B")]
        public string Name { get; set; }

        [Col("C")]
        public string Remarks { get; set; }
    }

    //public class Person1
    //{
    //    [Col(1, "B")]
    //    public int Age { get; set; }

    //    [Col(0, "A")]
    //    public string Name { get; set; }

    //    [Col(2, "C")]
    //    public string gender { get; set; }
    //    [Col(3, "D")]
    //    public DateTime Time { get; set; }


    //}
}
