namespace withOpentelem.Data.Interfaces
{
    public interface IGetById<T> where T : class
    {
        T GetById(int id);
    }
}
