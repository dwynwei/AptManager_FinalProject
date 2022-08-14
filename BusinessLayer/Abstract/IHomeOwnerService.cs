using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Configuration.CommandResponse;
using DataTransferObject.User;
using DataTransferObject.User.Requests;
using Models;
using Models.Entities;

namespace BusinessLayer.Abstract
{
    public interface IHomeOwnerService
    {
        public IEnumerable<SearchUserRequest> getAllUserInfo();
        public CommandResponse InsertUserInfo (CreateHomeOwnerRequest request);
        public CommandResponse UpdateUserInfo (UpdateHomeOwnerRequest request);
        public CommandResponse DeleteUserInfo (int id);
        public HomeOwner GetbyId(int id);
    }
}
