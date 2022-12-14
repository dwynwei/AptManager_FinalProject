using DataAccessLayer.Base;
using Models;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IUserRepository:IEfBaseRepository<User>
    {
        User GetUserWithPassword(string nationalityId);
    }
}
