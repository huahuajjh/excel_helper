using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eh.interfaces
{
    public interface IExport
    {
        MemoryStream Export<T>(IList<T> data);
    }
}
