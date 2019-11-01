using JwtFinalGeneric.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace JwtFinalGeneric.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        readonly XContext _xcontext;

        public Repository(XContext xcontext)
        {
            _xcontext = xcontext;
        }

        public bool Delete(int id)
        {
            var result = false;
            var x = Find(id);

            if (x != null)
            {
                _xcontext.Set<T>().Remove(x);
                _xcontext.SaveChanges();
                result = true;
            }
            return result;
        }

        public T Find(int id)
        {
            return _xcontext.Set<T>().Find(id);
        }

        public T FindUsername(string username)
        {
            return _xcontext.Set<T>().Find(username);
        }

        public T Insert(T entity)
        {
            _xcontext.Set<T>().Add(entity);
            _xcontext.SaveChanges();
            return entity;
        }

        public List<T> List()
        {
            return _xcontext.Set<T>().ToList();
        }

        public T Update(T entity)
        {
            _xcontext.Set<T>().Update(entity);
            _xcontext.SaveChanges();
            return entity;
        }
    }
}
