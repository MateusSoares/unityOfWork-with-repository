using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Repository.Data.Context;
using UnitOfWork_Repository.Data.Model;
using UnitOfWork_Repository.Data.Repository;

namespace UnitOfWork_Repository.Data.UnityOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly DatabaseContext _context;
        public IRepository Repository { get; set; }

        public UnitOfWork(DatabaseContext context, IRepository repository)
        {
            _context = context;
            this.Repository = repository;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
