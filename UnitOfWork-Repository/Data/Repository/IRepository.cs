using System.Linq.Expressions;
using UnitOfWork_Repository.Data.Model;

namespace UnitOfWork_Repository.Data.Repository
{
    public interface IRepository
    {
        void Add<T>(T entity);
        void Edit<T>(T entity);
        T First<T>(Expression<Func<T, bool>> expression) where T : ModelBase;
        IQueryable<T> Query<T>(Expression<Func<T, bool>> expression) where T : ModelBase;
        void Remove<T>(T entity);
    }
}