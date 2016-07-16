using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eh.interfaces
{
    public interface IImport
    {
        IList<T> Import<T>(Stream _stream,string _filename) where T : new();
    }
}
