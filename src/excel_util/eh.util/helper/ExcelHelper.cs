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
        public static IWorkbook GenerateWorkbook(Stream stream)
        {
            using(stream)
            {
                return CreateWb2003Or2007(stream);
            }
        }

        public static IWorkbook GenerateWorkbook(String _filename)
        {
            var fs = new FileStream(_filename,FileMode.Open);
            using(fs)
            {
                return GenerateWorkbook(fs);
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
            if (cell == null) return null;
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
            FileInfo info = new FileInfo(path);
            using (System.IO.MemoryStream memStream = new System.IO.MemoryStream())
            {
                info.Open(FileMode.OpenOrCreate).CopyTo(memStream);
                return new XSSFWorkbook(memStream);
            }
        }
        private static IWorkbook CreateWb2003Or2007(Stream stream)
        {
            IWorkbook wb = null;
            try {
                if (NPOI.POIFS.FileSystem.POIFSFileSystem.HasPOIFSHeader(stream))
                {
                    wb = new HSSFWorkbook(stream);
                    return wb;
                }
                else if (NPOI.POIXMLDocument.HasOOXMLHeader(stream))
                {
                    wb = new XSSFWorkbook(stream);
                    return wb;
                }
                throw new WrongFileTypeException("错误的文件类型");
            }catch(Exception ex)
            {
                throw new WrongFileTypeException("错误的文件类型,请上传excel格式的文件类型-"+ex.Message);
            }
        }

    }
}
