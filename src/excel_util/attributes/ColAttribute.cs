using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eh.attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColAttribute : Attribute
    {
        private const string CELLVALS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private string _ColName;
        private int _ColIndex;

        public int ColIndex { get { return this._ColIndex; } }
        public string ColName
        {
            get
            {
                return this._ColName;
            }
            set
            {
                this._ColName = value.ToUpper();
                if(this.ColName.Length == 1)
                {
                    this._ColIndex = CELLVALS.IndexOf(this.ColName);
                }
                else if(this.ColName.Length == 2)
                {
                    int firstIndex = CELLVALS.IndexOf(this.ColName[0]);
                    int lastIndex = CELLVALS.IndexOf(this.ColName[1]);
                    if (firstIndex < 0 || lastIndex < 0)
                        this._ColIndex = -1;
                    else
                        this._ColIndex = (firstIndex + 1) * 26 + lastIndex;
                }
                else
                {
                    this._ColIndex = -1;
                }
            }
        }

        public ColAttribute(string _col_name)
        {
            this.ColName = _col_name;
        }
    }
}
