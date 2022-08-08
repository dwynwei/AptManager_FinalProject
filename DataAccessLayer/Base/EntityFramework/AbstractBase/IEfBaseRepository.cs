using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Base
{
    public interface IEfBaseRepository<T> where T : class
    {
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        T Get(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll(Expression<Func<T,bool>> predicate = null);
        void SaveChages();
    }
}
