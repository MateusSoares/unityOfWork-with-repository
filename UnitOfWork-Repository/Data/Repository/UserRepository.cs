using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Repository.Data.Context;
using UnitOfWork_Repository.Data.Model;

namespace UnitOfWork_Repository.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Add<User>(user);
            _context.SaveChanges();
        }

        public void Edit(User user)
        {
            _context.Update<User>(user);
            _context.SaveChanges();
        }

        public void Remove(User user)
        {
            _context.Remove<User>(user);
            _context.SaveChanges();
        }

        public User Find(int id)
        {
            return _context.Find<User>(id);

        }

    }
}
