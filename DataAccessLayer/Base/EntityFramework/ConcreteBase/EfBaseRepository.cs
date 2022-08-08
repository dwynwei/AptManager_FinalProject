using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Base
{
    public class EfBaseRepository<T, TDbContext> : IEfBaseRepository<T> 
        where T : class
        where TDbContext:DbContext
    {
        protected readonly TDbContext _dbContext;

        public EfBaseRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Add(T entity)
        {
            return _dbContext.Add(entity).Entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().FirstOrDefault(predicate);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if(predicate == null)
                return _dbContext.Set<T>().ToList();
            else
            {
                return _dbContext.Set<T>().Where(predicate);
            }
        }

        public void SaveChages()
        {
            _dbContext.SaveChanges();
        }

        public T Update(T entity)
        {
            _dbContext.Update(entity);
            return entity;
        }
    }
}
