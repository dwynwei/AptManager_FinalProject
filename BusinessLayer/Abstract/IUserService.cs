using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Configuration.CommandResponse;
using DataTransferObject.User;
using DataTransferObject.User.Requests;
using Models;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        public IEnumerable<SearchUserRequest> getAllUserInfo();
        public CommandResponse InsertUserInfo (SearchUserRequest request);
        public CommandResponse UpdateUserInfo (SearchUserRequest request);
        public void DeleteUserInfo (User user);
    }
}
