using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataTransferObject.Building.Requests;
using DataTransferObject.CreditCard;
using DataTransferObject.User;
using DataTransferObject.User.Requests;
using Models;
using Models.Entities;
using Models.MongoEntites;

namespace BusinessLayer.Configuration.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            #region Building AutoMapper
            CreateMap<CreateBuildingInformationRequest, Building>();
            CreateMap<UpdateBuildingInformationRequest, Building>();
            CreateMap<Building, SearchBuildingInformationRequest>();
            #endregion
            #region HomeOwnerMap AutoMapper
            CreateMap<UpdateHomeOwnerRequest, HomeOwner>();
            CreateMap<HomeOwner, SearchUserRequest>();
            CreateMap<CreateHomeOwnerRequest, HomeOwner>();
            #endregion UserMap End
            CreateMap<CreateCreditCardRequest, CreditCard>();
            CreateMap<UpdateCreditCardRequest, CreditCard>();

            CreateMap<CreateUserRegisterRequest, User>();
        }
    }
}
