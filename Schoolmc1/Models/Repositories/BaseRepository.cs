using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Schoolmc1.Models.Repositories
{
    public class BaseRepository<T> where T : class
    {
        public DbContext context;

        public IEnumerable<T> Get()
        {
            return context.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }
        public void Update(int id, T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Insert(T entity)
        {
            context.Set<T>().Add(entity);
        }
        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }
        public IQueryable<T> GetBy(
            Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}