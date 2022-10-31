using System.Collections.Generic;

namespace dotnetmssql.Data.Interfaces
{
    public interface IGetAll<T> where T : class
    {
        IEnumerable<T> GetAll();
    }
}
