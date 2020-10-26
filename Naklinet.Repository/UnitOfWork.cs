using Naklinet.Repository.Context;
using Naklinet.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Naklinet.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly NaklinetDbContext _dbContext;
        public NaklinetDbContext DbContext => _dbContext;

        public UnitOfWork(NaklinetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {

        }
    }
}
