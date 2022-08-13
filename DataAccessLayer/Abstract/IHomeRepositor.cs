using DataAccessLayer.Base;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IHomeRepository:IEfBaseRepository<HomeOwner>
    {
        public void Delete(int ownerId);
    }
}
