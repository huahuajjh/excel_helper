
namespace eh.impls.configurations
{
    public class ExcelConfiguration
    {
        public int RowIndex { get { return 0; } set { } }
        public int ColIndex { get { return 0; } set { } }
        public int SheetIndex { get { return 0; } set { } }
        public int SheetNum { get { return 1; } set { } }

        public ExcelConfiguration()
        {
            
        }

        public ExcelConfiguration(int _row_index,int _col_index,int _sheet_index)
        {
            this.ColIndex = _col_index;
            this.RowIndex = _row_index;
            this.SheetIndex = _sheet_index;
        }
    }
}
