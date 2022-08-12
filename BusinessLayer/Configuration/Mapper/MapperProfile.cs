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
using Models.MongoEntites;

namespace BusinessLayer.Configuration.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            #region Building AutoMapper
            CreateMap<CreateBuildingInformationRequest, Building>();
            CreateMap<DeleteBuildingInformationRequest, Building>();
            CreateMap<UpdateBuildingInformationRequest, Building>();
            CreateMap<Building, SearchBuildingInformationRequest>();
            #endregion
            #region UserMap AutoMapper
            CreateMap<CreateUserRegisterRequest, User>();
            CreateMap<UpdateHomeOwnerRequest, User>();
            CreateMap<DeleteUserRequest, User>();
            CreateMap<User, SearchUserRequest>();
            CreateMap<CreateHomeOwnerRequest, User>();
            #endregion UserMap End
            CreateMap<CreateCreditCardRequest, CreditCard>();
            CreateMap<UpdateCreditCardRequest, CreditCard>();


        }
    }
}
