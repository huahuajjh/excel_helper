using eh.util.exceptions;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.IO;

namespace eh.util.helper
{
    public static class ExcelHelper
    {
        public static IWorkbook GenerateWorkbook(Stream stream,string _filename)
        {
            if (!_filename.EndsWith(".xls") && !_filename.EndsWith(".xlsx"))
            {
                throw new WrongFileTypeException("错误的文件类型,请上传excel格式的文件类型");
            }
            else
            {
                using(stream)
                {
                    return CreateWb2003Or2007(stream,_filename);
                }
            }

        }

        public static IWorkbook GenerateWorkbook(String _filename)
        {
            var fs = new FileStream(_filename,FileMode.Open);
            return GenerateWorkbook(fs,_filename);
        }

        private static IWorkbook CreateWb2003Or2007(Stream stream, string _filename)
        {
            IWorkbook wb = null;
            try {
                if (_filename.EndsWith(".xls"))
                {
                    wb = new HSSFWorkbook(stream);
                    return wb;
                }
                else
                {
                    wb = new XSSFWorkbook(stream);
                    return wb;
                }
            }catch(Exception ex)
            {
                throw new WrongFileTypeException("错误的文件类型,请上传excel格式的文件类型-"+ex.Message);
            }
        }

    }
}
