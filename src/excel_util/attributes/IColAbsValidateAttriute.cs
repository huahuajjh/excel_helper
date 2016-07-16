
namespace eh.attributes
{
    public interface IColAbsValidateAttriute
    {
        bool Validate(object _cell_data, int _row_index, string _col_name);
        string GetErrMsg();

    }
}
