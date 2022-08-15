using DataAccessLayer.Abstract;
using DataAccessLayer.Base;
using DataAccessLayer.DbContexts;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class UserRepository : EfBaseRepository<User, AptManagerDbContext>, IUserRepository
    {
        public UserRepository(AptManagerDbContext dbContext) : base(dbContext)
        {
        }

        public User GetUserWithPassword(string nationalityId) // Getting User With Password
        {
            return _dbContext.Users.Include(x=>x.Password).FirstOrDefault(x=>x.NationalityId == nationalityId);
        }
    }
}
