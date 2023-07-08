using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using User.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dbContext;
        public IRoomRepository Rooms { get; }
        public IInventoryRepository Inventories { get; }

        public IUserRepository Users { get; }

        public UnitOfWork(DataContext dbContext, IRoomRepository products)
        {
            _dbContext = dbContext;
            Rooms = products;
        }

        public void Dispose()
        {
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }


        public int Save()
        {
            return _dbContext.SaveChanges();
        }
    }
}
