using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Base.MongoDB.AbstractBase
{
    public interface IDocumentRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(ObjectId id);
        void Update(T entity);
        T GetById(string id);
        T Get(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetAll(Expression<Func<T,bool>>expression=null);
    }
}
