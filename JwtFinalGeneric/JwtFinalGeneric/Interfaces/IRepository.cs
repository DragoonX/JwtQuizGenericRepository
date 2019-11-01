using System.Collections.Generic;

namespace JwtFinalGeneric.Interfaces
{
    public interface IRepository<T> where T:class
    {
        List<T> List();
        T Insert(T entity);
        T Update(T entity);
        T Find(int id);
        T FindUsername(string username);
        bool Delete(int id);
    }
}
