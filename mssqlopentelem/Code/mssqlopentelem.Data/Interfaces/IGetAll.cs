using System.Collections.Generic;

namespace mssqlopentelem.Data.Interfaces
{
    public interface IGetAll<T> where T : class
    {
        IEnumerable<T> GetAll();
    }
}
