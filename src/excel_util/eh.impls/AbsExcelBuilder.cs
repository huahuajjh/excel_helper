using eh.impls.configurations;
using eh.impls.errs;

namespace eh.impls
{
    public abstract class AbsExcelBuilder//:IImport,IExport
    {
        public abstract ExcelConfiguration ReadCfg();
        public abstract void LoadCfg(ExcelConfiguration cfg);
        public abstract void LoadErrMsg(ErrMsg _errmsg);
        public abstract ErrMsg ReadErrMsg();
        //public IList<T> Import<T>(Stream _stream, string _filename) where T : new();
       // public MemoryStream Export<T>(IList<T> data);
    }
}
