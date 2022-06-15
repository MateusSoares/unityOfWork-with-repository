using UnitOfWork_Repository.Data.Model;
using UnitOfWork_Repository.Data.Repository;

namespace UnitOfWork_Repository.Data.UnityOfWork
{
    public interface IUnitOfWork
    {
        IRepository Repository { get; set; }

        void Commit();
        void Dispose();
    }
}