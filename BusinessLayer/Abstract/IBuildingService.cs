﻿using BusinessLayer.Configuration.CommandResponse;
using DataTransferObject.Building.Requests;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBuildingService
    {
        public IEnumerable<SearchBuildingInformationRequest> GetAllBuildingInfo();
        public CommandResponse InsertBuildingInfo(CreateBuildingInformationRequest buildingReq);
        public CommandResponse UpdateBuildingInfo(CreateBuildingInformationRequest buildingReq);
        public void DeleteBuildingInfo(Building building);
    }
}