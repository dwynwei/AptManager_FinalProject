﻿using DataAccessLayer.Base;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBuildingRepository:IEfBaseRepository<Building>
    {
        public void Delete(int buildingId);
    }
}
