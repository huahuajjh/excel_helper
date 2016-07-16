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
            using(fs)
            {
                return GenerateWorkbook(fs,_filename);
            }
        }

        public static Type GetCellType(ICell cell) 
        {
            if (cell == null) { return typeof(Nullable); }

            switch (cell.CellType)
            {
                case CellType.Blank:
                    return typeof(Nullable);

                case CellType.Boolean:
                    return typeof(bool);

                case CellType.Error:
                    return typeof(Nullable);

                case CellType.Formula:
                    return typeof(Nullable);

                case CellType.Numeric:
                    {
                        if (HSSFDateUtil.IsCellDateFormatted(cell)) return typeof(DateTime);
                        else return typeof(int);
                    }

                case CellType.String:
                    return typeof(string);

                case CellType.Unknown:
                    return typeof(Nullable);

                default:
                    return typeof(string);
            }
        }

        public static Object GetCellValue(ICell cell)
        {
            switch (cell.CellType)
            {
                case CellType.Blank:
                    return null;
                case CellType.Boolean:
                    return cell.BooleanCellValue;
                case CellType.Error:
                    return null;
                case CellType.Formula:
                    return null;
                case CellType.Numeric:
                    {
                        if (HSSFDateUtil.IsCellDateFormatted(cell)) return cell.DateCellValue;
                        else return (int)cell.NumericCellValue;
                    }
                    
                case CellType.String:
                    return cell.StringCellValue;
                case CellType.Unknown:
                    return null;
                default:
                    return null;
            }
        }
        public static IWorkbook CreateWorkbook(int version,string path)
        {
            if (version.Equals(2003)) return new XSSFWorkbook(path);
            else return new XSSFWorkbook(path);
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
