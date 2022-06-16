using System.Linq.Expressions;
using UnitOfWork_Repository.Data.Model;

namespace UnitOfWork_Repository.Data.Repository
{
    public interface IRepository
    {
        void Add<T>(T entity);
        void AddRange<T>(IEnumerable<T> entities) where T : ModelBase;
        void Edit<T>(T entity);
        void EditRange<T>(IEnumerable<T> entities) where T : ModelBase;
        T First<T>(Expression<Func<T, bool>> expression) where T : ModelBase;
        IQueryable<T> Query<T>(Expression<Func<T, bool>> expression) where T : ModelBase;
        void Remove<T>(T entity);
        void RemoveRange<T>(IEnumerable<T> entities) where T : ModelBase;
    }
}