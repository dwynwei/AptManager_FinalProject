using DataAccessLayer.Abstract;
using DataAccessLayer.Base;
using DataAccessLayer.DbContexts;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class BuildingRepository : EfBaseRepository<Building, AptManagerDbContext>, IBuildingRepository
    {
        public BuildingRepository(AptManagerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
