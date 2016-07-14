using eh.impls.configurations;
using System;
using System.Collections.Generic;
using eh.impls.errs;

namespace eh.impls
{
    public class DefaultExcelBuilder:AbsExcelBuilder
    {
        private ExcelConfiguration Cfg { get; set; }
        private ErrMsg ErrMsg { get; set; }

        public override ExcelConfiguration ReadCfg()
        {
            return Cfg;
        }

        public override void LoadCfg(ExcelConfiguration cfg)
        {
            this.Cfg = cfg;
        }

        public override void LoadErrMsg(ErrMsg _errmsg)
        {
            this.ErrMsg = _errmsg;
        }

        public override ErrMsg ReadErrMsg()
        {
            return this.ErrMsg;
        }

        public override IList<T> Import<T>(System.IO.Stream _stream)
        {
            Type type = typeof(T);
            T t = new T();

            var props = type.GetProperties();


            return null;

        }

        public override System.IO.MemoryStream Export<T>(IList<T> data)
        {
            throw new NotImplementedException();
        }
    }
}
