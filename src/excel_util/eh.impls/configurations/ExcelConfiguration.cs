
namespace eh.impls.configurations
{
    public class ExcelConfiguration
    {
        /// <summary>
        /// 行起始值
        /// </summary>
        public int RowIndex { get; set; }
        /// <summary>
        /// 列起始值
        /// </summary>
        public int ColIndex { get; set; }
        /// <summary>
        /// sheet的起始号
        /// </summary>
        public int SheetIndex { get; set; }
        /// <summary>
        /// sheet数量
        /// </summary>
        public int SheetNum { get; set; }
        /// <summary>
        /// 要生成的excel版本
        /// </summary>
        public ExcelV ExcelVersion { get; set; }
        /// <summary>
        /// 生成excel的版本枚举
        /// </summary>
        public enum ExcelV { EXCEL2003=2003, EXCEL2007=2007 }
        /// <summary>
        /// 模板路径
        /// </summary>
        public string TemplatePath { get; set; }
        /// <summary>
        /// 模板起始sheet的index
        /// </summary>
        public int TemplateSheetIndex { get; set; }
        /// <summary>
        /// 写入数据到模板中，表明该值从第几行写入
        /// </summary>
        public int TemplateRowIndex { get; set; }
        /// <summary>
        /// 表明写入模板的起始列
        /// </summary>
        //public int TemplateColIndex { get { return 0; } set; }
        
        public ExcelConfiguration():this(0,0,0)
        {

        }

        public ExcelConfiguration(int _row_index,int _col_index,int _sheet_index)
        {
            this.ColIndex = _col_index;
            this.RowIndex = _row_index;
            this.SheetIndex = _sheet_index;
            this.TemplateRowIndex = 1;
            this.ExcelVersion = ExcelV.EXCEL2007;
            this.SheetNum = 1;
        }
    }
}
