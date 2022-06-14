using UnitOfWork_Repository.Data.Model;

namespace UnitOfWork_Repository.Data.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        void Edit(User user);
        User Find(int id);
        void Remove(User user);
    }
}