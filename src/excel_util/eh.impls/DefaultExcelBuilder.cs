using eh.impls.configurations;
using System;
using System.Collections.Generic;
using eh.impls.errs;
using System.IO;

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

        public IList<T> Import<T>(Stream _stream, string _filename)
        {
            return null;

        }

        public System.IO.MemoryStream Export<T>(IList<T> data)
        {
            throw new NotImplementedException();
        }
    }
}
