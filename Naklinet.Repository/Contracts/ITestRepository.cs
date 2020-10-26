using Naklinet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Naklinet.Repository.Contracts
{
    public interface ITestRepository : IGenericRepository<Shippers>
    {
        List<Shippers> GetShippers();
        Shippers GetShipper(int id);
    }
}
