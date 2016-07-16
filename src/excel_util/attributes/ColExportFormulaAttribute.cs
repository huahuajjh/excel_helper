using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace attributes
{
    public class ColExportFormulaAttribute:Attribute
    {
        public string Formula { get; set; }
        public ColExportFormulaAttribute(string formula)
        {
            this.Formula = formula;
        }
    }
}
