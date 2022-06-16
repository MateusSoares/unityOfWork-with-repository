using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Repository.Data.Context;
using UnitOfWork_Repository.Data.Model;

namespace UnitOfWork_Repository.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly DatabaseContext _context;

        public Repository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity)
        {
            _context.Add(entity);
        }

        public void AddRange<T>(IEnumerable<T> entities) where T : ModelBase
        {
            var entitiesContext = _context.Set<T>();
            entitiesContext.AddRange(entities);
        }

        public void Edit<T>(T entity)
        {
            _context.Update(entity);
        }

        public void EditRange<T>(IEnumerable<T> entities) where T : ModelBase
        {
            var entitiesContext = _context.Set<T>();
            entitiesContext.UpdateRange(entities);
        }

        public void Remove<T>(T entity)
        {
            _context.Remove(entity);
        }

        public void RemoveRange<T>(IEnumerable<T> entities) where T : ModelBase
        {
            var entitiesContext = _context.Set<T>();
            entitiesContext.RemoveRange(entities);
        }

        public T First<T>(Expression<Func<T, bool>> expression) where T : ModelBase
        {
            var entities = _context.Set<T>();
            return entities.FirstOrDefault(expression);

        }

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> expression) where T : ModelBase
        {
            var entities = _context.Set<T>();
            return entities.Where(expression);
        }

    }
}
