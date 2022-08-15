using DataAccessLayer.Abstract;
using DataAccessLayer.Base;
using DataAccessLayer.DbContexts;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class HomeOwnerRepository : EfBaseRepository<HomeOwner, AptManagerDbContext>, IHomeRepository
    {
        public HomeOwnerRepository(AptManagerDbContext dbContext) : base(dbContext)
        {
        }

        public void Delete(int ownerId) // Deleting Entity By Id
        {
            _dbContext.Remove(ownerId);
        }
    }
}
