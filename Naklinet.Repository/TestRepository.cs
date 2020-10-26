using Naklinet.Domain.Entities;
using Naklinet.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Naklinet.Repository
{
    public class TestRepository : GenericRepository<Shippers>, ITestRepository
    {
        public TestRepository(IUnitOfWork uow) : base(uow)
        {

        }

        public List<Shippers> GetShippers()
        {
            return _context.Shippers.ToList();
        }
        public Shippers GetShipper(int id)
        {
            return _context.Shippers.Where(s => s.ID == id).FirstOrDefault();
        }
    }
}
