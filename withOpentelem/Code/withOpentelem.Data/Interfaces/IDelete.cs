namespace withOpentelem.Data.Interfaces
{
    public interface IDelete<T>
    {
        bool Delete(T id);
    }
}
