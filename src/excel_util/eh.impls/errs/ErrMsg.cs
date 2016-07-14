using System;
using System.Collections.Generic;

namespace eh.impls.errs
{
    public class ErrMsg
    {
        private List<string> Errors;
        public int Count 
        {
            get { return Errors.Count; }
        }

        public ErrMsg()
        {
            Errors = new List<string>();
        }

        public void AddErrMsg(string msg)
        {
            Errors.Add(msg);
        }

        public List<String> GetErrors()
        {
            return Errors;
        }

    }
}
