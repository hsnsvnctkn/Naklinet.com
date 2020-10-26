using Naklinet.Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Naklinet.Repository.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        NaklinetDbContext DbContext { get; }

        void SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
